using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ProjectUTS_ISA
{
    public class AES
    {
        public static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public string Encrypt(string plaintext, string password, byte[] IV)
        {
            byte[] key = Encoding.UTF8.GetBytes(password);

            AesManaged aes = new AesManaged();
            aes.Key = key;
            aes.IV = IV;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] inputBytes = Encoding.UTF8.GetBytes(plaintext);
            cs.Write(inputBytes, 0, inputBytes.Length);
            cs.FlushFinalBlock();

            byte[] encryptedText = ms.ToArray();

            return Convert.ToBase64String(encryptedText);
        }

        public string Decrypt(string encryptedText, string password, byte[] IV)
        {
            byte[] key = Encoding.UTF8.GetBytes(password);

            AesManaged aes = new AesManaged();
            aes.Key = key;
            aes.IV = IV;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] inputBytes = Encoding.UTF8.GetBytes(encryptedText);
            cs.Write(inputBytes, 0, inputBytes.Length);
            cs.FlushFinalBlock();

            byte[] plaintext = ms.ToArray();

            return Convert.ToBase64String(plaintext);
        }
    }
}
