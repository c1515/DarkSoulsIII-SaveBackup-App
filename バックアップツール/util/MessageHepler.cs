namespace DS3BackupApp.util {
    internal static class MessageHepler {
        internal static void Error(string message) {
            MessageBox.Show(message, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static bool Confirm(string message) {
            DialogResult result = MessageBox.Show(message, Properties.Resources.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        internal static void Info(string message) {
            MessageBox.Show(message, Properties.Resources.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static bool Warning(string message) {
            DialogResult result = MessageBox.Show(message, Properties.Resources.Warning, MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            return result == DialogResult.Retry;
        }
    }
}
