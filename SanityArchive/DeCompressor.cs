using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace SanityArchive
{
    class DeCompressor
    {
        public static void Compress(string input)
        {
            FileInfo fileToCompress = new FileInfo(input);
            FileStream originalFileStream = fileToCompress.OpenRead();
            using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                    CompressionMode.Compress))
                {
                    originalFileStream.CopyTo(compressionStream);

                }
            }
            FileInfo info = new FileInfo(input + ".gz");
            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
            fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
            
            originalFileStream.Close();
            fileToCompress.Delete();
        }

        public static void Decompress(string input)
        {
            FileInfo fileToDecompress = new FileInfo(input);
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
            fileToDecompress.Delete();
        }
    }
}
