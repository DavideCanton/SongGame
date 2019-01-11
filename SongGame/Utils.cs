
using System;
using System.Collections.Generic;
using System.Linq;

namespace SongGame
{
    public static class Utils
    {
        public static string Ellipsis(this string s, int length)
        {
            length -= 3;

            if (s.Length < length)
                return s;

            return s.Substring(length) + "...";
        }

        public static IEnumerable<Tuple<int, T>> Enumerate<T>(this IEnumerable<T> e, int start = 0)
        {
            return CountFrom(0).Zip(e, Tuple.Create);        
        }

        private static IEnumerable<int> CountFrom(int v)
        {
            int i = v;
            while (true)
                yield return i++;
        }
    }
}
