using Autofac;
using SongGame.Forms;
using System;
using System.Windows.Forms;

namespace SongGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            builder.RegisterModule(new IocModule());
            var container = builder.Build();

            var factory = container.Resolve<IFormFactory>();
            Application.Run(factory.createForm<MainForm>());
        }
    }
}
