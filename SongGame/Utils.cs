
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
    }
}
