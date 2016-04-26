using SongGame.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SongGame.Storage
{
    public class FilesStorage : IStorage
    {
        private Dictionary<string, List<string>> files = new Dictionary<string, List<string>>();
        private ISettingsContainer settings;
        private int totalCount;

        public FilesStorage(ISettingsContainer settings)
        {
            this.settings = settings;
        }

        public void reload()
        {
            files.Clear();
            totalCount = 0;

            foreach(var path in settings.getPaths())
            {
                files[path] = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories).ToList();
                totalCount += files[path].Count;
            }
        }

        public ISet<string> getRandomFiles(int n)
        {
            Random rnd = new Random();
            HashSet<int> indexes = new HashSet<int>();
            while (indexes.Count < n)
                indexes.Add(rnd.Next(totalCount));

            HashSet<string> retFiles = new HashSet<string>(getPathAt(indexes));
            return retFiles;
        }

        private string getPathAt(int i)
        {
            int cur = 0;

            foreach(List<string> value in files.Values)
            {
                if (i >= cur && i < cur + value.Count)
                    return value[i - cur];
                cur += value.Count;
            }

            return string.Empty;
        }
    }
}
