using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace ZlibTest
{
    public class Regressions
    {
        [Test]
        public void GzipStreamDoesNotThrowWhenNotReadToEnd()
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

            using (var ms = new MemoryStream(data))
            {
                using (var reader = new BinaryReader(new Ionic.Zlib.GZipStream(ms, Ionic.Zlib.CompressionMode.Decompress)))
                {
                    Assert.AreEqual(123, reader.ReadInt32());
                    Assert.DoesNotThrow(() => reader.Dispose());
                }
            }
        }
    }
}
