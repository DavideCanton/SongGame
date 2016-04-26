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

            foreach (var path in settings.getPaths())
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

            List<int> sortedIndexes = indexes.ToList();
            sortedIndexes.Sort();

            HashSet<string> retFiles = new HashSet<string>(getPathAt(sortedIndexes));
            return retFiles;
        }

        private IEnumerable<string> getPathAt(List<int> indexes)
        {
            int cur = 0;

            IEnumerator<List<string>> it = files.Values.GetEnumerator();
            if (!it.MoveNext())
                yield break;

            foreach (int i in indexes)
            {
                List<string> value = it.Current;
                if (i >= cur && i < cur + value.Count)
                    yield return value[i - cur];
                else
                {
                    if (!it.MoveNext())
                        yield break;
                    cur += value.Count;
                }
            }
        }
    }
}
