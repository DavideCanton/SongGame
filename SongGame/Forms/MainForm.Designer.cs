﻿namespace SongGame
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newQuestionBtn = new System.Windows.Forms.Button();
            this.questionPanel = new System.Windows.Forms.GroupBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.choice4 = new System.Windows.Forms.RadioButton();
            this.choice3 = new System.Windows.Forms.RadioButton();
            this.choice2 = new System.Windows.Forms.RadioButton();
            this.choice1 = new System.Windows.Forms.RadioButton();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.playSong = new System.Windows.Forms.Button();
            this.showSettingsForm = new System.Windows.Forms.Button();
            this.scores_lbl = new System.Windows.Forms.Label();
            this.time_lbl = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.questionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // newQuestionBtn
            // 
            this.newQuestionBtn.AutoSize = true;
            this.newQuestionBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newQuestionBtn.Location = new System.Drawing.Point(13, 13);
            this.newQuestionBtn.Name = "newQuestionBtn";
            this.newQuestionBtn.Size = new System.Drawing.Size(109, 27);
            this.newQuestionBtn.TabIndex = 0;
            this.newQuestionBtn.Text = "New Question!";
            this.newQuestionBtn.UseVisualStyleBackColor = true;
            this.newQuestionBtn.Click += new System.EventHandler(this.newQuestionBtn_Click);
            // 
            // questionPanel
            // 
            this.questionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionPanel.Controls.Add(this.answerLabel);
            this.questionPanel.Controls.Add(this.submitBtn);
            this.questionPanel.Controls.Add(this.choice4);
            this.questionPanel.Controls.Add(this.choice3);
            this.questionPanel.Controls.Add(this.choice2);
            this.questionPanel.Controls.Add(this.choice1);
            this.questionPanel.Controls.Add(this.labelQuestion);
            this.questionPanel.Controls.Add(this.playSong);
            this.questionPanel.Location = new System.Drawing.Point(13, 47);
            this.questionPanel.Name = "questionPanel";
            this.questionPanel.Size = new System.Drawing.Size(944, 254);
            this.questionPanel.TabIndex = 1;
            this.questionPanel.TabStop = false;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(4, 224);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(0, 17);
            this.answerLabel.TabIndex = 7;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(6, 189);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "Submit!";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // choice4
            // 
            this.choice4.AutoSize = true;
            this.choice4.Location = new System.Drawing.Point(7, 155);
            this.choice4.Name = "choice4";
            this.choice4.Size = new System.Drawing.Size(17, 16);
            this.choice4.TabIndex = 5;
            this.choice4.TabStop = true;
            this.choice4.UseVisualStyleBackColor = true;
            this.choice4.CheckedChanged += new System.EventHandler(this.choice_CheckedChanged);
            // 
            // choice3
            // 
            this.choice3.AutoSize = true;
            this.choice3.Location = new System.Drawing.Point(6, 133);
            this.choice3.Name = "choice3";
            this.choice3.Size = new System.Drawing.Size(17, 16);
            this.choice3.TabIndex = 4;
            this.choice3.TabStop = true;
            this.choice3.UseVisualStyleBackColor = true;
            this.choice3.CheckedChanged += new System.EventHandler(this.choice_CheckedChanged);
            // 
            // choice2
            // 
            this.choice2.AutoSize = true;
            this.choice2.Location = new System.Drawing.Point(6, 111);
            this.choice2.Name = "choice2";
            this.choice2.Size = new System.Drawing.Size(17, 16);
            this.choice2.TabIndex = 3;
            this.choice2.TabStop = true;
            this.choice2.UseVisualStyleBackColor = true;
            this.choice2.CheckedChanged += new System.EventHandler(this.choice_CheckedChanged);
            // 
            // choice1
            // 
            this.choice1.AutoSize = true;
            this.choice1.Location = new System.Drawing.Point(6, 89);
            this.choice1.Name = "choice1";
            this.choice1.Size = new System.Drawing.Size(17, 16);
            this.choice1.TabIndex = 2;
            this.choice1.TabStop = true;
            this.choice1.UseVisualStyleBackColor = true;
            this.choice1.CheckedChanged += new System.EventHandler(this.choice_CheckedChanged);
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(7, 56);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(194, 17);
            this.labelQuestion.TabIndex = 1;
            this.labelQuestion.Text = "Qual è il titolo della canzone?";
            // 
            // playSong
            // 
            this.playSong.AutoSize = true;
            this.playSong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.playSong.Location = new System.Drawing.Point(10, 17);
            this.playSong.Name = "playSong";
            this.playSong.Size = new System.Drawing.Size(82, 27);
            this.playSong.TabIndex = 0;
            this.playSong.Text = "Play Song";
            this.playSong.UseVisualStyleBackColor = true;
            this.playSong.Click += new System.EventHandler(this.playSong_Click);
            // 
            // showSettingsForm
            // 
            this.showSettingsForm.AutoSize = true;
            this.showSettingsForm.Location = new System.Drawing.Point(849, 13);
            this.showSettingsForm.Name = "showSettingsForm";
            this.showSettingsForm.Size = new System.Drawing.Size(108, 27);
            this.showSettingsForm.TabIndex = 2;
            this.showSettingsForm.Text = "Impostazioni...";
            this.showSettingsForm.UseVisualStyleBackColor = true;
            this.showSettingsForm.Click += new System.EventHandler(this.showSettingsForm_Click);
            // 
            // scores_lbl
            // 
            this.scores_lbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.scores_lbl.AutoSize = true;
            this.scores_lbl.Location = new System.Drawing.Point(705, 18);
            this.scores_lbl.Name = "scores_lbl";
            this.scores_lbl.Size = new System.Drawing.Size(0, 17);
            this.scores_lbl.TabIndex = 3;
            this.scores_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // time_lbl
            // 
            this.time_lbl.AutoSize = true;
            this.time_lbl.Location = new System.Drawing.Point(129, 18);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(208, 17);
            this.time_lbl.TabIndex = 4;
            this.time_lbl.Text = "Tempo rimanente: 10 secondi...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(344, 18);
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(210, 17);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            this.progressBar.Value = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 313);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.time_lbl);
            this.Controls.Add(this.scores_lbl);
            this.Controls.Add(this.showSettingsForm);
            this.Controls.Add(this.questionPanel);
            this.Controls.Add(this.newQuestionBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.questionPanel.ResumeLayout(false);
            this.questionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newQuestionBtn;
        private System.Windows.Forms.GroupBox questionPanel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.RadioButton choice4;
        private System.Windows.Forms.RadioButton choice3;
        private System.Windows.Forms.RadioButton choice2;
        private System.Windows.Forms.RadioButton choice1;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button playSong;
        private System.Windows.Forms.Button showSettingsForm;
        private System.Windows.Forms.Label scores_lbl;
        private System.Windows.Forms.Label time_lbl;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}