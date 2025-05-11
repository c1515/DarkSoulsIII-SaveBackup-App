using DS3BackupApp.util;

namespace DS3BackupApp {
    public partial class formBackupApp : Form {
        private string saveFolderPath = "";
        private bool IsLoading = true;

        public formBackupApp() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (Properties.Settings.Default.IsFirstRun) {
                txtBackupFolderPath.Text = AppConstants.DefaultBackupPath;
                int minutes = (int)numBackupInterval.Value;
                timerBackup.Interval = minutes * 60 * 1000; // 分をミリ秒に変換

                string[] accountFolders = AccountHelper.GetAccounFolders();
                if (accountFolders.Length == 0) {
                    Application.Exit();
                }

                saveFolderPath = accountFolders[0];

                AccountHelper.SetAccount(accountFolders, cmbAccount);

                if (accountFolders.Length > 1) {
                    MessageBox.Show(string.Format(Properties.Resources.Info_Account, saveFolderPath));
                }

                ProfileService.SetProfile(txtBackupFolderPath.Text, cmbSaveprofile, cmbProfile);

                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            } else {
                txtBackupFolderPath.Text = Properties.Settings.Default.BackupFolder;
                numBackupInterval.Value = Properties.Settings.Default.BackupInterval;
                timerBackup.Interval = (int)numBackupInterval.Value * 60 * 1000;
                saveFolderPath = Properties.Settings.Default.SaveFolder;
                numMaxAutosave.Value = Properties.Settings.Default.MaxAutosave;

                if (!string.IsNullOrEmpty(txtBackupFolderPath.Text)) {
                    ProfileService.SetProfile(txtBackupFolderPath.Text, cmbSaveprofile, cmbProfile);
                }

                string[] accountFolders = AccountHelper.GetAccounFolders();
                AccountHelper.SetAccount(accountFolders, cmbAccount);
            }

            IsLoading = false;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            bool retry = false;
            do {
                try {
                    Properties.Settings.Default.BackupFolder = txtBackupFolderPath.Text;
                    Properties.Settings.Default.BackupInterval = numBackupInterval.Value;
                    Properties.Settings.Default.SaveFolder = saveFolderPath;
                    Properties.Settings.Default.MaxAutosave = numMaxAutosave.Value;
                    Properties.Settings.Default.SelectedProfile = cmbProfile.Text.Trim();
                    Properties.Settings.Default.SelectedSaveprofile = cmbSaveprofile.Text.Trim();
                    Properties.Settings.Default.SelectedAccount = cmbAccount.Text.Trim();

                    Properties.Settings.Default.Save();
                    retry = false; // 成功した場合はリトライしない
                } catch (Exception ex) {
                    retry = MessageHepler.Warning(string.Format(Properties.Resources.Warning_Close, ex.Message));
                }
            } while (retry);
        }

        private void btnBackaup_Click(object sender, EventArgs e) {
            if (!PathHelper.ValidatePath(txtBackupFolderPath.Text, false, saveFolderPath)) {
                return;
            }

            if (string.IsNullOrEmpty(cmbSaveprofile.Text.Trim())) {
                MessageHepler.Error(Properties.Resources.Error_EmptyProfile);
                return;
            }

            if (string.IsNullOrEmpty(cmbSavename.Text.Trim())) {
                MessageHepler.Error(Properties.Resources.Error_EmptySavename);
                return;
            }

            string backupPath = Path.Combine(txtBackupFolderPath.Text, cmbSaveprofile.Text.Trim(), cmbSavename.Text.Trim());
            if (!PathHelper.ValidatePath(backupPath, false)) {
                return;
            }

            if (!SavedataService.PrepareForBackup(backupPath, cmbSavename, cmbSaveprofile, cmbProfile)) {
                return;
            }

            SavedataService.Backup(backupPath, saveFolderPath);

            if (cmbProfile.Text.Trim() == cmbSaveprofile.Text.Trim()) {
                ProfileService.SetSavedata(txtBackupFolderPath.Text, cmbProfile.Text.Trim(), lstSavedata);
            }

            MessageHepler.Info(Properties.Resources.Complite_Backup);
        }

