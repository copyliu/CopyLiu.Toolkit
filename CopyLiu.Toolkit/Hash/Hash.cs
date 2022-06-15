using System.Security.Cryptography;
using System.Text;

namespace CopyLiu.Toolkit.Hash
{
    public class HashHelper
    {
        private static byte[] ComputeHash(byte[] input, HashAlgorithm hashAlgorithm)
        {
            return hashAlgorithm.ComputeHash(input);
        }

        public static byte[] MD5(byte[] input)
        {
            using var hash = System.Security.Cryptography.MD5.Create();
            return ComputeHash(input, hash);
        }

        public static byte[] MD5(string input, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return MD5(encoding.GetBytes(input));
        }

        public static byte[] SHA1(byte[] input)
        {
            using var hash = System.Security.Cryptography.SHA1.Create();
            return ComputeHash(input, hash);
        }

        public static byte[] SHA1(string input, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return SHA1(encoding.GetBytes(input));
        }

        public static byte[] SHA256(byte[] input)
        {
            using var hash = System.Security.Cryptography.SHA256.Create();
            return ComputeHash(input, hash);
        }

        public static byte[] SHA256(string input, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return SHA256(encoding.GetBytes(input));
        }
    }
}