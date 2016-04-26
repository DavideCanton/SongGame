using TagLib;

namespace SongGame
{
    public struct SongData
    {
        public string Path;
        public Tag Tag;

        public SongData(string path)
        {
            Path = path;
            Tag = File.Create(path).Tag;
        }

        public string GetSongString()
        {
            return Tag.Performers[0] + " - " + Tag.Title;
        }
    }
}
