using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;

namespace UrlCheck {
    internal class AppContext : ApplicationContext {
        #region Members and init
        private static readonly string IconFileName = "WebCheck.ico";
        private static readonly string DefaultTooltip = "WebCheck: notify when web data changes";
        private readonly UrlCheck agent;

        private IContainer components; // the list of components to dispose when the context is disposed
        private NotifyIcon notifyIcon; // the icon that sits in the system tray

        private ToastForm popup;
        private SettingsForm settingsForm;

        public AppContext() {
            //InitializeContext();

            components = new Container();
            notifyIcon = new NotifyIcon(components) {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon(IconFileName),
                Text = DefaultTooltip,
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Opening += contextMenuStrip_Opening;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            notifyIcon.MouseUp += notifyIcon_MouseUp;

            agent = new UrlCheck(this);
        }
        private void InitializeContext() {
            
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing) {
            if (disposing && components != null) { components.Dispose(); }
        }

        protected override void ExitThreadCore() {
            if (settingsForm != null) { settingsForm.Close(); }
            if (popup != null) { popup.Close(); }

            notifyIcon.Visible = false; // should remove lingering tray icon!
            base.ExitThreadCore();
        }
        #endregion

        #region Methods
        public void ShowPopup(string label = null, string value = null) {
            if (popup == null) {
                popup = new ToastForm(agent);
                popup.Closed += popup_Closed;
                popup.Show();
            } else { popup.Activate(); }

            popup.Display(label, value);

            notifyIcon.Text = (!string.IsNullOrWhiteSpace(value) && value.Length > 63) ? value.Substring(0, 63) : value; // tooltips only 64 chars long
        }

        public void FreezePopup() {
            popup.Freeze();
        }

        public void UnfreezePopup() {
            popup.Unfreeze();
        }

        public void ShowSettingsForm() {
            if (settingsForm == null) {
                settingsForm = new SettingsForm(agent);
                settingsForm.Closed += settingsForm_Closed;  // avoid reshowing a disposed form
                settingsForm.Show();
            } else { settingsForm.Activate(); }
        }

        public void Exit() {
            agent.Save();

            ExitThread();
        }
        #endregion

        #region Subroutines
        private void ShowContextMenu() {
            notifyIcon.ContextMenuStrip.Items.Clear();

            notifyIcon.ContextMenuStrip.Items.Add(agent.ToolStripMenuItemWithHandler("Show &Popup", popupMenuItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(agent.ToolStripMenuItemWithHandler("&Settings", settingsMenuItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(agent.ToolStripMenuItemWithHandler("E&xit", exitMenuItem_Click));
        }

        #endregion

        #region Event handlers

        #region Tray icon
        // From http://stackoverflow.com/questions/2208690/invoke-notifyicons-context-menu
        private void notifyIcon_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                var mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e) { ShowPopup(popup.Label, popup.Value); }
        #endregion

        #region Context menu
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e) {
            e.Cancel = false;

            ShowContextMenu();
        }

        private void popupMenuItem_Click(object sender, EventArgs e) { ShowPopup(popup.Label, popup.Value); }

        private void settingsMenuItem_Click(object sender, EventArgs e) { ShowSettingsForm(); }

        private void exitMenuItem_Click(object sender, EventArgs e) {
            Exit();
        }
        #endregion

        #region Child forms
        private void popup_Closed(object sender, EventArgs e) { popup = null; }

        private void settingsForm_Closed(object sender, EventArgs e) { settingsForm = null; }
        #endregion

        #endregion
    }
}
