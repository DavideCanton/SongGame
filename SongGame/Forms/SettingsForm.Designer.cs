namespace SongGame
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.paths = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.timerValue = new System.Windows.Forms.NumericUpDown();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.ok_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Impostazioni:";
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addBtn.Location = new System.Drawing.Point(578, 46);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(104, 28);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Aggiungi...";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeBtn.Location = new System.Drawing.Point(578, 80);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(104, 30);
            this.removeBtn.TabIndex = 3;
            this.removeBtn.Text = "Rimuovi...";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // paths
            // 
            this.paths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paths.FormattingEnabled = true;
            this.paths.ItemHeight = 16;
            this.paths.Location = new System.Drawing.Point(13, 46);
            this.paths.Name = "paths";
            this.paths.Size = new System.Drawing.Size(559, 196);
            this.paths.TabIndex = 4;
            this.paths.SelectedIndexChanged += new System.EventHandler(this.paths_SelectedIndexChanged);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.UserProfile;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Timer";
            // 
            // timerValue
            // 
            this.timerValue.Location = new System.Drawing.Point(64, 249);
            this.timerValue.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(120, 22);
            this.timerValue.TabIndex = 6;
            this.timerValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(606, 306);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 7;
            this.cancel_btn.Text = "Annulla";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(525, 306);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 8;
            this.ok_btn.Text = "Ok";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 341);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.timerValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paths);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.timerValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListBox paths;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown timerValue;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button ok_btn;
    }
}