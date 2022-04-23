using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MessagePack
{
    public class MsgPackEnum : IEnumerator
    {
        List<MsgPack> children;
        int position = -1;

        public MsgPackEnum(List<MsgPack> obj)
        {
            children = obj;
        }
        object IEnumerator.Current => children[position];

        bool IEnumerator.MoveNext()
        {
            position++;
            return (position < children.Count);
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

    }

    public class MsgPackArray
    {
        List<MsgPack> children;
        MsgPack owner;

        public MsgPackArray(MsgPack msgpackObj, List<MsgPack> listObj)
        {
            owner = msgpackObj;
            children = listObj;
        }

        public MsgPack Add()
        {
            return owner.AddArrayChild();
        }

        public MsgPack Add(String value)
        {
            MsgPack obj = owner.AddArrayChild();
            obj.AsString = value;
            return obj;
        }

        public MsgPack Add(Int64 value)
        {
            MsgPack obj = owner.AddArrayChild();
            obj.SetAsInteger(value);
            return obj;
        }

        public MsgPack Add(Double value)
        {
            MsgPack obj = owner.AddArrayChild();
            obj.SetAsFloat(value);
            return obj;
        }

        public MsgPack this[int index] => children[index];

        public int Length => children.Count;
    }

    public class MsgPack : IEnumerable
    {
        string name;
        string lowerName;
        object innerValue;
        MsgPackType valueType;
        MsgPack parent;
        List<MsgPack> children = new List<MsgPack>();
        MsgPackArray refAsArray;

        private void SetName(string value)
        {
            name = value;
            lowerName = name.ToLower();
        }

        private void Clear()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].Clear();
            }
            children.Clear();
        }

        private MsgPack InnerAdd()
        {
            MsgPack r = new MsgPack
            {
                parent = this
            };
            children.Add(r);
            return r;
        }

        private int IndexOf(string name)
        {
            int i = -1;
            int r = -1;

            string tmp = name.ToLower();
            foreach (MsgPack item in children)
            {
                i++;
                if (tmp.Equals(item.lowerName))
                {
                    r = i;
                    break;
                }
            }
            return r;
        }

        public MsgPack FindObject(string name)
        {
            int i = IndexOf(name);
            if (i == -1)
            {
                return null;
            }

            return children[i];
        }


        private MsgPack InnerAddMapChild()
        {
            if (valueType != MsgPackType.Map)
            {
                Clear();
                valueType = MsgPackType.Map;
            }
            return InnerAdd();
        }

        private MsgPack InnerAddArrayChild()
        {
            if (valueType != MsgPackType.Array)
            {
                Clear();
                valueType = MsgPackType.Array;
            }
            return InnerAdd();
        }

        public MsgPack AddArrayChild()
        {
            return InnerAddArrayChild();
        }

        private void WriteMap(Stream ms)
        {
            byte b;
            byte[] lenBytes;
            int len = children.Count;
            if (len <= 15)
            {
                b = (byte)(0x80 + (byte)len);
                ms.WriteByte(b);
            }
            else if (len <= 65535)
            {
                b = 0xDE;
                ms.WriteByte(b);

                lenBytes = BytesTools.SwapBytes(BitConverter.GetBytes((Int16)len));
                ms.Write(lenBytes, 0, lenBytes.Length);
            }
            else
            {
                b = 0xDF;
                ms.WriteByte(b);
                lenBytes = BytesTools.SwapBytes(BitConverter.GetBytes(len));
                ms.Write(lenBytes, 0, lenBytes.Length);
            }

            for (int i = 0; i < len; i++)
            {
                WriteTools.WriteString(ms, children[i].name);
                children[i].Encode2Stream(ms);
            }
        }

        private void WirteArray(Stream ms)
        {
            byte b;
            byte[] lenBytes;
            int len = children.Count;
            if (len <= 15)
            {
                b = (byte)(0x90 + (byte)len);
                ms.WriteByte(b);
            }
            else if (len <= 65535)
            {
                b = 0xDC;
                ms.WriteByte(b);

                lenBytes = BytesTools.SwapBytes(BitConverter.GetBytes((Int16)len));
                ms.Write(lenBytes, 0, lenBytes.Length);
            }
            else
            {
                b = 0xDD;
                ms.WriteByte(b);
                lenBytes = BytesTools.SwapBytes(BitConverter.GetBytes(len));
                ms.Write(lenBytes, 0, lenBytes.Length);
            }


            for (int i = 0; i < len; i++)
            {
                children[i].Encode2Stream(ms);
            }
        }

        public void SetAsInteger(Int64 value)
        {
            innerValue = value;
            valueType = MsgPackType.Integer;
        }

        public void SetAsUInt64(UInt64 value)
        {
            innerValue = value;
            valueType = MsgPackType.UInt64;
        }

        public UInt64 GetAsUInt64()
        {
            switch (valueType)
            {
                case MsgPackType.Integer:
                    return Convert.ToUInt64((Int64)innerValue);
                case MsgPackType.UInt64:
                    return (UInt64)innerValue;
                case MsgPackType.String:
                    return UInt64.Parse(innerValue.ToString().Trim());
                case MsgPackType.Float:
                    return Convert.ToUInt64((Double)innerValue);
                case MsgPackType.Single:
                    return Convert.ToUInt64((Single)innerValue);
                case MsgPackType.DateTime:
                    return Convert.ToUInt64((DateTime)innerValue);
                default:
                    return 0;
            }

        }

        public Int64 GetAsInteger()
        {
            switch (valueType)
            {
                case MsgPackType.Integer:
                    return (Int64)innerValue;
                case MsgPackType.UInt64:
                    return Convert.ToInt64((Int64)innerValue);
                case MsgPackType.String:
                    return Int64.Parse(innerValue.ToString().Trim());
                case MsgPackType.Float:
                    return Convert.ToInt64((Double)innerValue);
                case MsgPackType.Single:
                    return Convert.ToInt64((Single)innerValue);
                case MsgPackType.DateTime:
                    return Convert.ToInt64((DateTime)innerValue);
                default:
                    return 0;
            }
        }

        public Double GetAsFloat()
        {
            switch (valueType)
            {
                case MsgPackType.Integer:
                    return Convert.ToDouble((Int64)innerValue);
                case MsgPackType.String:
                    return Double.Parse((String)innerValue);
                case MsgPackType.Float:
                    return (Double)innerValue;
                case MsgPackType.Single:
                    return (Single)innerValue;
                case MsgPackType.DateTime:
                    return Convert.ToInt64((DateTime)innerValue);
                default:
                    return 0;
            }
        }


        public void SetAsBytes(byte[] value)
        {
            innerValue = value;
            valueType = MsgPackType.Binary;
        }

        public byte[] GetAsBytes()
        {
            switch (valueType)
            {
                case MsgPackType.Integer:
                    return BitConverter.GetBytes((Int64)innerValue);
                case MsgPackType.String:
                    return BytesTools.GetUtf8Bytes(innerValue.ToString());
                case MsgPackType.Float:
                    return BitConverter.GetBytes((Double)innerValue);
                case MsgPackType.Single:
                    return BitConverter.GetBytes((Single)innerValue);
                case MsgPackType.DateTime:
                    long dateval = ((DateTime)innerValue).ToBinary();
                    return BitConverter.GetBytes(dateval);
                case MsgPackType.Binary:
                    return (byte[])innerValue;
                default:
                    return new byte[] { };
            }
        }

        public void Add(string key, String value)
        {
            MsgPack tmp = InnerAddArrayChild();
            tmp.name = key;
            tmp.SetAsString(value);
        }

        public void Add(string key, int value)
        {
            MsgPack tmp = InnerAddArrayChild();
            tmp.name = key;
            tmp.SetAsInteger(value);
        }

        public bool LoadFileAsBytes(string fileName)
        {
            if (File.Exists(fileName))
            {
                byte[] value = null;
                FileStream fs = new FileStream(fileName, FileMode.Open);
                value = new byte[fs.Length];
                fs.Read(value, 0, (int)fs.Length);
                fs.Close();
                SetAsBytes(value);
                return true;
            }

            return false;

        }

        public bool SaveBytesToFile(string fileName)
        {
            if (innerValue != null)
            {
                FileStream fs = new FileStream(fileName, FileMode.Append);
                fs.Write(((byte[])innerValue), 0, ((byte[])innerValue).Length);
                fs.Close();
                return true;
            }

            return false;
        }

        public MsgPack ForcePathObject(string path)
        {
            MsgPack tmpParent, tmpObject;
            tmpParent = this;
            string[] pathList = path.Trim().Split('.', '/', '\\');
            string tmp = null;
            if (pathList.Length == 0)
            {
                return null;
            }

            if (pathList.Length > 1)
            {
                for (int i = 0; i < pathList.Length - 1; i++)
                {
                    tmp = pathList[i];
                    tmpObject = tmpParent.FindObject(tmp);
                    if (tmpObject == null)
                    {
                        tmpParent = tmpParent.InnerAddMapChild();
                        tmpParent.SetName(tmp);
                    }
                    else
                    {
                        tmpParent = tmpObject;
                    }
                }
            }
            tmp = pathList[pathList.Length - 1];
            int j = tmpParent.IndexOf(tmp);
            if (j > -1)
            {
                return tmpParent.children[j];
            }

            tmpParent = tmpParent.InnerAddMapChild();
            tmpParent.SetName(tmp);
            return tmpParent;
        }

        public void SetAsNull()
        {
            Clear();
            innerValue = null;
            valueType = MsgPackType.Null;
        }

        public void SetAsString(String value)
        {
            innerValue = value;
            valueType = MsgPackType.String;
        }

        public String GetAsString()
        {
            if (innerValue == null)
            {
                return "";
            }

            return innerValue.ToString();

        }

        public void SetAsBoolean(Boolean bVal)
        {
            valueType = MsgPackType.Boolean;
            innerValue = bVal;
        }

        public void SetAsSingle(Single fVal)
        {
            valueType = MsgPackType.Single;
            innerValue = fVal;
        }

        public void SetAsFloat(Double fVal)
        {
            valueType = MsgPackType.Float;
            innerValue = fVal;
        }



        public void DecodeFromBytes(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            ms.Position = 0;
            DecodeFromStream(ms);
        }

        public void DecodeFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            DecodeFromStream(fs);
            fs.Dispose();
        }



        public void DecodeFromStream(Stream ms)
        {
            byte lvByte = (byte)ms.ReadByte();
            byte[] rawByte = null;
            MsgPack msgPack = null;
            int len = 0;
            int i = 0;

            if (lvByte <= 0x7F)
            {   //positive fixint	0xxxxxxx	0x00 - 0x7f
                SetAsInteger(lvByte);
            }
            else if ((lvByte >= 0x80) && (lvByte <= 0x8F))
            {
                //fixmap	1000xxxx	0x80 - 0x8f
                Clear();
                valueType = MsgPackType.Map;
                len = lvByte - 0x80;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if ((lvByte >= 0x90) && (lvByte <= 0x9F))  //fixarray	1001xxxx	0x90 - 0x9f
            {
                //fixmap	1000xxxx	0x80 - 0x8f
                Clear();
                valueType = MsgPackType.Array;
                len = lvByte - 0x90;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if ((lvByte >= 0xA0) && (lvByte <= 0xBF))  // fixstr	101xxxxx	0xa0 - 0xbf
            {
                len = lvByte - 0xA0;
                SetAsString(ReadTools.ReadString(ms, len));
            }
            else if ((lvByte >= 0xE0) && (lvByte <= 0xFF))
            {   /// -1..-32
                //  negative fixnum stores 5-bit negative integer
                //  +--------+
                //  |111YYYYY|
                //  +--------+                
                SetAsInteger((sbyte)lvByte);
            }
            else if (lvByte == 0xC0)
            {
                SetAsNull();
            }
            else if (lvByte == 0xC1)
            {
                throw new Exception("(never used) type $c1");
            }
            else if (lvByte == 0xC2)
            {
                SetAsBoolean(false);
            }
            else if (lvByte == 0xC3)
            {
                SetAsBoolean(true);
            }
            else if (lvByte == 0xC4)
            {  // max 255
                len = ms.ReadByte();
                rawByte = new byte[len];
                ms.Read(rawByte, 0, len);
                SetAsBytes(rawByte);
            }
            else if (lvByte == 0xC5)
            {  // max 65535                
                rawByte = new byte[2];
                ms.Read(rawByte, 0, 2);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToUInt16(rawByte, 0);

                // read binary
                rawByte = new byte[len];
                ms.Read(rawByte, 0, len);
                SetAsBytes(rawByte);
            }
            else if (lvByte == 0xC6)
            {  // binary max: 2^32-1                
                rawByte = new byte[4];
                ms.Read(rawByte, 0, 4);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToInt32(rawByte, 0);

                // read binary
                rawByte = new byte[len];
                ms.Read(rawByte, 0, len);
                SetAsBytes(rawByte);
            }
            else if ((lvByte == 0xC7) || (lvByte == 0xC8) || (lvByte == 0xC9))
            {
                throw new Exception("(ext8,ext16,ex32) type $c7,$c8,$c9");
            }
            else if (lvByte == 0xCA)
            {  // float 32              
                rawByte = new byte[4];
                ms.Read(rawByte, 0, 4);
                rawByte = BytesTools.SwapBytes(rawByte);

                SetAsSingle(BitConverter.ToSingle(rawByte, 0));
            }
            else if (lvByte == 0xCB)
            {  // float 64              
                rawByte = new byte[8];
                ms.Read(rawByte, 0, 8);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsFloat(BitConverter.ToDouble(rawByte, 0));
            }
            else if (lvByte == 0xCC)
            {  // uint8   
                //      uint 8 stores a 8-bit unsigned integer
                //      +--------+--------+
                //      |  0xcc  |ZZZZZZZZ|
                //      +--------+--------+
                lvByte = (byte)ms.ReadByte();
                SetAsInteger(lvByte);
            }
            else if (lvByte == 0xCD)
            {  // uint16      
                //    uint 16 stores a 16-bit big-endian unsigned integer
                //    +--------+--------+--------+
                //    |  0xcd  |ZZZZZZZZ|ZZZZZZZZ|
                //    +--------+--------+--------+
                rawByte = new byte[2];
                ms.Read(rawByte, 0, 2);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsInteger(BitConverter.ToUInt16(rawByte, 0));
            }
            else if (lvByte == 0xCE)
            {
                //  uint 32 stores a 32-bit big-endian unsigned integer
                //  +--------+--------+--------+--------+--------+
                //  |  0xce  |ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ
                //  +--------+--------+--------+--------+--------+
                rawByte = new byte[4];
                ms.Read(rawByte, 0, 4);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsInteger(BitConverter.ToUInt32(rawByte, 0));
            }
            else if (lvByte == 0xCF)
            {
                //  uint 64 stores a 64-bit big-endian unsigned integer
                //  +--------+--------+--------+--------+--------+--------+--------+--------+--------+
                //  |  0xcf  |ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|
                //  +--------+--------+--------+--------+--------+--------+--------+--------+--------+
                rawByte = new byte[8];
                ms.Read(rawByte, 0, 8);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsUInt64(BitConverter.ToUInt64(rawByte, 0));
            }
            else if (lvByte == 0xDC)
            {
                //      +--------+--------+--------+~~~~~~~~~~~~~~~~~+
                //      |  0xdc  |YYYYYYYY|YYYYYYYY|    N objects    |
                //      +--------+--------+--------+~~~~~~~~~~~~~~~~~+
                rawByte = new byte[2];
                ms.Read(rawByte, 0, 2);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToUInt16(rawByte, 0);

                Clear();
                valueType = MsgPackType.Array;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if (lvByte == 0xDD)
            {
                //  +--------+--------+--------+--------+--------+~~~~~~~~~~~~~~~~~+
                //  |  0xdd  |ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|    N objects    |
                //  +--------+--------+--------+--------+--------+~~~~~~~~~~~~~~~~~+
                rawByte = new byte[4];
                ms.Read(rawByte, 0, 4);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToUInt16(rawByte, 0);

                Clear();
                valueType = MsgPackType.Array;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if (lvByte == 0xD9)
            {
                //  str 8 stores a byte array whose length is upto (2^8)-1 bytes:
                //  +--------+--------+========+
                //  |  0xd9  |YYYYYYYY|  data  |
                //  +--------+--------+========+
                SetAsString(ReadTools.ReadString(lvByte, ms));
            }
            else if (lvByte == 0xDE)
            {
                //    +--------+--------+--------+~~~~~~~~~~~~~~~~~+
                //    |  0xde  |YYYYYYYY|YYYYYYYY|   N*2 objects   |
                //    +--------+--------+--------+~~~~~~~~~~~~~~~~~+
                rawByte = new byte[2];
                ms.Read(rawByte, 0, 2);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToUInt16(rawByte, 0);

                Clear();
                valueType = MsgPackType.Map;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if (lvByte == 0xDE)
            {
                //    +--------+--------+--------+~~~~~~~~~~~~~~~~~+
                //    |  0xde  |YYYYYYYY|YYYYYYYY|   N*2 objects   |
                //    +--------+--------+--------+~~~~~~~~~~~~~~~~~+
                rawByte = new byte[2];
                ms.Read(rawByte, 0, 2);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToUInt16(rawByte, 0);

                Clear();
                valueType = MsgPackType.Map;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if (lvByte == 0xDF)
            {
                //    +--------+--------+--------+--------+--------+~~~~~~~~~~~~~~~~~+
                //    |  0xdf  |ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|   N*2 objects   |
                //    +--------+--------+--------+--------+--------+~~~~~~~~~~~~~~~~~+
                rawByte = new byte[4];
                ms.Read(rawByte, 0, 4);
                rawByte = BytesTools.SwapBytes(rawByte);
                len = BitConverter.ToInt32(rawByte, 0);

                Clear();
                valueType = MsgPackType.Map;
                for (i = 0; i < len; i++)
                {
                    msgPack = InnerAdd();
                    msgPack.SetName(ReadTools.ReadString(ms));
                    msgPack.DecodeFromStream(ms);
                }
            }
            else if (lvByte == 0xDA)
            {
                //      str 16 stores a byte array whose length is upto (2^16)-1 bytes:
                //      +--------+--------+--------+========+
                //      |  0xda  |ZZZZZZZZ|ZZZZZZZZ|  data  |
                //      +--------+--------+--------+========+
                SetAsString(ReadTools.ReadString(lvByte, ms));
            }
            else if (lvByte == 0xDB)
            {
                //  str 32 stores a byte array whose length is upto (2^32)-1 bytes:
                //  +--------+--------+--------+--------+--------+========+
                //  |  0xdb  |AAAAAAAA|AAAAAAAA|AAAAAAAA|AAAAAAAA|  data  |
                //  +--------+--------+--------+--------+--------+========+
                SetAsString(ReadTools.ReadString(lvByte, ms));
            }
            else if (lvByte == 0xD0)
            {
                //      int 8 stores a 8-bit signed integer
                //      +--------+--------+
                //      |  0xd0  |ZZZZZZZZ|
                //      +--------+--------+
                SetAsInteger((sbyte)ms.ReadByte());
            }
            else if (lvByte == 0xD1)
            {
                //    int 16 stores a 16-bit big-endian signed integer
                //    +--------+--------+--------+
                //    |  0xd1  |ZZZZZZZZ|ZZZZZZZZ|
                //    +--------+--------+--------+
                rawByte = new byte[2];
                ms.Read(rawByte, 0, 2);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsInteger(BitConverter.ToInt16(rawByte, 0));
            }
            else if (lvByte == 0xD2)
            {
                //  int 32 stores a 32-bit big-endian signed integer
                //  +--------+--------+--------+--------+--------+
                //  |  0xd2  |ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|
                //  +--------+--------+--------+--------+--------+
                rawByte = new byte[4];
                ms.Read(rawByte, 0, 4);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsInteger(BitConverter.ToInt32(rawByte, 0));
            }
            else if (lvByte == 0xD3)
            {
                //  int 64 stores a 64-bit big-endian signed integer
                //  +--------+--------+--------+--------+--------+--------+--------+--------+--------+
                //  |  0xd3  |ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|ZZZZZZZZ|
                //  +--------+--------+--------+--------+--------+--------+--------+--------+--------+
                rawByte = new byte[8];
                ms.Read(rawByte, 0, 8);
                rawByte = BytesTools.SwapBytes(rawByte);
                SetAsInteger(BitConverter.ToInt64(rawByte, 0));
            }
        }

        public byte[] Encode2Bytes()
        {
            MemoryStream ms = new MemoryStream();
            Encode2Stream(ms);
            byte[] r = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(r, 0, (int)ms.Length);
            return r;
        }

        public void Encode2Stream(Stream ms)
        {
            switch (valueType)
            {
                case MsgPackType.Unknown:
                case MsgPackType.Null:
                    WriteTools.WriteNull(ms);
                    break;
                case MsgPackType.String:
                    WriteTools.WriteString(ms, (String)innerValue);
                    break;
                case MsgPackType.Integer:
                    WriteTools.WriteInteger(ms, (Int64)innerValue);
                    break;
                case MsgPackType.UInt64:
                    WriteTools.WriteUInt64(ms, (UInt64)innerValue);
                    break;
                case MsgPackType.Boolean:
                    WriteTools.WriteBoolean(ms, (Boolean)innerValue);
                    break;
                case MsgPackType.Float:
                    WriteTools.WriteFloat(ms, (Double)innerValue);
                    break;
                case MsgPackType.Single:
                    WriteTools.WriteFloat(ms, (Single)innerValue);
                    break;
                case MsgPackType.DateTime:
                    WriteTools.WriteInteger(ms, GetAsInteger());
                    break;
                case MsgPackType.Binary:
                    WriteTools.WriteBinary(ms, (byte[])innerValue);
                    break;
                case MsgPackType.Map:
                    WriteMap(ms);
                    break;
                case MsgPackType.Array:
                    WirteArray(ms);
                    break;
                default:
                    WriteTools.WriteNull(ms);
                    break;
            }
        }

        public String AsString
        {
            get => GetAsString();
            set => SetAsString(value);
        }

        public Int64 AsInteger
        {
            get => GetAsInteger();
            set => SetAsInteger(value);
        }

        public Double AsFloat
        {
            get => GetAsFloat();
            set => SetAsFloat(value);
        }
        public MsgPackArray AsArray
        {
            get
            {
                lock (this)
                {
                    if (refAsArray == null)
                    {
                        refAsArray = new MsgPackArray(this, children);
                    }
                }
                return refAsArray;
            }
        }


        public MsgPackType ValueType => valueType;


        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MsgPackEnum(children);
        }
    }
}