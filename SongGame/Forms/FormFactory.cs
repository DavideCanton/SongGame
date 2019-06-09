using Autofac;
using System.Windows.Forms;

namespace SongGame.Forms
{
    public class FormFactory : IFormFactory
    {
        private readonly IComponentContext container;

        public FormFactory(IComponentContext container)
        {
            this.container = container;
        }

        public T createForm<T>() where T : Form
        {
            return container.Resolve<T>();
        }
    }
}