        private void btnSelectBackupFolder_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog dialog = new()) {
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtBackupFolderPath.Text = Path.Combine(dialog.SelectedPath, AppConstants.TopBackupFolder);
                }
            }

            if (!PathHelper.ValidatePath(txtBackupFolderPath.Text, false)) {
                txtBackupFolderPath.Clear();
                return;
            }

            ProfileService.SetProfile(txtBackupFolderPath.Text, cmbSaveprofile, cmbProfile);
        }

        private void lstSavedata_DoubleClick(object sender, EventArgs e) {
            if (!PathHelper.ValidatePath(txtBackupFolderPath.Text, true, saveFolderPath)) {
                return;
            }

            string savename = ProfileService.GetSavename(lstSavedata);
            if (string.IsNullOrEmpty(savename)) {
                return;
            }

            string backupPath = PathHelper.GetBackupPathFromList(savename, txtBackupFolderPath.Text, cmbProfile.Text.Trim());
            if (!PathHelper.ValidatePath(backupPath, true)) {
                return;
            }

            if (!MessageHepler.Confirm(string.Format(Properties.Resources.Confirm_Restore, savename))) {
                return;
            }

            SavedataService.Restore(backupPath, saveFolderPath);

        }

        private void timerBackup_Tick(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke(new Action(() => timerBackup_Tick(sender, e)));
                return;
            }

            if (!PathHelper.ValidatePathForAuto(txtBackupFolderPath.Text, saveFolderPath)) {
                return;
            }

            SavedataService.AutoBackup(txtBackupFolderPath.Text, saveFolderPath, numMaxAutosave.Value);

            if (cmbProfile.Text.Trim() == AppConstants.AutosaveProfile) {
                ProfileService.SetSavedata(txtBackupFolderPath.Text, cmbProfile.Text.Trim(), lstSavedata);
            }
        }

        private void chkAutoBackup_CheckedChanged(object? sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke(new Action(() => chkAutoBackup_CheckedChanged(sender, e)));
                return;
            }

            if (chkAutoBackup.Checked && !PathHelper.ValidatePath(txtBackupFolderPath.Text, false, saveFolderPath)) {
                // チェックボックスの状態を元に戻す  
                chkAutoBackup.CheckedChanged -= chkAutoBackup_CheckedChanged; // イベントを一時的に解除
                chkAutoBackup.Checked = !chkAutoBackup.Checked;
                chkAutoBackup.CheckedChanged += chkAutoBackup_CheckedChanged; // イベントを再登録
                return;
            }

            // タイマーの開始または停止  
            if (chkAutoBackup.Checked) {
                timerBackup.Start();
            } else {
                timerBackup.Stop();
            }
        }

        private void numBackupInterval_ValueChanged(object sender, EventArgs e) {
            int minutes = (int)numBackupInterval.Value;
            timerBackup.Interval = minutes * 60 * 1000;
        }

        private void cmbSaveprofile_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsLoading && !PathHelper.ValidatePath(txtBackupFolderPath.Text, true)) {
                cmbSavename.Items.Clear();
                return;
            }
            ProfileService.SetSavename(txtBackupFolderPath.Text, cmbSaveprofile.Text.Trim(), cmbSavename);
        }

        private void cmbProfile_SelectedIndexChanged(object sender, EventArgs e) {
            if (!IsLoading && !PathHelper.ValidatePath(txtBackupFolderPath.Text, true)) {
                cmbProfile.Items.Clear();
                lstSavedata.Items.Clear();
                return;
            }

            ProfileService.SetSavedata(txtBackupFolderPath.Text, cmbProfile.Text.Trim(), lstSavedata);

            txtMemo.Text = Properties.Resources.Info_SelectSavedata;
            txtMemo.Enabled = false;
        }

        private void txtMemo_Leave(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtBackupFolderPath.Text)) {
                MessageHepler.Error(Properties.Resources.Error_MemoWriteEmptyBackupPath);
                return;
            }

            string profilePath = PathHelper.GetBackupPathFromList(ProfileService.GetSavename(lstSavedata), txtBackupFolderPath.Text, cmbProfile.Text.Trim());
            if (!PathHelper.ValidatePath(profilePath, true)) {
                MessageHepler.Error(Properties.Resources.Error_MemoWrite);
                return;
            }

            MemoService.Write(profilePath, txtMemo.Text);
        }

        private void btnLordSavedata_Click(object sender, EventArgs e) {
            lstSavedata_DoubleClick(sender, e);
        }

        private void btnDeleteSavedata_Click(object sender, EventArgs e) {
            if (!PathHelper.ValidatePath(txtBackupFolderPath.Text, true)) {
                return;
            }

            string savename = ProfileService.GetSavename(lstSavedata);
            string backupPath = PathHelper.GetBackupPathFromList(ProfileService.GetSavename(lstSavedata), txtBackupFolderPath.Text, cmbProfile.Text.Trim());
            if (!PathHelper.ValidatePath(backupPath, true)) {
                return;
            }

            if (!MessageHepler.Confirm(string.Format(Properties.Resources.Confirm_DeleteSavedata, savename))) {
                return;
            }

            SavedataService.Delete(backupPath);
            ProfileService.RemoveSavedata(savename, lstSavedata);
            ProfileService.RemoveSavename(savename, cmbSavename);
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e) {
            if (!PathHelper.ValidatePath(txtBackupFolderPath.Text, true)) {
                return;
            }

            string profile = cmbProfile.Text.Trim();
            if (string.IsNullOrEmpty(profile)) {
                return;
            }

            string backupPath = Path.Combine(txtBackupFolderPath.Text, profile);
            if (!PathHelper.ValidatePath(backupPath, true)) {
                return;
            }

            if (ProfileService.Delete(backupPath, profile)) {
                string saveProfile = cmbSaveprofile.Text.Trim();
                ProfileService.RemoveProfile(profile, cmbProfile);
                ProfileService.RemoveProfile(profile, cmbSaveprofile);
                if (profile.Equals(saveProfile)) {
                    cmbSavename.Text = "";
                }
            }
        }

        private void cmbSaveprofile_KeyPress(object sender, KeyPressEventArgs e) {
            cmbSavename.Items.Clear();
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke(new Action(() => cmbAccount_SelectedIndexChanged(sender, e)));
                return;
            }

            string path = Path.Combine(AppConstants.AppDataPathDSIII, cmbAccount.Text.Trim());
            if (Directory.Exists(path)) {
                saveFolderPath = path;
            } else {
                MessageHepler.Error(Properties.Resources.Error_NotFoundAccount);
            }
        }

        private void btnChangeName_Click(object sender, EventArgs e) {
            if (!PathHelper.ValidatePath(txtBackupFolderPath.Text, true)) {
                return;
            }

            if (lstSavedata.SelectedItem == null) {
                MessageHepler.Error(Properties.Resources.Error_NoItemSelected);
                return;

            }
            string oldName = ProfileService.GetSavename(lstSavedata);
            if (string.IsNullOrEmpty(oldName)) {
                return;
            }

            while (true) {
                using (var inputDialog = new InputDialog(Properties.Resources.Prompt_EnterNewName, Properties.Resources.Form_ChangeName, oldName)) {
                    if (inputDialog.ShowDialog() == DialogResult.OK) {
                        string newName = inputDialog.InputText.Trim();
                        if (string.IsNullOrEmpty(newName)) {
                            MessageHepler.Error(Properties.Resources.Error_EmptySavename);
                            continue;
                        }

                        string oldPath = PathHelper.GetBackupPathFromList(oldName, txtBackupFolderPath.Text, cmbProfile.Text.Trim());
                        if (!PathHelper.ValidatePath(oldPath, true)) {
                            return;
                        }

                        string newPath = Path.Combine(Path.GetDirectoryName(oldPath) ?? string.Empty, newName);
                        if (!PathHelper.ValidatePath(newPath, false)) {
                            return;
                        }

                        if (Directory.Exists(newPath)) {
                            MessageHepler.Error(Properties.Resources.Error_NameAlreadyExists);
                            oldName = newName;
                            continue;
                        }

                        if (FileSystemHelper.MoveDirectory(oldPath, newPath)) {
                            ProfileService.SetSavedata(txtBackupFolderPath.Text, cmbProfile.Text.Trim(), lstSavedata);
                            MessageHepler.Info(string.Format(Properties.Resources.Info_Rename, oldName, newName));
                            break;
                        } else {
                            break;
                        }
                    } else {
                        break;
                    }
                }
            }

        }

        private void lstSavedata_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstSavedata.SelectedItem == null) {
                return;
            }

            txtMemo.Clear();
            if (!txtMemo.Enabled) {
                txtMemo.Enabled = true;
                txtMemo.ScrollBars = ScrollBars.Vertical;
            }

            if (string.IsNullOrEmpty(txtBackupFolderPath.Text)) {
                MessageHepler.Error(Properties.Resources.Error_MemoReadNoBackupPath);
                return;
            }

            string profilePath = PathHelper.GetBackupPathFromList(ProfileService.GetSavename(lstSavedata), txtBackupFolderPath.Text, cmbProfile.Text.Trim());
            if(!PathHelper.ValidatePath(profilePath, true)) {
                return;
            }

            MemoService.Read(profilePath, txtMemo);
        }
    }
}
