using SongGame.Settings;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SongGame
{
    public partial class SettingsForm : Form
    {
        private ISettingsContainer settings;
        private BindingSource source;
        private int selectedIndex;

        public SettingsForm(ISettingsContainer sc)
        {
            settings = sc;

            InitializeComponent();

            source = new BindingSource();
            source.DataSource = settings.GetPaths().ToList();
            paths.DataSource = source;
            removeBtn.Enabled = false;

            timerValue.Value = settings.TimerValue;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                source.Add(folderBrowserDialog.SelectedPath);
                source.ResetBindings(false);
            }
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
        private void removeBtn_Click(object sender, EventArgs e)
        {
            source.RemoveAt(selectedIndex);
            source.ResetBindings(false);
            removeBtn.Enabled = false;
            paths.ClearSelected();
        }     

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }        

        private void ok_btn_Click(object sender, EventArgs e)
        {
            settings.TimerValue = (int) timerValue.Value;
            settings.SetPaths(source.Cast<string>());
            settings.SaveToFile(Properties.Settings.Default.configPath);
            Close();
        }
    }
}
