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
            btnBackaup = new Button();
            txtBackupFlderPath = new TextBox();
            btnSelectBaskupFolder = new Button();
            lstBackupHistory = new ListBox();
            timerBackup = new System.Windows.Forms.Timer(components);
            chkAutoBackup = new CheckBox();
            numBackupInterval = new NumericUpDown();
            lblBackupInterval = new Label();
            lblProfile = new Label();
            cmbProfile = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numBackupInterval).BeginInit();
            SuspendLayout();
            // 
            // btnBackaup
            // 
            btnBackaup.Location = new Point(332, 98);
            btnBackaup.Name = "btnBackaup";
            btnBackaup.Size = new Size(75, 23);
            btnBackaup.TabIndex = 2;
            btnBackaup.Text = "バックアップ";
            btnBackaup.UseVisualStyleBackColor = true;
            btnBackaup.Click += btnBackaup_Click;
            // 
            // txtBackupFlderPath
            // 
            txtBackupFlderPath.Location = new Point(110, 12);
            txtBackupFlderPath.Name = "txtBackupFlderPath";
            txtBackupFlderPath.Size = new Size(267, 23);
            txtBackupFlderPath.TabIndex = 3;
            // 
            // btnSelectBaskupFolder
            // 
            btnSelectBaskupFolder.Location = new Point(110, 55);
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
            chkAutoBackup.Location = new Point(430, 59);
            chkAutoBackup.Name = "chkAutoBackup";
            chkAutoBackup.Size = new Size(164, 19);
            chkAutoBackup.TabIndex = 6;
            chkAutoBackup.Text = "自動バックアップを有効にする";
            chkAutoBackup.UseVisualStyleBackColor = true;
            chkAutoBackup.CheckedChanged += chkAutoBackup_CheckedChanged;
            // 
            // numBackupInterval
            // 
            numBackupInterval.Location = new Point(430, 84);
            numBackupInterval.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numBackupInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBackupInterval.Name = "numBackupInterval";
            numBackupInterval.Size = new Size(47, 23);
            numBackupInterval.TabIndex = 7;
            numBackupInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numBackupInterval.ValueChanged += numBackupInterval_ValueChanged;
            // 
            // lblBackupInterval
            // 
            lblBackupInterval.AutoSize = true;
            lblBackupInterval.Location = new Point(483, 86);
            lblBackupInterval.Name = "lblBackupInterval";
            lblBackupInterval.Size = new Size(36, 15);
            lblBackupInterval.TabIndex = 8;
            lblBackupInterval.Text = "分ごと";
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Location = new Point(12, 192);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(59, 15);
            lblProfile.TabIndex = 9;
            lblProfile.Text = "プロファイル";
            // 
            // cmbProfile
            // 
            cmbProfile.FormattingEnabled = true;
            cmbProfile.Location = new Point(83, 184);
            cmbProfile.Name = "cmbProfile";
            cmbProfile.Size = new Size(308, 23);
            cmbProfile.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbProfile);
            Controls.Add(lblProfile);
            Controls.Add(lblBackupInterval);
            Controls.Add(numBackupInterval);
            Controls.Add(chkAutoBackup);
            Controls.Add(lstBackupHistory);
            Controls.Add(btnSelectBaskupFolder);
            Controls.Add(txtBackupFlderPath);
            Controls.Add(btnBackaup);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numBackupInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnBackaup;
        private TextBox txtBackupFlderPath;
        private Button btnSelectBaskupFolder;
        private ListBox lstBackupHistory;
        private System.Windows.Forms.Timer timerBackup;
        private CheckBox chkAutoBackup;
        private NumericUpDown numBackupInterval;
        private Label lblBackupInterval;
        private Label lblProfile;
        private ComboBox cmbProfile;
    }
}
