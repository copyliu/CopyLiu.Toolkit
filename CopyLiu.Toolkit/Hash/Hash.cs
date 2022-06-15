using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CopyLiu.Toolkit.Hash
{
    public class HashHelper
    {
        private static string CalcHash(byte[] input, HashAlgorithm hashAlgorithm)
        {
            return string.Join("", hashAlgorithm
                .ComputeHash(input)
                .Select(p => p.ToString("x2")));
        }

        public static string MD5(byte[] input)
        {
            using var hash = System.Security.Cryptography.MD5.Create();
            return CalcHash(input, hash);
        }

        public static string MD5(string input, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return MD5(encoding.GetBytes(input));
        }

        public static string SHA1(byte[] input)
        {
            using var hash = System.Security.Cryptography.SHA1.Create();
            return CalcHash(input, hash);
        }

        public static string SHA1(string input, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return SHA1(encoding.GetBytes(input));
        }

        public static string SHA256(byte[] input)
        {
            using var hash = System.Security.Cryptography.SHA256.Create();
            return CalcHash(input, hash);
        }

        public static string SHA256(string input, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return SHA256(encoding.GetBytes(input));
        }
    }
}