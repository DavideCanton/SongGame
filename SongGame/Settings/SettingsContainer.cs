﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace SongGame.Settings
{
    public class SettingsContainer : ISettingsContainer
    {
        private List<string> paths = new List<string>();

        public int TimerValue { get; set; }

        public IEnumerable<string> GetPaths()
        {
            return paths.AsEnumerable();
        }

        public void AddPath(string path)
        {
            paths.Add(path);
        }

        public void RemovePath(int index)
        {
            paths.RemoveAt(index);
        }

        public void SetPaths(IEnumerable<string> paths)
        {
            this.paths.Clear();
            this.paths.AddRange(paths);
        }

        public void LoadFromFile(string path)
        {
            using (var stream = new StreamReader(path))
            {
                var obj = JsonConvert.DeserializeObject<JsonSettingsModel>(stream.ReadToEnd());
                paths.AddRange(obj.paths);
                TimerValue = obj.timerValue;
            }
        }

        public void SaveToFile(string path)
        {
            using (var stream = new StreamWriter(path))
            {
                var obj = new JsonSettingsModel
                {
                    paths = paths.ToArray(),
                    timerValue = TimerValue
                };
                var json = JsonConvert.SerializeObject(obj);
                stream.WriteLine(json);
            }
        }
    }
}
