using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SongGame.Settings
{
    public class SettingsContainer : ISettingsContainer
    {
        private List<string> paths = new List<string>();

        public IEnumerable<string> getPaths()
        {
            return paths.AsEnumerable();
        }

        public void addPath(string path)
        {
            paths.Add(path);
        }

        public void removePath(int index)
        {
            paths.RemoveAt(index);
        }

        public void loadFromFile(string path)
        {
            using (var stream = new StreamReader(path))
            {
                var obj = JsonConvert.DeserializeAnonymousType(stream.ReadToEnd(), new { paths = new string[0] });
                paths.AddRange(obj.paths);
            }
        }

        public void saveToFile(string path)
        {
            using (var stream = new StreamWriter(path))
            {
                var obj = new
                {
                    paths = paths.ToArray()
                };
                var json = JsonConvert.SerializeObject(obj);
                stream.WriteLine(json);
            }
        }
    }
}
