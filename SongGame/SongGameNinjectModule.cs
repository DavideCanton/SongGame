using Ninject.Modules;
using SongGame.Forms;
using SongGame.Players;
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

            Bind<ISettingsContainer>().ToMethod(ctx =>
            {
                SettingsContainer sc = new SettingsContainer();
                sc.loadFromFile("config.json");
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
