using NAudio.Wave;
using System;

namespace SongGame.Players
{
    public class NAudioPlayer : IPlayer, IDisposable
    {
        private IWavePlayer player;
        private AudioFileReader reader;

        public int SongDuration { get; private set; }

        public void SetSong(string path)
        {
            player?.Dispose();
            reader?.Dispose();

            player = new WaveOut();
            reader = new AudioFileReader(path);
            SongDuration = (int)reader.TotalTime.TotalSeconds;
        }

        public void PlaySong(int second)
        {
            reader.Skip(second);
            player.Init(reader);
            player.Play();
        }

        public void Stop()
        {
            player?.Stop();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    reader.Dispose();
                    player.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
