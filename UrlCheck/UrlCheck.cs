using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Helpers;
using System.Windows.Forms;

namespace UrlCheck {
    public class UrlCheck {
        #region Members and init
        internal AppContext context;

        internal readonly ConfigSettings Config = new ConfigSettings();

        private static string[] dot = new string[] { "." };

        private Timer pollTimer = new Timer();

        private bool firstRun = true;

        internal string LastValue = ConfigSettings.Get("LastValue", string.Empty);
        internal string LastLabel = ConfigSettings.Get("LastLabel", string.Empty);

        internal UrlCheck(AppContext context) {
            this.context = context;

            pollTimer.Interval = ConfigSettings.PollIntervalMSec;
            pollTimer.Tick += new System.EventHandler(this.pollTimer_Tick);

            CheckUrl();

            StartPolling();
        }
        #endregion

        #region Methods
        public void StartPolling() {
            pollTimer.Enabled = true;
            pollTimer.Start();
        }

        public async void CheckUrl() {
            try {
                using (var web = new HttpClient()) {
                    var jsonStr = await web.GetStringAsync(ConfigSettings.PollUrl);

                    if (!string.IsNullOrWhiteSpace(jsonStr)) {
                        dynamic json = Json.Decode(jsonStr);

                        var newValue = GetValueOfPath(json, ConfigSettings.ValueJsonPath);

                        var changed = (!string.IsNullOrWhiteSpace(newValue) && (
                            string.IsNullOrWhiteSpace(LastValue) ||
                            string.Compare(newValue, LastValue, true) != 0));

                        if (changed) {
                            LastValue = newValue;
                            LastLabel = GetValueOfPath(json, ConfigSettings.LabelJsonPath);
                        }

                        if (changed || firstRun) {
                            context.ShowPopup();
                            context.UnfreezePopup();
                            firstRun = false;
                        }
                    }
                }
            } catch (Exception ex) {
                context.ShowPopup("Error:", ex.Message);
                context.FreezePopup();
            }
        }

        private string GetValueOfPath(dynamic json, string path) {
            var newValue = string.Empty;

            if (json != null) {
                var list = new List<string>(path.Split(dot, StringSplitOptions.RemoveEmptyEntries));

                dynamic objPtr = json;

                foreach (var member in list) {
                    if (objPtr[member] != null)
                        objPtr = objPtr[member];
                }

                if (objPtr != null)
                    newValue = objPtr.ToString().Trim();
            }

            return newValue;
        }

        public void StopPolling() {
            pollTimer.Stop();
            pollTimer.Enabled = false;
        }

        public void Save() {
            ConfigSettings.Set("LastValue", LastValue);
            ConfigSettings.Set("LastLabel", LastLabel);
        }

        public void RestartAgent() {
            var info = new ProcessStartInfo();
            info.Arguments = "/C ping 127.0.0.1 -n 5 && \"" + Application.ExecutablePath + "\"";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.FileName = "cmd.exe";
            Process.Start(info);

            context.Exit();
        }

        public ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, EventHandler eventHandler) {
            var item = new ToolStripMenuItem(displayText);
            item.Image = null;
            item.ToolTipText = string.Empty;

            if (eventHandler != null)
                item.Click += eventHandler;

            return item;
        }

        # endregion

        #region Event handlers
        private void pollTimer_Tick(object sender, EventArgs e) {
            CheckUrl();
        }
        #endregion
    }
}
