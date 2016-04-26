using NAudio.Wave;

namespace SongGame.Players
{
    public class NAudioPlayer : IPlayer
    {
        private IWavePlayer player;
        private AudioFileReader reader;

        public void SetSong(string path)
        {
            player = new WaveOut();
            reader = new AudioFileReader(path);
        }

        public void PlaySong(int second)
        {
            reader.Skip(second);
            player.Init(reader);
            player.Play();

            player.PlaybackStopped += Player_PlaybackStopped;
        }

        public void Stop()
        {
            if (player != null)
                player.Stop();
        }

        private void Player_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            reader.Dispose();
            player.Dispose();
        }

        public int GetSongDuration()
        {
            return reader.TotalTime.Seconds;
        }
    }
}
