using Ninject.Modules;
using SongGame.Forms;
using SongGame.Players;
using SongGame.Scores;
using SongGame.Settings;
using SongGame.Storage;

namespace SongGame
{
    public class SongGameNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStorage>().To<FilesStorage>().InSingletonScope();
            Bind<IPlayer>().To<NAudioPlayer>();
            Bind<IScoresManager>().To<ScoresManager>();

            Bind<ISettingsContainer>().ToMethod(ctx =>
            {
                ISettingsContainer sc = new SettingsContainer();
                sc.LoadFromFile(Properties.Settings.Default.configPath);
                return sc;
            }).InSingletonScope();

            Bind<IFormFactory>().ToMethod(ctx =>
            {
                FormFactory factory = new FormFactory(Kernel);
                return factory;
            });
        }
    }
}
