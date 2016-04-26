using Ninject;
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

            IKernel Kernel = SetupKernel();
            IFormFactory factory = Kernel.Get<IFormFactory>();
            Application.Run(factory.createForm<MainForm>());
        }

        private static IKernel SetupKernel()
        {
            return new StandardKernel(new SongGameNinjectModule());
        }
    }
}
