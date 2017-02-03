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

        public string SongString
        {
            get
            {
                return Tag.Performers[0] + " - " + Tag.Title;
            }
        }

        public bool IsValid
        {
            get
            {
                return Tag.Performers.Length > 0 && !string.IsNullOrEmpty(Tag.Performers[0]) && !string.IsNullOrEmpty(Tag.Title);
            }
        }
    }
}
