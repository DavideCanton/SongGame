using System.Collections.Generic;

namespace SongGame.Settings
{
    public interface ISettingsContainer
    {
        IEnumerable<string> GetPaths();
        void AddPath(string path);
        void RemovePath(int index);
        void SetPaths(IEnumerable<string> paths);
        void LoadFromFile(string path);
        void SaveToFile(string path);

        int TimerValue { get; set; }  
    }
}
