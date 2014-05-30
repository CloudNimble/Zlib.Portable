using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using Ionic.Zlib;

namespace ZlibTest
{
    public class GzipTrailerValidation
    {
        [Test]
        public void SystemGzipStreamWithBadTrailer_DoesNotThrowWhenNotReadToEnd()
        {
            Verify_StreamWithBadTrailer_DoesNotThrow_WhenNotReadToEnd(ms => new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress));
        }

        [Test]
        public void IonicGzipStreamWithBadTrailer_DoesNotThrowWhenNotReadToEnd()
        {
            Verify_StreamWithBadTrailer_DoesNotThrow_WhenNotReadToEnd(ms => new Ionic.Zlib.GZipStream(ms, Ionic.Zlib.CompressionMode.Decompress));
        }


        void Verify_StreamWithBadTrailer_DoesNotThrow_WhenNotReadToEnd(Func<Stream, Stream> buildGzip)
        {
            byte[] data = BuildTestData();

            TamperWithCrcTrailer(data);

            using (var ms = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(buildGzip(ms)))
                {
                    Assert.AreEqual(123, reader.ReadInt32());
                    Assert.DoesNotThrow(() => reader.Dispose());
                }
            }
        }
        [Test]
        public void SystemGzipStreamWithBadTrailer_DoesNotThrowWhenReadToEnd()
        {
            Verify_StreamWithBadTrailer_DoesNotThrow_WhenReadToEnd(ms => new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress));
        }

        [Test]
        public void IonicGzipStreamWithBadTrailer_DoesNotThrowWhenReadToEnd()
        {
            Verify_StreamWithBadTrailer_DoesNotThrow_WhenReadToEnd(ms => new Ionic.Zlib.GZipStream(ms, Ionic.Zlib.CompressionMode.Decompress));
        }

        
        void Verify_StreamWithBadTrailer_DoesNotThrow_WhenReadToEnd(Func<Stream, Stream> buildGzip)
        {
            byte[] data = BuildTestData();

            TamperWithCrcTrailer(data);

            using (var ms = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(buildGzip(ms)))
                {
                    Assert.AreEqual(123, reader.ReadInt32());
                    reader.ReadString();
                    Assert.DoesNotThrow(() => reader.Dispose());
                }
            }
        }

        static byte[] BuildTestData()
        {
            var data = default(byte[]);
            using (var ms = new MemoryStream())
            {
                using (var writer = new BinaryWriter(new Ionic.Zlib.GZipStream(ms, Ionic.Zlib.CompressionMode.Compress)))
                {
                    writer.Write(123);
                    writer.Write("Some string we're never gonna read");
                }

                data = ms.ToArray();
            }
            return data;
        }

        static void TamperWithCrcTrailer(byte[] data)
        {
            int trailerCrcIndex = data.Length - 8;
            data[trailerCrcIndex] ^= 1; // flip a bit in the crc
        }
    }
}
