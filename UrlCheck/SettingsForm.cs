using System;
using System.Windows.Forms;

namespace UrlCheck {
    public partial class SettingsForm : Form {
        private UrlCheck agent;
        public const int MILLE = 1000;

        public SettingsForm(UrlCheck agent) {
            InitializeComponent();

            this.agent = agent;
        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            pollIntervalValue.Value = (ConfigSettings.PollIntervalMSec / MILLE);
            urlTextBox.Text = ConfigSettings.PollUrl;
            checkPathTextBox.Text = ConfigSettings.ValueJsonPath;
            displayPathTextBox.Text = ConfigSettings.LabelJsonPath;
            animIntervalValue.Value = ConfigSettings.AnimationIntervalMSec;
            displayDurationValue.Value = (ConfigSettings.DisplayMSec / MILLE);
        }

        private void okButton_Click(object sender, EventArgs e) {
            var res = MessageBox.Show("This will restart the UrlCheck utility, is that cool?", "Restart to load new settings", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes) {
                ConfigSettings.Set("PollIntervalMSec", (pollIntervalValue.Value * MILLE).ToString());
                ConfigSettings.Set("PollUrl", urlTextBox.Text);
                ConfigSettings.Set("ValueJsonPath", checkPathTextBox.Text);
                ConfigSettings.Set("LabelJsonPath", displayPathTextBox.Text);
                ConfigSettings.Set("AnimationIntervalMSec", animIntervalValue.Value.ToString());
                ConfigSettings.Set("DisplayMSec ", (displayDurationValue.Value * MILLE).ToString());

                agent.RestartAgent();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
