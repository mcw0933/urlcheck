using System;
using System.Drawing;
using System.Windows.Forms;

namespace UrlCheck {
    public partial class ToastForm : Form {
        #region Members and init
        private UrlCheck agent;

        public ToastForm(UrlCheck agent) {
            InitializeComponent();

            this.animationTimer.Interval = ConfigSettings.AnimationIntervalMSec;
            this.displayTimer.Interval = ConfigSettings.DisplayMSec;

            this.agent = agent;
        }
        #endregion

        private void ToastForm_Load(object sender, EventArgs e) {
            var area = Screen.GetWorkingArea(this);
            this.Location = new Point(area.Width - this.Width, area.Height + this.Height);
        }

        #region Properties

        public string Label { get { return displayLabel.Text; } }
        public string Value { get { return valueLabel.Text; } } 
        public bool Frozen { get; private set; }

        // Hide from Windows task switcher
        // http://stackoverflow.com/a/17893626/3782
        protected override CreateParams CreateParams {
            get {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;
                return Params;
            }
        }

        #endregion

        #region Methods
        public void PopToast() {
            animationTimer.Tag = Direction.Up;
            animationTimer.Enabled = true;
            animationTimer.Start();
        }

        public void Display(string label = null, string value = null) {
            displayLabel.Text = label ?? agent.LastLabel ?? ConfigSettings.LabelJsonPath;
            valueLabel.Text = value ?? agent.LastValue;
            timestampLabel.Text = DateTime.Now.ToString();

            PopToast();
        }

        public void Freeze() {
            Frozen = true;
        }

        public void Unfreeze() {
            Frozen = false;
            StartDelayHide();
        }
        #endregion

        #region Subroutines
        private void Animate() {
            var yBound = Screen.GetWorkingArea(this).Height;

            if ((Direction)animationTimer.Tag == Direction.Up) {
                if (this.Location.Y > yBound - this.Height) {
                    this.Location = new Point(this.Location.X, this.Location.Y - 8);
                } else {
                    StopAnimation();

                    if (!Frozen)
                        StartDelayHide();
                }
            } else {
                displayTimer.Stop();
                displayTimer.Enabled = false;

                if (this.Location.Y < yBound + this.Height) {
                    this.Location = new Point(this.Location.X, this.Location.Y + 8);
                } else
                    StopAnimation();
            }
        }

        private void StartDelayHide() {
            displayTimer.Start();
            displayTimer.Enabled = true;
        }

        private void StopAnimation() {
            animationTimer.Stop();
            animationTimer.Enabled = false;
        }
        #endregion

        #region Event handlers
        private void animationTimer_Tick(object sender, EventArgs e) {
            Animate();
        }

        private void displayTimer_Tick(object sender, EventArgs e) {
            animationTimer.Tag = Direction.Down;
            animationTimer.Enabled = true;
            animationTimer.Start();
        }
        #endregion
    }

    public enum Direction {
        Down = 0,
        Up = 1
    }
}
