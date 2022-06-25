using System;
using System.Security.Cryptography;
using System.Text;
using CopyLiu.Toolkit.String;

namespace CopyLiu.Toolkit.Crypt
{
    public class AESCBC
    {
        private static RijndaelManaged GetCryptoServiceProvider(byte[] keyBytes, byte[] ivBytes)
        {
            var cryptoProvider = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = ivBytes
            };
            return cryptoProvider;
        }

        private static RijndaelManaged GetCryptoServiceProvider(string secretKey, string iv)
        {
            var keyBytes = secretKey.AsByteArray();
            var ivBytes = iv.AsByteArray();
            return GetCryptoServiceProvider(keyBytes, ivBytes);
        }

        private static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        private static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            return Encrypt(data, GetCryptoServiceProvider(key, iv));
        }

        public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            return Decrypt(data, GetCryptoServiceProvider(key, iv));
        }

        public static string Base64Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            return Convert.ToBase64String(Encrypt(data, GetCryptoServiceProvider(key, iv)));
        }


        public static byte[] Base64Decrypt(string encryptedText, byte[] key, byte[] iv)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return Decrypt(encryptedBytes, GetCryptoServiceProvider(key, iv));
        }

        public static string Base64Encrypt(string plainText, byte[] key, byte[] iv, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            var plainBytes = encoding.GetBytes(plainText);
            return Convert.ToBase64String(Encrypt(plainBytes, GetCryptoServiceProvider(key, iv)));
        }


        public static string Base64Decrypt(string encryptedText, byte[] key, byte[] iv, Encoding encoding)
        {
            encoding ??= Encoding.UTF8;
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            return encoding.GetString(Decrypt(encryptedBytes, GetCryptoServiceProvider(key, iv)));
        }
    }
}