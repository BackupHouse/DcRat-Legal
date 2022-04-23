using System;
using System.Runtime.InteropServices;

namespace WaveLib
{
    /// <summary>
    /// Win32
    /// </summary>
    public static unsafe class Win32
    {
        //Konstanten
        public const int WAVE_MAPPER = -1;

        public const int WT_EXECUTEDEFAULT = 0x00000000;
        public const int WT_EXECUTEINIOTHREAD = 0x00000001;
        public const int WT_EXECUTEINTIMERTHREAD = 0x00000020;
        public const int WT_EXECUTEINPERSISTENTTHREAD = 0x00000080;

        public const int TIME_ONESHOT = 0;
        public const int TIME_PERIODIC = 1;

        /// <summary>
        /// WAVEOUTCAPS
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
        public struct WAVEOUTCAPS
        {
            public short wMid;
            public short wPid;
            public int vDriverVersion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPname;

            public uint dwFormats;
            public short wChannels;
            public short wReserved;
            public int dwSupport;
        }

        /// <summary>
        /// WAVEINCAPS
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
        public struct WAVEINCAPS
        {
            public short wMid;
            public short wPid;
            public int vDriverVersion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string szPname;

            public uint dwFormats;
            public short wChannels;
            public short wReserved;
            public int dwSupport;
        }

        public enum WaveFormats
        {
            Pcm = 1,
            Float = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        public class WaveFormat
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            public short cbSize;

            public WaveFormat(int rate, int bits, int channels)
            {
                wFormatTag = (short) WaveFormats.Pcm;
                nChannels = (short) channels;
                nSamplesPerSec = rate;
                wBitsPerSample = (short) bits;
                cbSize = 0;

                nBlockAlign = (short) (channels * (bits / 8));
                nAvgBytesPerSec = nSamplesPerSec * nBlockAlign;
            }
        }

        /// <summary>
        /// MMRESULT
        /// </summary>
        public enum MMRESULT : uint
        {
            MMSYSERR_NOERROR = 0,
            MMSYSERR_ERROR = 1,
            MMSYSERR_BADDEVICEID = 2,
            MMSYSERR_NOTENABLED = 3,
            MMSYSERR_ALLOCATED = 4,
            MMSYSERR_INVALHANDLE = 5,
            MMSYSERR_NODRIVER = 6,
            MMSYSERR_NOMEM = 7,
            MMSYSERR_NOTSUPPORTED = 8,
            MMSYSERR_BADERRNUM = 9,
            MMSYSERR_INVALFLAG = 10,
            MMSYSERR_INVALPARAM = 11,
            MMSYSERR_HANDLEBUSY = 12,
            MMSYSERR_INVALIDALIAS = 13,
            MMSYSERR_BADDB = 14,
            MMSYSERR_KEYNOTFOUND = 15,
            MMSYSERR_READERROR = 16,
            MMSYSERR_WRITEERROR = 17,
            MMSYSERR_DELETEERROR = 18,
            MMSYSERR_VALNOTFOUND = 19,
            MMSYSERR_NODRIVERCB = 20,
            WAVERR_BADFORMAT = 32,
            WAVERR_STILLPLAYING = 33,
            WAVERR_UNPREPARED = 34
        }

        [Flags]
        public enum WaveHdrFlags : uint
        {
            WHDR_DONE = 1,
            WHDR_PREPARED = 2,
            WHDR_BEGINLOOP = 4,
            WHDR_ENDLOOP = 8,
            WHDR_INQUEUE = 16
        }

        [Flags]
        public enum WaveProcFlags
        {
            CALLBACK_NULL = 0,
            CALLBACK_FUNCTION = 0x30000,
            CALLBACK_EVENT = 0x50000,
            CALLBACK_WINDOW = 0x10000,
            CALLBACK_THREAD = 0x20000,
            WAVE_FORMAT_QUERY = 1,
            WAVE_MAPPED = 4,
            WAVE_FORMAT_DIRECT = 8
        }

        [Flags]
        public enum HRESULT : long
        {
            S_OK = 0L,
            S_FALSE = 1L
        }

        /// <summary>
        /// WAVEHDR
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct WAVEHDR
        {
            public IntPtr lpData; // pointer to locked data buffer
            public uint dwBufferLength; // length of data buffer
            public uint dwBytesRecorded; // used for input only
            public IntPtr dwUser; // for client's use
            public WaveHdrFlags dwFlags; // assorted flags (see defines)
            public uint dwLoops; // loop control counter
            public IntPtr lpNext; // PWaveHdr reserved for driver
            public IntPtr reserved; // reserved for driver
        }

        /// <summary>
        /// WIM_Messages
        /// </summary>
        public enum WIM_Messages
        {
            OPEN = 0x03BE,
            CLOSE = 0x03BF,
            DATA = 0x03C0
        }

        public delegate void DelegateWaveInProc(IntPtr hWaveIn, WIM_Messages msg, IntPtr dwInstance, WAVEHDR* pWaveHdr,
            IntPtr lParam);

        [DllImport("winmm.dll")]
        public static extern MMRESULT waveInOpen(ref IntPtr hWaveIn, int deviceId, WaveFormat wfx,
            DelegateWaveInProc dwCallBack, int dwInstance, int dwFlags);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT waveInStart(IntPtr hWaveIn);

        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint waveInGetDevCaps(int index, ref WAVEINCAPS pwic, int cbwic);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern uint waveInGetNumDevs();

        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint waveOutGetDevCaps(int index, ref WAVEOUTCAPS pwoc, int cbwoc);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern uint waveOutGetNumDevs();

        [DllImport("winmm.dll", EntryPoint = "waveInStop", SetLastError = true)]
        public static extern MMRESULT waveInStop(IntPtr hWaveIn);

        [DllImport("winmm.dll", EntryPoint = "waveInReset", SetLastError = true)]
        public static extern MMRESULT waveInReset(IntPtr hWaveIn);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT waveInPrepareHeader(IntPtr hWaveIn, WAVEHDR* pwh, int cbwh);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT waveInUnprepareHeader(IntPtr hWaveIn, WAVEHDR* pwh, int cbwh);

        [DllImport("winmm.dll", EntryPoint = "waveInAddBuffer", SetLastError = true)]
        public static extern MMRESULT waveInAddBuffer(IntPtr hWaveIn, WAVEHDR* pwh, int cbwh);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT waveInClose(IntPtr hWaveIn);
    }
}