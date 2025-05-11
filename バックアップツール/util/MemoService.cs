namespace DS3BackupApp.util {
    internal static class MemoService {
        internal static void Create(string backupPath) {
            if (!PathHelper.ValidatePath(backupPath, true)) {
                return;
            }

            string memoPath = Path.Combine(backupPath, AppConstants.MemoFile);
            if (!File.Exists(memoPath)) {
                FileSystemHelper.CreateFile(memoPath);
            }
        }

        internal static void Write(string profilePath, string memoText) {
            if (!Directory.Exists(profilePath)) {
                MessageHepler.Error(Properties.Resources.Error_NotfoundBackupfolder);
                return;
            }

            string memoPath = Path.Combine(profilePath, AppConstants.MemoFile);
            if (!File.Exists(memoPath)) {
                MessageHepler.Error(Properties.Resources.Error_NotFoundMemo);
                return;
            }

            FileSystemHelper.WriteAllText(memoPath, memoText);
        }

        internal static void Read(string profilePath, TextBox memoTextBox) {
            if (!Directory.Exists(profilePath)) {
                MessageHepler.Error(Properties.Resources.Error_NotfoundBackupfolder);
                return;
            }
            if (memoTextBox == null) {
                throw new ArgumentNullException(nameof(memoTextBox), "TextBoxが未設定");
            }

            string memoPath = Path.Combine(profilePath, AppConstants.MemoFile);
            if (!File.Exists(memoPath)) {
                MessageHepler.Error(Properties.Resources.Error_NotFoundMemo);
                return;
            }

            memoTextBox.Text = FileSystemHelper.ReadAllText(memoPath);
        }
    }
}

