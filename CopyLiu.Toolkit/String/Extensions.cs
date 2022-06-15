using System;
using System.Linq;

namespace CopyLiu.Toolkit.String
{
    public static class Extensions
    {
        private static char GetHexValue(int i)
        {
            return i < 10 ? (char)(i + 48) : (char)(i - 10 + 65);
        }

        public static string ToHexString(this byte[] input)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            char[] chArray = new char[input.Length*2];
            var arrayIndex = 0;
            for (int index = 0; index < input.Length*2; index += 2)
            {
                byte num2 = input[arrayIndex++];
                chArray[index] = GetHexValue((int) num2 / 16);
                chArray[index + 1] = GetHexValue((int) num2 % 16);
            }

            return new string(chArray);
#elif NETSTANDARD2_1
            return string.Create(input.Length * 2, input, (dst, state) =>
            {
                const string HexValues = "0123456789abcdef";

                var src = new ReadOnlySpan<byte>(state);

                var i = 0;
                var j = 0;

                var b = src[i++];
                dst[j++] = HexValues[b >> 4];
                dst[j++] = HexValues[b & 0xF];

                while (i < src.Length)
                {
                    b = src[i++];
                    dst[j++] = HexValues[b >> 4];
                    dst[j++] = HexValues[b & 0xF];
                }
            });
#else
            return string.Join("", input.Select(p => p.ToString("x2")));
#endif
        }

        public static byte[] AsByteArray(this string hexString)
        {
            //TODO: 性能优化
            return Enumerable.Range(0, hexString.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                .ToArray();
        }
    }
}