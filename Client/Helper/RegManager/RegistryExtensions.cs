using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace Client.Helper.RegManager
{
    internal static class RegistryExtensions
    {
        [Flags]
        public enum RegistryAccessMask
        {
            QueryValue = 0x0001,
            SetValue = 0x0002,
            CreateSubKey = 0x0004,
            EnumerateSubKeys = 0x0008,
            Notify = 0x0010,
            CreateLink = 0x0020,
            WoW6432 = 0x0200,
            Wow6464 = 0x0100,
            Write = 0x20006,
            Read = 0x20019,
            Execute = 0x20019,
            AllAccess = 0xF003F
        }

        public enum RegistryView
        {
            Registry86,
            Registry64
        }

        public static RegistryKey OpenBaseKey(RegistryHive registryHive, RegistryView registryType)
        {
            var _hiveKeys = new Dictionary<RegistryHive, UIntPtr>
            {
                {RegistryHive.ClassesRoot, new UIntPtr(0x80000000u)},
                {RegistryHive.CurrentConfig, new UIntPtr(0x80000005u)},
                {RegistryHive.CurrentUser, new UIntPtr(0x80000001u)},
                {RegistryHive.DynData, new UIntPtr(0x80000006u)},
                {RegistryHive.LocalMachine, new UIntPtr(0x80000002u)},
                {RegistryHive.PerformanceData, new UIntPtr(0x80000004u)},
                {RegistryHive.Users, new UIntPtr(0x80000003u)}
            };

            var _accessMasks = new Dictionary<RegistryView, RegistryAccessMask>
            {
                {RegistryView.Registry64, RegistryAccessMask.Wow6464},
                {RegistryView.Registry86, RegistryAccessMask.WoW6432}
            };

            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version.Major <= 5)
                throw new PlatformNotSupportedException(
                    "The platform or operating system must be Windows XP or later.");

            var hiveKey = _hiveKeys[registryHive];
            var flags = RegistryAccessMask.QueryValue | RegistryAccessMask.EnumerateSubKeys |
                        _accessMasks[registryType];

            var result = Native.RegOpenKeyEx(hiveKey, string.Empty, 0, (uint) flags, out var keyHandlePointer);
            if (result == 0)
            {
                var safeRegistryHandleType =
                    typeof(SafeHandleZeroOrMinusOneIsInvalid).Assembly.GetType(
                        "Microsoft.Win32.SafeHandles.SafeRegistryHandle");
                var safeRegistryHandleConstructor =
                    safeRegistryHandleType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null,
                        new[] {typeof(IntPtr), typeof(bool)}, null) ??
                    safeRegistryHandleType.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null,
                        new[] {typeof(IntPtr), typeof(bool)}, null);

                var keyHandle = safeRegistryHandleConstructor.Invoke(new object[] {keyHandlePointer, true});
                var net3Constructor = typeof(RegistryKey).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                    null, new[] {safeRegistryHandleType, typeof(bool)}, null);
                var net4Constructor = typeof(RegistryKey).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                    null, new[] {typeof(IntPtr), typeof(bool), typeof(bool), typeof(bool), typeof(bool)}, null);
                object key;

                if (net4Constructor != null)
                {
                    key = net4Constructor.Invoke(new object[]
                        {keyHandlePointer, true, false, false, hiveKey == _hiveKeys[RegistryHive.PerformanceData]});
                }
                else if (net3Constructor != null)
                {
                    key = net3Constructor.Invoke(new[] {keyHandle, true});
                }
                else
                {
                    var keyFromHandleMethod = typeof(RegistryKey).GetMethod("FromHandle",
                        BindingFlags.Static | BindingFlags.Public, null, new[] {safeRegistryHandleType}, null);
                    key = keyFromHandleMethod.Invoke(null, new[] {keyHandle});
                }

                var field = typeof(RegistryKey).GetField("keyName", BindingFlags.Instance | BindingFlags.NonPublic);
                if (field != null)
                    switch (registryHive)
                    {
                        case RegistryHive.ClassesRoot:
                        {
                            field.SetValue(key, "HKEY_CLASSES_ROOT");
                            break;
                        }
                        case RegistryHive.CurrentUser:
                        {
                            field.SetValue(key, "HKEY_CURRENT_USER");
                            break;
                        }
                        case RegistryHive.LocalMachine:
                        {
                            field.SetValue(key, "HKEY_LOCAL_MACHINE");
                            break;
                        }
                        case RegistryHive.Users:
                        {
                            field.SetValue(key, "HKEY_USERS");
                            break;
                        }
                        case RegistryHive.PerformanceData:
                        {
                            field.SetValue(key, "HKEY_PERFORMANCE_DATA");
                            break;
                        }
                        case RegistryHive.CurrentConfig:
                        {
                            field.SetValue(key, "HKEY_CURRENT_CONFIG");
                            break;
                        }
                        default:
                        {
                            field.SetValue(key, string.Empty);
                            break;
                        }
                    }

                return (RegistryKey) key;
            }

            if (result == 2) // NOT_FOUND
                return null;

            throw new Win32Exception(result);
        }
    }
}