using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace WaveLib
{
    public class WinSound
    {
        public static List<string> GetWaveInDeviceNames()
        {
            var num = Win32.waveInGetNumDevs();

            var names = new List<string>();
            var caps = new Win32.WAVEINCAPS();
            for (var i = 0; i < num; i++)
            {
                var hr = (Win32.HRESULT) Win32.waveInGetDevCaps(i, ref caps, Marshal.SizeOf(typeof(Win32.WAVEINCAPS)));
                if (hr == Win32.HRESULT.S_OK) names.Add(caps.szPname);
            }

            return names;
        }
    }
}