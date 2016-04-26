using SongGame.Settings;
using System;
using System.Windows.Forms;

namespace SongGame
{
    public partial class SettingsForm : Form
    {
        private ISettingsContainer settings;
        private int selectedIndex;
        private BindingSource source;

        public SettingsForm(ISettingsContainer sc)
        {
            settings = sc;

            InitializeComponent();

            source = new BindingSource();
            source.DataSource = settings.getPaths();
            paths.DataSource = source;
            removeBtn.Enabled = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                settings.addPath(folderBrowserDialog.SelectedPath);
                source.ResetBindings(false);
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            settings.removePath(selectedIndex);
            source.ResetBindings(false);
            removeBtn.Enabled = false;
            paths.ClearSelected();
        }

        private void paths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paths.SelectedIndices.Count > 0)
            {
                selectedIndex = paths.SelectedIndices[0];
                removeBtn.Enabled = true;
            }
            else
            {
                selectedIndex = -1;
                removeBtn.Enabled = false;
            }
        }
    }
}
