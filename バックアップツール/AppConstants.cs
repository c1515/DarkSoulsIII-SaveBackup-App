namespace DS3BackupApp {
    internal static class AppConstants {

        public const string DefaultProfile = "default";
        public const string AutosaveProfile = "Autosaves";
        public const string MemoFile = "memo.txt";
        public const string TopBackupFolder = "Backups";
        public const string DarkSoulsIII = "DarkSoulsIII";
        public const string DefaultBackupFolderSuffix = "_Backup";
        public const string AutosaveSaveName = "Autosave";
        public const string SavedataListFormat = "{0} - {1:yyyy/MM/dd HH:mm:ss}";
        public const string SavedataFile = "DS30000.sl2";
        public static readonly string DefaultBackupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DarkSoulsIII + DefaultBackupFolderSuffix, TopBackupFolder);
        public static readonly string AppDataPathDSIII = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DarkSoulsIII);
        public const string AutosaveFormat = AutosaveSaveName + " ";
    }
}
