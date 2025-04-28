namespace バックアップツール {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            btnSledctFolder = new Button();
            txtFolderPath = new TextBox();
            listBoxFiles = new ListBox();
            bunBackaup = new Button();
            txtBackupFlderPath = new TextBox();
            btnSelectBaskupFolder = new Button();
            lstBackupHistory = new ListBox();
            timerBackup = new System.Windows.Forms.Timer(components);
            chkAutoBackup = new CheckBox();
            numBackupInterval = new NumericUpDown();
            numBackupIntervalLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)numBackupInterval).BeginInit();
            SuspendLayout();
            // 
            // btnSledctFolder
            // 
            btnSledctFolder.Location = new Point(30, 188);
            btnSledctFolder.Name = "btnSledctFolder";
            btnSledctFolder.Size = new Size(75, 23);
            btnSledctFolder.TabIndex = 0;
            btnSledctFolder.Text = "参照\r\n";
            btnSledctFolder.UseVisualStyleBackColor = true;
            btnSledctFolder.Click += btnSledctFolder_Click;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(30, 159);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(267, 23);
            txtFolderPath.TabIndex = 1;
            // 
            // listBoxFiles
            // 
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(0, 0);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(401, 94);
            listBoxFiles.TabIndex = 0;
            listBoxFiles.SelectedIndexChanged += listBoxFiles_SelectedIndexChanged;
            // 
            // bunBackaup
            // 
            bunBackaup.Location = new Point(397, 230);
            bunBackaup.Name = "bunBackaup";
            bunBackaup.Size = new Size(75, 23);
            bunBackaup.TabIndex = 2;
            bunBackaup.Text = "バックアップ";
            bunBackaup.UseVisualStyleBackColor = true;
            bunBackaup.Click += bunBackaup_Click;
            // 
            // txtBackupFlderPath
            // 
            txtBackupFlderPath.Location = new Point(397, 159);
            txtBackupFlderPath.Name = "txtBackupFlderPath";
            txtBackupFlderPath.Size = new Size(267, 23);
            txtBackupFlderPath.TabIndex = 3;
            // 
            // btnSelectBaskupFolder
            // 
            btnSelectBaskupFolder.Location = new Point(397, 188);
            btnSelectBaskupFolder.Name = "btnSelectBaskupFolder";
            btnSelectBaskupFolder.Size = new Size(75, 23);
            btnSelectBaskupFolder.TabIndex = 4;
            btnSelectBaskupFolder.Text = "参照";
            btnSelectBaskupFolder.UseVisualStyleBackColor = true;
            btnSelectBaskupFolder.Click += btnSelectBaskupFolder_Click;
            // 
            // lstBackupHistory
            // 
            lstBackupHistory.FormattingEnabled = true;
            lstBackupHistory.ItemHeight = 15;
            lstBackupHistory.Location = new Point(12, 290);
            lstBackupHistory.Name = "lstBackupHistory";
            lstBackupHistory.Size = new Size(776, 154);
            lstBackupHistory.TabIndex = 5;
            lstBackupHistory.DoubleClick += lstBackupHistory_DoubleClick;
            // 
            // timerBackup
            // 
            timerBackup.Interval = 300000;
            timerBackup.Tick += timerBackup_Tick;
            // 
            // chkAutoBackup
            // 
            chkAutoBackup.AutoSize = true;
            chkAutoBackup.Location = new Point(505, 230);
            chkAutoBackup.Name = "chkAutoBackup";
            chkAutoBackup.Size = new Size(164, 19);
            chkAutoBackup.TabIndex = 6;
            chkAutoBackup.Text = "自動バックアップを有効にする";
            chkAutoBackup.UseVisualStyleBackColor = true;
            chkAutoBackup.CheckedChanged += chkAutoBackup_CheckedChanged;
            // 
            // numBackupInterval
            // 
            numBackupInterval.Location = new Point(505, 255);
            numBackupInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numBackupInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBackupInterval.Name = "numBackupInterval";
            numBackupInterval.Size = new Size(47, 23);
            numBackupInterval.TabIndex = 7;
            numBackupInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numBackupInterval.ValueChanged += numBackupInterval_ValueChanged;
            // 
            // numBackupIntervalLabel
            // 
            numBackupIntervalLabel.AutoSize = true;
            numBackupIntervalLabel.Location = new Point(558, 257);
            numBackupIntervalLabel.Name = "numBackupIntervalLabel";
            numBackupIntervalLabel.Size = new Size(36, 15);
            numBackupIntervalLabel.TabIndex = 8;
            numBackupIntervalLabel.Text = "分ごと";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numBackupIntervalLabel);
            Controls.Add(numBackupInterval);
            Controls.Add(chkAutoBackup);
            Controls.Add(lstBackupHistory);
            Controls.Add(btnSelectBaskupFolder);
            Controls.Add(txtBackupFlderPath);
            Controls.Add(bunBackaup);
            Controls.Add(listBoxFiles);
            Controls.Add(txtFolderPath);
            Controls.Add(btnSledctFolder);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numBackupInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSledctFolder;
        private TextBox txtFolderPath;
        private ListBox listBoxFiles;
        private Button bunBackaup;
        private TextBox txtBackupFlderPath;
        private Button btnSelectBaskupFolder;
        private ListBox lstBackupHistory;
        private System.Windows.Forms.Timer timerBackup;
        private CheckBox chkAutoBackup;
        private NumericUpDown numBackupInterval;
        private Label numBackupIntervalLabel;
    }
}
