namespace UrlCheck {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.animationGroup = new System.Windows.Forms.GroupBox();
            this.displayDurationValue = new System.Windows.Forms.NumericUpDown();
            this.displayDurationLabel = new System.Windows.Forms.Label();
            this.animIntervalValue = new System.Windows.Forms.NumericUpDown();
            this.animIntervalLabel = new System.Windows.Forms.Label();
            this.pollingGroup = new System.Windows.Forms.GroupBox();
            this.displayPathTextBox = new System.Windows.Forms.TextBox();
            this.labelPathLabel = new System.Windows.Forms.Label();
            this.checkPathTextBox = new System.Windows.Forms.TextBox();
            this.valuePathLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.pollIntervalValue = new System.Windows.Forms.NumericUpDown();
            this.pollIntervalLabel = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.animationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDurationValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animIntervalValue)).BeginInit();
            this.pollingGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollIntervalValue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.cancelButton);
            this.panel.Controls.Add(this.okButton);
            this.panel.Controls.Add(this.animationGroup);
            this.panel.Controls.Add(this.pollingGroup);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(284, 262);
            this.panel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(116, 227);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(197, 227);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // animationGroup
            // 
            this.animationGroup.Controls.Add(this.displayDurationValue);
            this.animationGroup.Controls.Add(this.displayDurationLabel);
            this.animationGroup.Controls.Add(this.animIntervalValue);
            this.animationGroup.Controls.Add(this.animIntervalLabel);
            this.animationGroup.Location = new System.Drawing.Point(12, 140);
            this.animationGroup.Name = "animationGroup";
            this.animationGroup.Size = new System.Drawing.Size(260, 78);
            this.animationGroup.TabIndex = 1;
            this.animationGroup.TabStop = false;
            this.animationGroup.Text = "&Animation";
            // 
            // displayDurationValue
            // 
            this.displayDurationValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.displayDurationValue.Location = new System.Drawing.Point(151, 45);
            this.displayDurationValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.displayDurationValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.displayDurationValue.Name = "displayDurationValue";
            this.displayDurationValue.Size = new System.Drawing.Size(103, 20);
            this.displayDurationValue.TabIndex = 3;
            this.displayDurationValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // displayDurationLabel
            // 
            this.displayDurationLabel.AutoSize = true;
            this.displayDurationLabel.Location = new System.Drawing.Point(6, 47);
            this.displayDurationLabel.Name = "displayDurationLabel";
            this.displayDurationLabel.Size = new System.Drawing.Size(119, 13);
            this.displayDurationLabel.TabIndex = 2;
            this.displayDurationLabel.Text = "Display &for (in seconds):";
            // 
            // animIntervalValue
            // 
            this.animIntervalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.animIntervalValue.Location = new System.Drawing.Point(151, 19);
            this.animIntervalValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.animIntervalValue.Name = "animIntervalValue";
            this.animIntervalValue.Size = new System.Drawing.Size(103, 20);
            this.animIntervalValue.TabIndex = 1;
            this.animIntervalValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // animIntervalLabel
            // 
            this.animIntervalLabel.AutoSize = true;
            this.animIntervalLabel.Location = new System.Drawing.Point(6, 21);
            this.animIntervalLabel.Name = "animIntervalLabel";
            this.animIntervalLabel.Size = new System.Drawing.Size(112, 13);
            this.animIntervalLabel.TabIndex = 0;
            this.animIntervalLabel.Text = "D&raw speed (in msec):";
            // 
            // pollingGroup
            // 
            this.pollingGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pollingGroup.Controls.Add(this.displayPathTextBox);
            this.pollingGroup.Controls.Add(this.labelPathLabel);
            this.pollingGroup.Controls.Add(this.checkPathTextBox);
            this.pollingGroup.Controls.Add(this.valuePathLabel);
            this.pollingGroup.Controls.Add(this.urlTextBox);
            this.pollingGroup.Controls.Add(this.urlLabel);
            this.pollingGroup.Controls.Add(this.pollIntervalValue);
            this.pollingGroup.Controls.Add(this.pollIntervalLabel);
            this.pollingGroup.Location = new System.Drawing.Point(12, 12);
            this.pollingGroup.Name = "pollingGroup";
            this.pollingGroup.Size = new System.Drawing.Size(260, 122);
            this.pollingGroup.TabIndex = 0;
            this.pollingGroup.TabStop = false;
            this.pollingGroup.Text = "&Polling";
            // 
            // displayPathTextBox
            // 
            this.displayPathTextBox.Location = new System.Drawing.Point(115, 94);
            this.displayPathTextBox.Name = "displayPathTextBox";
            this.displayPathTextBox.Size = new System.Drawing.Size(139, 20);
            this.displayPathTextBox.TabIndex = 7;
            // 
            // labelPathLabel
            // 
            this.labelPathLabel.AutoSize = true;
            this.labelPathLabel.Location = new System.Drawing.Point(6, 97);
            this.labelPathLabel.Name = "labelPathLabel";
            this.labelPathLabel.Size = new System.Drawing.Size(96, 13);
            this.labelPathLabel.TabIndex = 6;
            this.labelPathLabel.Text = "Json path for &label:";
            // 
            // checkPathTextBox
            // 
            this.checkPathTextBox.Location = new System.Drawing.Point(115, 68);
            this.checkPathTextBox.Name = "checkPathTextBox";
            this.checkPathTextBox.Size = new System.Drawing.Size(139, 20);
            this.checkPathTextBox.TabIndex = 5;
            // 
            // valuePathLabel
            // 
            this.valuePathLabel.AutoSize = true;
            this.valuePathLabel.Location = new System.Drawing.Point(6, 71);
            this.valuePathLabel.Name = "valuePathLabel";
            this.valuePathLabel.Size = new System.Drawing.Size(100, 13);
            this.valuePathLabel.TabIndex = 4;
            this.valuePathLabel.Text = "Json path for &value:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(35, 42);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(219, 20);
            this.urlTextBox.TabIndex = 3;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(6, 45);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(23, 13);
            this.urlLabel.TabIndex = 2;
            this.urlLabel.Text = "&Url:";
            // 
            // pollIntervalValue
            // 
            this.pollIntervalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pollIntervalValue.Location = new System.Drawing.Point(151, 19);
            this.pollIntervalValue.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.pollIntervalValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pollIntervalValue.Name = "pollIntervalValue";
            this.pollIntervalValue.Size = new System.Drawing.Size(103, 20);
            this.pollIntervalValue.TabIndex = 1;
            this.pollIntervalValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pollIntervalLabel
            // 
            this.pollIntervalLabel.AutoSize = true;
            this.pollIntervalLabel.Location = new System.Drawing.Point(6, 21);
            this.pollIntervalLabel.Name = "pollIntervalLabel";
            this.pollIntervalLabel.Size = new System.Drawing.Size(138, 13);
            this.pollIntervalLabel.TabIndex = 0;
            this.pollIntervalLabel.Text = "Polling &interval (in seconds):";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "UrlCheck Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel.ResumeLayout(false);
            this.animationGroup.ResumeLayout(false);
            this.animationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDurationValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animIntervalValue)).EndInit();
            this.pollingGroup.ResumeLayout(false);
            this.pollingGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollIntervalValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox pollingGroup;
        private System.Windows.Forms.NumericUpDown pollIntervalValue;
        private System.Windows.Forms.Label pollIntervalLabel;
        private System.Windows.Forms.GroupBox animationGroup;
        private System.Windows.Forms.NumericUpDown animIntervalValue;
        private System.Windows.Forms.Label animIntervalLabel;
        private System.Windows.Forms.TextBox displayPathTextBox;
        private System.Windows.Forms.Label labelPathLabel;
        private System.Windows.Forms.TextBox checkPathTextBox;
        private System.Windows.Forms.Label valuePathLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown displayDurationValue;
        private System.Windows.Forms.Label displayDurationLabel;
    }
}