using System.Collections.Generic;

namespace SongGame.Settings
{
    public interface ISettingsContainer
    {
        IEnumerable<string> getPaths();
        void addPath(string path);
        void removePath(int index);
        void loadFromFile(string path);
        void saveToFile(string path);
    }
}
