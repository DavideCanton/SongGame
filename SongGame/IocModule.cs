using Autofac;
using SongGame.Forms;
using SongGame.Players;
using SongGame.Scores;
using SongGame.Settings;
using SongGame.Storage;
using System.Reflection;
using System.Windows.Forms;
using P = SongGame.Properties;

namespace SongGame
{
    public class IocModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder container)
        {
            container.RegisterType<FilesStorage>().AsImplementedInterfaces().SingleInstance();
            container.RegisterType<NAudioPlayer>().AsImplementedInterfaces().SingleInstance();
            container.RegisterType<ScoresManager>().AsImplementedInterfaces().SingleInstance();
            container.RegisterType<FormFactory>().AsImplementedInterfaces().SingleInstance();

            container.Register((context, settings) =>
            {
                ISettingsContainer sc = new SettingsContainer();
                sc.LoadFromFile(P.Settings.Default.configPath);
                return sc;
            }).SingleInstance();

            container.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                 .Where(t => t.IsSubclassOf(typeof(Form)))
                 .AsSelf();
        }
    }
}
