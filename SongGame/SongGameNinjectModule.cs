using Ninject.Modules;
using SongGame.Forms;
using SongGame.Players;
using SongGame.Scores;
using SongGame.Settings;
using SongGame.Storage;
using P = SongGame.Properties;

namespace SongGame
{
    public class SongGameNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStorage>().To<FilesStorage>().InSingletonScope();
            Bind<IPlayer>().To<NAudioPlayer>().InSingletonScope();
            Bind<IScoresManager>().To<ScoresManager>().InSingletonScope();

            Bind<ISettingsContainer>().ToMethod(_ =>
            {
                ISettingsContainer sc = new SettingsContainer();
                sc.LoadFromFile(P.Settings.Default.configPath);
                return sc;
            }).InSingletonScope();

            Bind<IFormFactory>().ToMethod(_ => new FormFactory(Kernel));
        }
    }
}
