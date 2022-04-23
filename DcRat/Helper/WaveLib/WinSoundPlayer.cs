using System;
using System.Runtime.InteropServices;
using System.Threading;
using static WaveLib.Win32;

namespace WaveLib
{
    public unsafe class WinSoundPlayer
    {
        private string WaveOutDeviceName;
        private int SamplesPerSecond = 8000;
        private int BitsPerSample = 16;
        private int Channels = 1;
        private int BufferSize = 1024;
        private int BufferCount = 8;


        private IntPtr hWaveOut;
        private WAVEHDR*[] WaveOutHeaders;
        private AutoResetEvent AutoResetEventDataPlayed = new AutoResetEvent(false);
        private DelegateWaveOutProc delegateWaveOutProc;


        public WinSoundPlayer()
        {
            delegateWaveOutProc = waveOutProc;
        }

        public bool Open(string deviceName, int samplesPerSecond, int bitsPerSample, int channels, int bufferSize, int bufferCount)
        {
            WaveOutDeviceName = deviceName;
            SamplesPerSecond = samplesPerSecond;
            BitsPerSample = bitsPerSample;
            Channels = channels;
            BufferSize = bufferSize;
            BufferCount = bufferCount;

            if (OpenWaveOut())
            {
                if (CreateWaveOutHeaders())
                    return true;
            }

            return false;
        }

        private bool OpenWaveOut()
        {
            WaveFormat fmt = new WaveFormat(44100, 16, 1);

            int deviceId = WinSound.GetWaveOutDeviceIdByName(WaveOutDeviceName);

            MMRESULT hr = waveOutOpen(ref hWaveOut, -1, fmt, delegateWaveOutProc, 0, (int)WaveProcFlags.CALLBACK_FUNCTION);

            if (hr != MMRESULT.MMSYSERR_NOERROR)
                return false;

            GCHandle.Alloc(hWaveOut, GCHandleType.Pinned);

            return true;
        }


        /// <summary>
        /// CreateWaveOutHeaders
        /// </summary>
        /// <returns></returns>
        private bool CreateWaveOutHeaders()
        {
            WaveOutHeaders = new WAVEHDR*[BufferCount];
            int createdHeaders = 0;

            for (int i = 0; i < BufferCount; i++)
            {
                WaveOutHeaders[i] = (WAVEHDR*)Marshal.AllocHGlobal(sizeof(WAVEHDR));

                WaveOutHeaders[i]->dwLoops = 0;
                WaveOutHeaders[i]->dwUser = IntPtr.Zero;
                WaveOutHeaders[i]->lpNext = IntPtr.Zero;
                WaveOutHeaders[i]->reserved = IntPtr.Zero;
                WaveOutHeaders[i]->lpData = Marshal.AllocHGlobal(BufferSize);
                WaveOutHeaders[i]->dwBufferLength = (uint)BufferSize;
                WaveOutHeaders[i]->dwBytesRecorded = 0;
                WaveOutHeaders[i]->dwFlags = 0;

                MMRESULT hr = waveOutPrepareHeader(hWaveOut, WaveOutHeaders[i], sizeof(WAVEHDR));
                if (hr == MMRESULT.MMSYSERR_NOERROR)
                {
                    createdHeaders++;
                }
            }

            return (createdHeaders == BufferCount);
        }

        public bool PlayData(byte[] data)
        {
            int index = GetNextFreeWaveOutHeaderIndex();
            if (index != -1)
            {
                if (WaveOutHeaders[index]->dwBufferLength != data.Length)
                {
                    Marshal.FreeHGlobal(WaveOutHeaders[index]->lpData);
                    WaveOutHeaders[index]->lpData = Marshal.AllocHGlobal(data.Length);
                    WaveOutHeaders[index]->dwBufferLength = (uint)data.Length;
                }

                WaveOutHeaders[index]->dwBufferLength = (uint)data.Length;
                WaveOutHeaders[index]->dwUser = (IntPtr)index;
                Marshal.Copy(data, 0, WaveOutHeaders[index]->lpData, data.Length);

                MMRESULT hr = waveOutWrite(hWaveOut, WaveOutHeaders[index], sizeof(WAVEHDR));
                if (hr == MMRESULT.MMSYSERR_NOERROR)
                    return true;
                return false;
            }

            return false;
        }

        /// <summary>
        /// GetNextFreeWaveOutHeaderIndex
        /// </summary>
        /// <returns></returns>
        private int GetNextFreeWaveOutHeaderIndex()
        {
            for (int i = 0; i < WaveOutHeaders.Length; i++)
            {
                if (IsHeaderPrepared(*WaveOutHeaders[i]) && !IsHeaderInqueue(*WaveOutHeaders[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// IsHeaderPrepared
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        private bool IsHeaderPrepared(WAVEHDR header)
        {
            return (header.dwFlags & WaveHdrFlags.WHDR_PREPARED) > 0;
        }

        /// <summary>
        /// IsHeaderInqueue
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        private bool IsHeaderInqueue(WAVEHDR header)
        {
            return (header.dwFlags & WaveHdrFlags.WHDR_INQUEUE) > 0;
        }

        /// <summary>
        /// waveOutProc
        /// </summary>
        /// <param name="hWaveOut"></param>
        /// <param name="msg"></param>
        /// <param name="dwInstance"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        private void waveOutProc(IntPtr hWaveOut, WOM_Messages msg, IntPtr dwInstance, WAVEHDR* pWaveHeader, IntPtr lParam)
        {
            switch (msg)
            {
                case WOM_Messages.OPEN:
                    break;
                case WOM_Messages.DONE:
                    break;
                case WOM_Messages.CLOSE:
                    this.hWaveOut = IntPtr.Zero;
                    break;
            }
        }

        public bool Close()
        {
            int count = 0;
            while (waveOutReset(hWaveOut) != MMRESULT.MMSYSERR_NOERROR && count <= 100)
            {
                Thread.Sleep(50);
                count++;
            }

            FreeWaveOutHeaders();

            count = 0;
            while (waveOutClose(hWaveOut) != MMRESULT.MMSYSERR_NOERROR && count <= 100)
            {
                Thread.Sleep(50);
                count++;
            }

            return true;
        }

        private void FreeWaveOutHeaders()
        {
            for (int i = 0; i < WaveOutHeaders.Length; i++)
            {
                MMRESULT hr = waveOutUnprepareHeader(hWaveOut, WaveOutHeaders[i], sizeof(WAVEHDR));

                int count = 0;
                while (count <= 100 && (WaveOutHeaders[i]->dwFlags & WaveHdrFlags.WHDR_INQUEUE) == WaveHdrFlags.WHDR_INQUEUE)
                {
                    Thread.Sleep(20);
                    count++;
                }

                if ((WaveOutHeaders[i]->dwFlags & WaveHdrFlags.WHDR_INQUEUE) != WaveHdrFlags.WHDR_INQUEUE)
                {
                    if (WaveOutHeaders[i]->lpData != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(WaveOutHeaders[i]->lpData);
                        WaveOutHeaders[i]->lpData = IntPtr.Zero;
                    }
                }
            }

        }
    }
}
