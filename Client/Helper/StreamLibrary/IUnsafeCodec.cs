using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Client.StreamLibrary.src;

namespace Client.StreamLibrary
{
    public abstract class IUnsafeCodec
    {
        protected JpgCompression jpgCompression;
        protected LzwCompression lzwCompression;
        public abstract ulong CachedSize { get; internal set; }
        protected object ImageProcessLock { get; private set; }

        private int _imageQuality;

        public int ImageQuality
        {
            get => _imageQuality;
            set
            {
                _imageQuality = value;
                jpgCompression = new JpgCompression(value);
                lzwCompression = new LzwCompression(value);
            }
        }


        public abstract event IVideoCodec.VideoDebugScanningDelegate onCodeDebugScan;
        public abstract event IVideoCodec.VideoDebugScanningDelegate onDecodeDebugScan;

        public IUnsafeCodec(int ImageQuality = 100)
        {
            this.ImageQuality = ImageQuality;
            ImageProcessLock = new object();
        }

        public abstract int BufferCount { get; }
        public abstract CodecOption CodecOptions { get; }

        public abstract void CodeImage(IntPtr Scan0, Rectangle ScanArea, Size ImageSize, PixelFormat Format,
            Stream outStream);

        public abstract Bitmap DecodeData(Stream inStream);
        public abstract Bitmap DecodeData(IntPtr CodecBuffer, uint Length);
    }
}