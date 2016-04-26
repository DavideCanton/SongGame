using Ninject;
using System.Windows.Forms;

namespace SongGame.Forms
{
    public class FormFactory : IFormFactory
    {
        private IKernel kernel;

        public FormFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T createForm<T>() where T : Form
        {
            return kernel.Get<T>();
        }
    }
}
