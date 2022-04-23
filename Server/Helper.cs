using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Server
{
    internal class Helper
    {
        public static object LockReceivedSendValue { get; set; }

        public static double DiffSeconds(DateTime startTime, DateTime endTime)
        {
            var secondSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
            return Math.Abs(secondSpan.TotalSeconds);
        }

        public class Aes
        {
            private static byte[] keyArray = Encoding.UTF8.GetBytes("DcRat_qwqdanchun");

            public static byte[] Encrypt(byte[] toEncryptArray)
            {
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return resultArray;
            }

            public static byte[] Decrypt(byte[] toEncryptArray)
            {
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return resultArray;
            }
        }
    }
}