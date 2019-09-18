using SongGame.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SongGame.Storage
{
    public class FilesStorage : IStorage
    {
        public IDictionary<string, List<string>> files { get; } = new Dictionary<string, List<string>>();
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

            foreach (var path in settings.GetPaths())
                registerEntries(path, Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories).ToList());
        }

        public void registerEntries(string path, List<string> values)
        {
            files[path] = values;
            totalCount += values.Count;
        }

        public ISet<string> getRandomFiles(int count)
        {
            var rnd = new Random();

            var indexes = new HashSet<int>();
            var res = new HashSet<string>();

            if (totalCount < count)
            {
                foreach (var val in files.Values)
                    foreach (string value in val)
                        res.Add(value);
            }
            else
            {
                while (indexes.Count < count)
                {
                    var index = rnd.Next(totalCount);

                    if (indexes.Contains(index))
                        continue;

                    var path = findPath(index);

                    if (validatePath(path))
                    {
                        indexes.Add(index);
                        res.Add(path);
                    }
                }
            }

            return res;
        }

        public virtual bool validatePath(string path)
        {
            return new SongData(path).IsValid;
        }

        public string findPath(int index)
        {
            var cur = 0;
            foreach(var val in files.Values)
            {
                var n = cur + val.Count;
                if (index < n) return val[index - cur];
                cur = n;
            }
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
        }
    }
}
