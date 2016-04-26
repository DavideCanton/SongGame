using System.Collections.Generic;

namespace SongGame.Storage
{
    public interface IStorage
    {
        ISet<string> getRandomFiles(int n);
        void reload();
    }
}
