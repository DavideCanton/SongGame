
namespace SongGame.Scores
{
    public class ScoresManager : IScoresManager
    {
        public int Ok { get; private set; }
        public int Wrongs { get; private set; }

        public void AddOk()
        {
            ++Ok;
        }

        public void AddWrong()
        {
            ++Wrongs;
        }
    }
}
