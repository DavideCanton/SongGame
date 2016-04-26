using SongGame.Forms;
using SongGame.Players;
using SongGame.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongGame
{
    public partial class MainForm : Form
    {
        private IStorage storage;
        private IPlayer player;
        private IFormFactory formFactory;
        private List<SongData> answers;
        private int correct, selected;
        private CancellationTokenSource cancelDelayToken;

        public MainForm(IStorage storage, IPlayer player, IFormFactory formFactory)
        {
            this.storage = storage;
            this.player = player;
            this.formFactory = formFactory;

            InitializeComponent();
            questionPanel.Visible = false;

            storage.reload();
        }

        private void newQuestionBtn_Click(object sender, EventArgs e)
        {
            player.Stop();
            questionPanel.Visible = true;
            playSong.Enabled = true;
            submitBtn.Enabled = true;
            answerLabel.Text = string.Empty;
            answers = storage.getRandomFiles(4).Select(path => new SongData(path)).ToList();
            correct = new Random().Next(4);
            choice1.Select();

            choice1.Text = answers[0].GetSongString();
            choice2.Text = answers[1].GetSongString();
            choice3.Text = answers[2].GetSongString();
            choice4.Text = answers[3].GetSongString();
            PlaySong();
        }

        private async void PlaySong()
        {
            if (cancelDelayToken != null)
                cancelDelayToken.Cancel();
            cancelDelayToken = new CancellationTokenSource();

            playSong.Enabled = false;
            player.SetSong(answers[correct].Path);
            int second = player.GetSongDuration() / 2;
            player.PlaySong(second);

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(10), cancelDelayToken.Token);
                StopSong();
            }
            catch (TaskCanceledException)
            {

            }
        }

        private void StopSong()
        {
            player.Stop();

            playSong.Enabled = true;
        }

        private void playSong_Click(object sender, EventArgs e)
        {
            PlaySong();
        }

        private void choice1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selected = 0;
        }

        private void choice2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selected = 1;
        }

        private void choice3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selected = 2;
        }

        private void choice4_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selected = 3;
        }

        private void showSettingsForm_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = formFactory.createForm<SettingsForm>();

            settingsForm.FormClosed += new FormClosedEventHandler((o, ea) =>
            {
                storage.reload();
            });
            settingsForm.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (selected == correct)
                answerLabel.Text = "Risposta esatta!";
            else
                answerLabel.Text = "Risposta sbagliata! La risposta corretta era: " + answers[correct].GetSongString();

            submitBtn.Enabled = false;
            playSong.Enabled = false;
            StopSong();
        }

    }
}
