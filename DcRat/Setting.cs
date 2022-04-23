using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DcRat
{
    internal class Setting
    {
        public static object LockListviewClients = new object();
        public static string HWID = getHWID();

        #region HWID

        public static string getHWID()
        {
            try
            {
                var strToHash = string.Concat(Environment.ProcessorCount, Environment.UserName,
                    Environment.MachineName, Environment.OSVersion
                    , new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize);
                var md5Obj = new MD5CryptoServiceProvider();
                var bytesToHash = Encoding.ASCII.GetBytes(strToHash);
                bytesToHash = md5Obj.ComputeHash(bytesToHash);
                var strResult = new StringBuilder();
                foreach (var b in bytesToHash) strResult.Append(b.ToString("x2"));

                return strResult.ToString().Substring(0, 20).ToUpper();
            }
            catch
            {
                return "Err HWID";
            }
        }

        #endregion
    }
}