using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Listener
    {
        private Socket listener { get; set; }

        public void Connect()
        {
            try
            {
                var IpEndPoint = new IPEndPoint(IPAddress.Any, Settings.Port);
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
                {
                    SendBufferSize = 50 * 1024,
                    ReceiveBufferSize = 50 * 1024
                };
                listener.Bind(IpEndPoint);
                listener.Listen(20);

                listener.BeginAccept(EndAccept, null);
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }

        private void EndAccept(IAsyncResult ar)
        {
            try
            {
                var CL = new Clients(listener.EndAccept(ar))
                {
                    Info =
                    {
                        LastPing = DateTime.Now
                    }
                };
            }
            catch
            {
            }

            finally
            {
                listener.BeginAccept(EndAccept, null);
            }
        }
    }
}