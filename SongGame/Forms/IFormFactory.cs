using System.Windows.Forms;

namespace SongGame.Forms
{
    public interface IFormFactory
    {
        T createForm<T>() where T : Form;
    }
}
