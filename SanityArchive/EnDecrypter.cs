using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace SanityArchive
{
    class EnDecrypter
    {
        static string key = "ütvefúró";

        public static void encrypt(string input)
        {            
                string strHash = key;
                FileStream inStream, outStream;
                CryptoStream CryStream;
                TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteTexto;
                string output = input + ".cry";
                inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
                outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

                byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
                byteTexto = File.ReadAllBytes(input);

                md5.Clear();

                TDC.Key = byteHash;
                TDC.Mode = CipherMode.ECB;

                CryStream = new CryptoStream(outStream, TDC.CreateEncryptor(), CryptoStreamMode.Write);

                int bytesRead;
                long length, position = 0;
                length = inStream.Length;

                while (position < length)
                {
                    bytesRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                    position += bytesRead;

                    CryStream.Write(byteTexto, 0, bytesRead);
                }

                inStream.Close();
                outStream.Close();
            FileInfo file = new FileInfo(input);
            file.Delete();

        }

        public static void decrypt(string input)
        {
            string strHash = key;
            FileStream inStream, outStream;
            CryptoStream CryStream;
            TripleDESCryptoServiceProvider TDS = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] byteHash, byteTexto;
            string output = input.Remove(input.Length - 3);
            inStream = new FileStream(input, FileMode.Open, FileAccess.Read);
            outStream = new FileStream(output, FileMode.OpenOrCreate, FileAccess.Write);

            byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
            byteTexto = File.ReadAllBytes(input);

            md5.Clear();

            TDS.Key = byteHash;
            TDS.Mode = CipherMode.ECB;

            CryStream = new CryptoStream(outStream, TDS.CreateDecryptor(), CryptoStreamMode.Write);

            int bytesRead;
            long length, position = 0;
            length = inStream.Length;

            while (position < length)
            {
                bytesRead = inStream.Read(byteTexto, 0, byteTexto.Length);
                position += bytesRead;

                CryStream.Write(byteTexto, 0, bytesRead);
            }

            inStream.Close();
            outStream.Close();
            FileInfo file = new FileInfo(input);
            file.Delete();

        }
    }
}
