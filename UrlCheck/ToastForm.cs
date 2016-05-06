using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Net.Http;
using System.Web.Helpers;
using System.Windows.Forms;

namespace UrlCheck {
    public partial class ToastForm : Form {
        #region Members and init
        private static readonly int AnimationIntervalMSec = Get("AnimationIntervalMSec", 10);
        private static readonly int DisplayMSec = Get("DisplayMSec", 3000);
        private static readonly int PollIntervalMSec = Get("DisplayMSec", 1000);

        private static readonly string PollUrl = Get("PollUrl", "https://pacific-hollows-2522.herokuapp.com/api/player/WhileJazz?gid=Reddit%20Omega");
        private static readonly string CheckJsonPath = Get("CheckJsonPath", "player.trophies_won");
        private static readonly string DisplayJsonPath = Get("DisplayJsonPath", "player.trophies_won");

        private static string[] dot = new string[] { "." };
        private static readonly List<string> CheckJsonPathParts = new List<string>(CheckJsonPath.Split(dot, StringSplitOptions.RemoveEmptyEntries));
        private static readonly List<string> DisplayJsonPathParts = new List<string>(DisplayJsonPath.Split(dot, StringSplitOptions.RemoveEmptyEntries));

        private string LastValue = Get("LastValue", string.Empty);

        public ToastForm() {
            InitializeComponent();
        }
        #endregion

        private void ToastForm_Load(object sender, EventArgs e) {
            var area = Screen.GetWorkingArea(this);

            this.Location = new Point(area.Width - this.Width, area.Height + this.Height);

            StartPolling();
        }

        #region Methods
        public void StartPolling() {
            pollTimer.Enabled = true;
            pollTimer.Start();
        }

        public async void CheckUrl() {
            try {
                using (var web = new HttpClient()) {
                    var jsonStr = await web.GetStringAsync(PollUrl);

                    if (!string.IsNullOrWhiteSpace(jsonStr)) {
                        dynamic json = Json.Decode(jsonStr);

                        if (json != null) {
                            dynamic objPtr = json;

                            foreach (var member in CheckJsonPathParts) {
                                if (objPtr[member] != null)
                                    objPtr = objPtr[member];
                            }

                            if (objPtr != null) {
                                var newValue = objPtr.ToString().Trim();

                                if (string.IsNullOrWhiteSpace(LastValue) || string.Compare(newValue, LastValue, true) != 0) {
                                    LastValue = newValue;
                                    Display();
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Display("Error:", ex.Message);
            }
        }

        public void StopPolling() {
            pollTimer.Stop();
            pollTimer.Enabled = false;
        }

        public void PopToast() {
            animationTimer.Tag = Direction.Up;
            animationTimer.Enabled = true;
            animationTimer.Start();
        }

        public void Display(string label = null, string value = null) {
            displayLabel.Text = label ?? DisplayJsonPath;
            valueLabel.Text = value ?? LastValue;
            timestampLabel.Text = DateTime.Now.ToString();

            PopToast();
        }
        #endregion

        #region Subroutines
        private static int Get(string name, int defVal) {
            var retVal = defVal;
            var setting = ConfigurationManager.AppSettings.Get(name);

            if (!string.IsNullOrWhiteSpace(setting))
                retVal = int.TryParse(setting, out retVal) ? retVal : defVal;

            return retVal;
        }

        private static string Get(string name, string defVal) {
            var setting = ConfigurationManager.AppSettings.Get(name);
            var retVal = string.IsNullOrWhiteSpace(setting) ? defVal : setting;

            return retVal;
        }

        private void Animate() {
            var yBound = Screen.GetWorkingArea(this).Height;

            if ((Direction)animationTimer.Tag == Direction.Up) {
                if (this.Location.Y > yBound - this.Height) {
                    this.Location = new Point(this.Location.X, this.Location.Y - 8);
                } else {
                    animationTimer.Stop();
                    animationTimer.Enabled = false;
                    displayTimer.Start();
                    displayTimer.Enabled = true;
                }
            } else {
                displayTimer.Stop();
                displayTimer.Enabled = false;

                if (this.Location.Y < yBound + this.Height) {
                    this.Location = new Point(this.Location.X, this.Location.Y + 8);
                } else {
                    animationTimer.Stop();
                    animationTimer.Enabled = false;
                }
            }
        }
        #endregion

        #region Event handlers
        private void pollTimer_Tick(object sender, EventArgs e) {
            CheckUrl();
        }
        #endregion

        private void animationTimer_Tick(object sender, EventArgs e) {
            Animate();
        }

        private void displayTimer_Tick(object sender, EventArgs e) {
            animationTimer.Tag = Direction.Down;
            animationTimer.Enabled = true;
            animationTimer.Start();
        }
    }

    public enum Direction {
        Down = 0,
        Up = 1
    }
}
