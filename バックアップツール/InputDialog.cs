namespace DS3BackupApp {
    public class InputDialog : Form {
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;

        public string InputText => textBox.Text;

        public InputDialog(string prompt, string title, string defaultText = "") {
            // フォームの設定
            Text = title;
            Width = 300;
            Height = 150;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // テキストボックス
            textBox = new TextBox {
                Text = defaultText,
                Width = 220,
                Margin = new Padding(10),
            };

            // 中央に配置
            textBox.Location = new System.Drawing.Point((ClientSize.Width - textBox.Width) / 2, 38);

            Controls.Add(textBox);

            // ラベル
            Label label = new Label {
                Text = prompt,
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                AutoSize = true
            };
            Controls.Add(label);

            // ボタンパネル
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                Height = 50
            };

            // OKボタン
            okButton = new Button {
                Text = Properties.Resources.Button_OK,
                DialogResult = DialogResult.OK
            };

            // キャンセルボタン
            cancelButton = new Button {
                Text = Properties.Resources.Button_Cancel,
                DialogResult = DialogResult.Cancel
            };

            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);

            Controls.Add(buttonPanel);

            AcceptButton = okButton;
            CancelButton = cancelButton;
        }
    }
}
