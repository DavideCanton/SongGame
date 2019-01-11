using SongGame.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SongGame.Storage
{
    public class FilesStorage : IStorage
    {
        private readonly IDictionary<string, List<string>> files = new Dictionary<string, List<string>>();
        private readonly ISettingsContainer settings;
        private int totalCount;

        public FilesStorage(ISettingsContainer settings)
        {
            this.settings = settings;
        }

        public void reload()
        {
            files.Clear();
            totalCount = 0;

            foreach (var path in settings.getPaths())
            {
                files[path] = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories).ToList();
                totalCount += files[path].Count;
            }
        }

        public ISet<string> getRandomFiles(int count)
        {
            Random rnd = new Random();

            HashSet<int> indexes = new HashSet<int>();
            HashSet<string> res = new HashSet<string>();
            IEnumerable<string> values = files.Values.SelectMany(s => s);

            if (totalCount < count)
            {
                foreach (string value in values)
                    res.Add(value);
            }
            else
            {
                while (indexes.Count < count)
                {
                    int index = rnd.Next(totalCount);

                    if (indexes.Contains(index))
                        continue;

                    string path = values.ElementAt(index);

                    if (new SongData(path).IsValid)
                    {
                        indexes.Add(index);
                        res.Add(path);
                    }
                }
            }

            return res;
        }
    }
}
