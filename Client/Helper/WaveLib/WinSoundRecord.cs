using System;
using System.Runtime.InteropServices;
using System.Threading;
using static WaveLib.Win32;

namespace WaveLib
{
    public unsafe class WinSoundRecord
    {
        private IntPtr hWaveIn;
        private string WaveInDeviceName = "";
        private int SamplesPerSecond = 8000;
        private int BitsPerSample = 16;
        private int Channels = 1;
        private int BufferCount = 8;
        private int BufferSize = 1024;
        private WAVEHDR*[] WaveInHeaders;
        private WAVEHDR* CurrentRecordedHeader;
        private DelegateWaveInProc delegateWaveInProc;
        private Thread ThreadRecording;
        private AutoResetEvent AutoResetEventDataRecorded = new AutoResetEvent(false);

        public delegate void DelegateDataRecorded(byte[] bytes);

        public event DelegateDataRecorded DataRecorded;

        public WinSoundRecord()
        {
            delegateWaveInProc = waveInProc;
        }

        /// <summary>
        /// StartWaveIn
        /// </summary>
        /// <returns></returns>
        private bool OpenWaveIn()
        {
            var fmt = new WaveFormat(44100, 16, 1);

            var hr = waveInOpen(ref hWaveIn, -1, fmt, delegateWaveInProc, 0, (int) WaveProcFlags.CALLBACK_FUNCTION);

            if (hWaveIn == IntPtr.Zero)
                return false;

            GCHandle.Alloc(hWaveIn, GCHandleType.Pinned);

            return true;
        }

        public bool Open(string deviceName, int samplesPerSecond, int bitsPerSample, int channels, int bufferSize,
            int bufferCount)
        {
            WaveInDeviceName = deviceName;
            SamplesPerSecond = samplesPerSecond;
            BitsPerSample = bitsPerSample;
            Channels = channels;
            BufferSize = bufferSize;
            BufferCount = bufferCount;

            if (OpenWaveIn())
                if (CreateWaveInHeaders())
                {
                    var hr = waveInStart(hWaveIn);
                    if (hr == MMRESULT.MMSYSERR_NOERROR)
                    {
                        StartThreadRecording();
                        return true;
                    }

                    return false;
                }

            return false;
        }

        /// <summary>
        /// StartThreadRecording
        /// </summary>
        private void StartThreadRecording()
        {
            ThreadRecording = new Thread(OnThreadRecording)
            {
                Name = "Recording",
                Priority = ThreadPriority.Highest
            };
            ThreadRecording.Start();
        }

        /// <summary>
        /// OnThreadRecording
        /// </summary>
        private void OnThreadRecording()
        {
            while (true)
            {
                AutoResetEventDataRecorded.WaitOne();


                if (CurrentRecordedHeader->dwBytesRecorded > 0)
                {
                    var bytes = new byte[CurrentRecordedHeader->dwBytesRecorded];
                    Marshal.Copy(CurrentRecordedHeader->lpData, bytes, 0, (int) CurrentRecordedHeader->dwBytesRecorded);

                    DataRecorded?.Invoke(bytes);

                    for (var i = 0; i < WaveInHeaders.Length; i++)
                        if ((WaveInHeaders[i]->dwFlags & WaveHdrFlags.WHDR_INQUEUE) == 0)
                        {
                            var hr = waveInAddBuffer(hWaveIn, WaveInHeaders[i], sizeof(WAVEHDR));
                        }
                }
            }
        }

        /// <summary>
        /// CreateWaveInHeaders
        /// </summary>
        /// <param name="count"></param>
        /// <param name="bufferSize"></param>
        /// <returns></returns>
        private bool CreateWaveInHeaders()
        {
            WaveInHeaders = new WAVEHDR*[BufferCount];
            var createdHeaders = 0;

            for (var i = 0; i < BufferCount; i++)
            {
                WaveInHeaders[i] = (WAVEHDR*) Marshal.AllocHGlobal(sizeof(WAVEHDR));

                WaveInHeaders[i]->dwLoops = 0;
                WaveInHeaders[i]->dwUser = IntPtr.Zero;
                WaveInHeaders[i]->lpNext = IntPtr.Zero;
                WaveInHeaders[i]->reserved = IntPtr.Zero;
                WaveInHeaders[i]->lpData = Marshal.AllocHGlobal(BufferSize);
                WaveInHeaders[i]->dwBufferLength = (uint) BufferSize;
                WaveInHeaders[i]->dwBytesRecorded = 0;
                WaveInHeaders[i]->dwFlags = 0;

                var hr = waveInPrepareHeader(hWaveIn, WaveInHeaders[i], sizeof(WAVEHDR));
                if (hr == MMRESULT.MMSYSERR_NOERROR)
                {
                    if (i == 0) hr = waveInAddBuffer(hWaveIn, WaveInHeaders[i], sizeof(WAVEHDR));
                    createdHeaders++;
                }
            }

            return createdHeaders == BufferCount;
        }

        public void Stop()
        {
            var hr = waveInStop(hWaveIn);

            var resetCount = 0;
            while (IsAnyWaveInHeaderInState(WaveHdrFlags.WHDR_INQUEUE) & (resetCount < 20))
            {
                hr = waveInReset(hWaveIn);
                Thread.Sleep(50);
                resetCount++;
            }

            FreeWaveInHeaders();
            hr = waveInClose(hWaveIn);

            AutoResetEventDataRecorded.Set();
        }

        /// <summary>
        /// IsAnyWaveInHeaderInState
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private bool IsAnyWaveInHeaderInState(WaveHdrFlags state)
        {
            for (var i = 0; i < WaveInHeaders.Length; i++)
                if ((WaveInHeaders[i]->dwFlags & state) == state)
                    return true;
            return false;
        }

        /// <summary>
        /// FreeWaveInHeaders
        /// </summary>
        private void FreeWaveInHeaders()
        {
            if (WaveInHeaders != null)
                for (var i = 0; i < WaveInHeaders.Length; i++)
                {
                    var hr = waveInUnprepareHeader(hWaveIn, WaveInHeaders[i], sizeof(WAVEHDR));

                    var count = 0;
                    while (count <= 100 && (WaveInHeaders[i]->dwFlags & WaveHdrFlags.WHDR_INQUEUE) ==
                           WaveHdrFlags.WHDR_INQUEUE)
                    {
                        Thread.Sleep(20);
                        count++;
                    }

                    if ((WaveInHeaders[i]->dwFlags & WaveHdrFlags.WHDR_INQUEUE) != WaveHdrFlags.WHDR_INQUEUE)
                        if (WaveInHeaders[i]->lpData != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(WaveInHeaders[i]->lpData);
                            WaveInHeaders[i]->lpData = IntPtr.Zero;
                        }
                }
        }

        /// <summary>
        /// waveInProc
        /// </summary>
        /// <param name="hWaveIn"></param>
        /// <param name="msg"></param>
        /// <param name="dwInstance"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        private void waveInProc(IntPtr hWaveIn, WIM_Messages msg, IntPtr dwInstance, WAVEHDR* pWaveHdr, IntPtr lParam)
        {
            switch (msg)
            {
                case WIM_Messages.OPEN:
                    break;
                case WIM_Messages.DATA:
                    CurrentRecordedHeader = pWaveHdr;
                    AutoResetEventDataRecorded.Set();
                    break;
                case WIM_Messages.CLOSE:
                    AutoResetEventDataRecorded.Set();
                    this.hWaveIn = IntPtr.Zero;
                    break;
            }
        }
    }
}