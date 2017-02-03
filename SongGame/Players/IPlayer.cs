namespace SongGame.Players
{
    public interface IPlayer
    {
        void SetSong(string path);
        void PlaySong(int second);
        void Stop();

        int SongDuration { get; }
    }
}
