namespace DS3BackupApp {
    public class InputDialog : Form {
        private TextBox textBox;
        private Button okButton;
        private Button cancelButton;

        public string InputText => textBox.Text;

        public InputDialog(string prompt, string title, string defaultText = "") {
            // �t�H�[���̐ݒ�
            Text = title;
            Width = 300;
            Height = 150;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            // �e�L�X�g�{�b�N�X
            textBox = new TextBox {
                Text = defaultText,
                Width = 220,
                Margin = new Padding(10),
            };

            // �����ɔz�u
            textBox.Location = new System.Drawing.Point((ClientSize.Width - textBox.Width) / 2, 38);

            Controls.Add(textBox);

            // ���x��
            Label label = new Label {
                Text = prompt,
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                AutoSize = true
            };
            Controls.Add(label);

            // �{�^���p�l��
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                Height = 50
            };

            // OK�{�^��
            okButton = new Button {
                Text = Properties.Resources.Button_OK,
                DialogResult = DialogResult.OK
            };

            // �L�����Z���{�^��
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
