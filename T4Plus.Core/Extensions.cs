using System.Collections.Generic;

namespace T4Plus
{
    public static class Extensions
    {
        public static string FirstToLower(this string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            if (s.Length > 1)
            {
                return s[0].ToString().ToLowerInvariant() + s.Substring(1);
            }

            return s[0].ToString().ToLowerInvariant();
        }

        public static string JoinWith<T>(this IEnumerable<T> source, string separator)
        {
            return string.Join(separator, source);
        }
    }
}