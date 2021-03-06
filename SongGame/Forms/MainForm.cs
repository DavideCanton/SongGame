﻿using SongGame.Forms;
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
        private readonly IStorage storage;
        private readonly IPlayer player;
        private readonly IFormFactory formFactory;
        private readonly IScoresManager scores;
        private readonly ISettingsContainer settings;
        private List<SongData> answers;
        private int correct, selected, seconds;
        private readonly Random rnd;
        private CancellationTokenSource cancelDelayToken;
        private readonly List<RadioButton> choices;

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

            choices = new List<RadioButton> { choice1, choice2, choice3, choice4 };
            time_lbl.Text = "";
        }

        private void ShowScores()
        {
            scores_lbl.Text = $"Wins: {scores.Ok} - Loses: {scores.Wrongs}";
        }

        private async void newQuestionBtn_Click(object sender, EventArgs e)
        {
            player.Stop();
            questionPanel.Visible = true;
            playSong.Enabled = true;
            submitBtn.Enabled = true;
            answerLabel.Text = string.Empty;
            answers = storage.getRandomFiles(4).Select(path => new SongData(path)).ToList();
            correct = rnd.Next(4);

            choices[0].Select();

            foreach (Tuple<int, RadioButton> t in choices.Enumerate())
            {
                t.Item2.Text = answers[t.Item1].SongString.Ellipsis(100);
            }

            await PlaySong().ConfigureAwait(false);
        }

        private async Task PlaySong()
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

            IProgress<int> p = new Progress<int>(s =>
            {
                time_lbl.Text = $"Tempo rimanente: {s} secondi...";
                progressBar.Value = s;
            });

            IProgress<bool> x = new Progress<bool>(_ =>
            {
                StopSong();
                SetWrong(false);
                UpdateStatus();
            });

            try
            {
                while (seconds > 0)
                {
                    p.Report(seconds);
                    await Task.Delay(TimeSpan.FromSeconds(1), cancelDelayToken.Token).ConfigureAwait(false);
                    --seconds;
                }
                p.Report(0);
                x.Report(false);
            }
            catch (TaskCanceledException)
            {

            }
        }

        private void StopSong()
        {
            player.Stop();
            cancelDelayToken?.Cancel();
            playSong.Enabled = true;
            showSettingsForm.Enabled = true;
        }

        private async void playSong_Click(object sender, EventArgs e)
        {
            await PlaySong().ConfigureAwait(false);
        }

        private void choice_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton senderBtn = sender as RadioButton;
            if (senderBtn.Checked)
                selected = choices.IndexOf(senderBtn);
        }

        private void showSettingsForm_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = formFactory.createForm<SettingsForm>();
            settingsForm.FormClosed += (o, ea) => storage.reload();
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
            scores.AddOk();
        }

        private void SetWrong(bool answered)
        {
            string message = answered ? "Risposta sbagliata! " : "";
            answerLabel.Text = $"{message}La risposta corretta era: {answers[correct].SongString}";
            scores.AddWrong();
        }
    }
}
