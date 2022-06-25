using System.Collections;
using System.Text;
using System.Web;

namespace CopyLiu.Toolkit.Web
{
    public static class Extensions
    {
        public static string UrlEncode(this IDictionary dict, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            var sb = new StringBuilder();
            foreach (DictionaryEntry entry in dict)
            {
                sb.Append(HttpUtility.UrlEncode(entry.Key.ToString(), encoding));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(entry.Value.ToString(), encoding));
                sb.Append("&");
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}