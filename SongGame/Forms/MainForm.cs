using SongGame.Forms;
using SongGame.Players;
using SongGame.Scores;
using SongGame.Settings;
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
        private IScoresManager scores;
        private ISettingsContainer settings;
        private List<SongData> answers;
        private int correct, selected, seconds;
        private Random rnd;
        private CancellationTokenSource cancelDelayToken;

        public MainForm(IStorage storage, IPlayer player, IFormFactory formFactory, IScoresManager scores, ISettingsContainer settings)
        {
            this.storage = storage;
            this.player = player;
            this.formFactory = formFactory;
            this.scores = scores;
            this.settings = settings;

            InitializeComponent();
            questionPanel.Visible = false;
            rnd = new Random();

            storage.reload();
            ShowScores();
        }

        private void ShowScores()
        {
            scores_lbl.Text = $"Wins: {scores.Ok} - Loses: {scores.Wrongs}";
        }

        private void newQuestionBtn_Click(object sender, EventArgs e)
        {
            player.Stop();
            questionPanel.Visible = true;
            playSong.Enabled = true;
            submitBtn.Enabled = true;
            answerLabel.Text = string.Empty;
            answers = storage.getRandomFiles(4).Select(path => new SongData(path)).ToList();
            correct = rnd.Next(4);
            choice1.Select();

            choice1.Text = answers[0].SongString.Ellipsis(100);
            choice2.Text = answers[1].SongString.Ellipsis(100);
            choice3.Text = answers[2].SongString.Ellipsis(100);
            choice4.Text = answers[3].SongString.Ellipsis(100);

            PlaySong();
        }

        private async void PlaySong()
        {
            var timeout = settings.TimerValue;
            StopSong();

            cancelDelayToken = new CancellationTokenSource();

            showSettingsForm.Enabled = false;
            playSong.Enabled = false;
            player.SetSong(answers[correct].Path);

            int second = rnd.Next(timeout, player.SongDuration - timeout);

            player.PlaySong(second);
            seconds = timeout;

            try
            {
                while (seconds > 0)
                {
                    time_lbl.Text = $"Tempo rimanente: {seconds} secondi...";
                    await Task.Delay(TimeSpan.FromSeconds(1), cancelDelayToken.Token);
                    --seconds;
                }
                StopSong();
                SetWrong(false);
                UpdateStatus();
            }
            catch (TaskCanceledException)
            {

            }
        }

        private void StopSong()
        {
            player.Stop();
            if (cancelDelayToken != null) cancelDelayToken.Cancel();
            playSong.Enabled = true;
            showSettingsForm.Enabled = true;
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
            settingsForm.FormClosed += new FormClosedEventHandler((o, ea) => storage.reload());
            settingsForm.Show();
        }        

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (selected == correct)
                SetOk();
            else
                SetWrong(true);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            ShowScores();
            StopSong();
            submitBtn.Enabled = false;
            playSong.Enabled = false;
        }

        private void SetOk()
        {
            answerLabel.Text = "Risposta esatta!";
            scores.addOk();
        }

        private void SetWrong(bool answered)
        {
            string message = "";
            if (answered)
                message += "Risposta sbagliata! ";

            answerLabel.Text = $"{message}La risposta corretta era: " + answers[correct].SongString;
            scores.addWrong();
        }
    }
}
