namespace バックアップツール {
    public partial class Form1 : Form {
        private string historyFilePath = "backup_history.txt";

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (File.Exists(historyFilePath)) {
                using (StreamReader reader = new StreamReader(historyFilePath)) {
                    while (!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        lstBackupHistory.Items.Add(line);
                    }
                }
            }

            int minutes = (int)numBackupInterval.Value;
            timerBackup.Interval = minutes * 60 * 1000; // 分をミリ秒に変換
        }

        private void btnSledctFolder_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtFolderPath.Text = dialog.SelectedPath;
                    DisplayFiles(dialog.SelectedPath);
                }
            }
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void DisplayFiles(string folderPath) {
            listBoxFiles.Items.Clear();
            string[] files = Directory.GetFiles(folderPath);
            foreach (var file in files) {
                listBoxFiles.Items.Add(Path.GetFileName(file));
            }
        }

        private void bunBackaup_Click(object sender, EventArgs e) {
            string sourcePath = txtFolderPath.Text;
            string backupPath = txtBackupFlderPath.Text;

            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(backupPath)) {
                MessageBox.Show("フォルダを選択してください。");
                return;
            }

            if (!Directory.Exists(backupPath)) {
                Directory.CreateDirectory(backupPath);
            }

            foreach (var filePath in Directory.GetFiles(sourcePath)) {//ファイル名固定に変更予定ノート機能
                string fileName = Path.GetFileName(filePath);
                string destPath = Path.Combine(backupPath, fileName);

                try {
                    File.Copy(filePath, destPath, true);
                } catch (Exception ex) {
                    MessageBox.Show($"ファイルのコピー中にエラーが発生しました。\n\n{ex.Message}",
                        "バックアップエラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            string history = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} バックアップ元: {sourcePath} → 先: {backupPath}";
            lstBackupHistory.Items.Add(history);

            MessageBox.Show("バックアップが完了しました。");
        }

        private void btnSelectBaskupFolder_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()) {
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtBackupFlderPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            using (StreamWriter writer = new StreamWriter(historyFilePath, false)) {
                foreach (var item in lstBackupHistory.Items) {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        private void lstBackupHistory_DoubleClick(object sender, EventArgs e) {
            if (lstBackupHistory.SelectedItem == null)
                return;

            string selectedHistory = lstBackupHistory.SelectedItem.ToString();

            int sourceStart = selectedHistory.IndexOf("バックアップ元: ") + "バックアップ元: ".Length;
            int sourceEnd = selectedHistory.IndexOf(" → 先: ");
            int destStart = sourceEnd + " → 先: ".Length;

            if (sourceStart < 0 || sourceEnd < 0 || destStart < 0) {
                MessageBox.Show("履歴のフォーマットが正しくありません。");
                return;
            }

            string sourcePath = selectedHistory.Substring(sourceStart, sourceEnd - sourceStart);
            string backupPath = selectedHistory.Substring(destStart);

            var result = MessageBox.Show("このバックアップから復元しますか？", "確認", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
                return;

            if (!Directory.Exists(sourcePath)) {
                Directory.CreateDirectory(sourcePath);
            }

            foreach (var filePath in Directory.GetFiles(backupPath)) {
                string fileName = Path.GetFileName(filePath);
                string destPath = Path.Combine(sourcePath, fileName);
                try {
                    File.Copy(filePath, destPath, true);
                } catch (Exception ex) {
                    MessageBox.Show($"ファイルのコピー中にエラーが発生しました。\n\n{ex.Message}",
                        "バックアップエラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("復元が完了しました。");
        }

        private void timerBackup_Tick(object sender, EventArgs e) {
            string sourcePath = txtFolderPath.Text;
            string backupPath = txtBackupFlderPath.Text;

            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(backupPath)) {
                return;
            }

            if (!Directory.Exists(backupPath)) {
                Directory.CreateDirectory(backupPath);
            }

            foreach (var filePath in Directory.GetFiles(sourcePath)) {
                string fileName = Path.GetFileName(filePath);
                string destPath = Path.Combine(backupPath, fileName);

                try {
                    File.Copy(filePath, destPath, true);
                } catch (Exception ex) {
                    MessageBox.Show($"ファイルのコピー中にエラーが発生しました。\n\n{ex.Message}",
                        "バックアップエラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            string history = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} (自動) バックアップ元: {sourcePath} → 先: {backupPath}";
            lstBackupHistory.Items.Add(history);
        }

        private void chkAutoBackup_CheckedChanged(object sender, EventArgs e) {
            if (chkAutoBackup.Checked) {
                timerBackup.Start();
            } else {
                timerBackup.Stop();
            }
        }

        private void numBackupInterval_ValueChanged(object sender, EventArgs e) {
            int minutes = (int)numBackupInterval.Value;
            timerBackup.Interval = minutes * 60 * 1000; // 分をミリ秒に変換
        }
    }
}
