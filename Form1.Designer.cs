namespace IOS_Peak
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grgDeviceConnect = new GroupBox();
            btnDisconnect = new Button();
            lblDeviceConnected = new Label();
            txtDeviceIP = new TextBox();
            btnDeviceConnect = new Button();
            grpListBundles = new GroupBox();
            btnFridaRemote = new Button();
            btnObjection = new Button();
            lblPid = new Label();
            btnGetPid = new Button();
            comboBoxListApps = new ComboBox();
            btnListApps = new Button();
            grpWorkingDirectory = new GroupBox();
            lblWorkingDirectory = new Label();
            btnWorkingDirectory = new Button();
            btnWorkingDirSelect = new Button();
            grpRespringUI = new GroupBox();
            btnRespring = new Button();
            grpScreenshots = new GroupBox();
            btnScreenshots = new Button();
            grgDeviceConnect.SuspendLayout();
            grpListBundles.SuspendLayout();
            grpWorkingDirectory.SuspendLayout();
            grpRespringUI.SuspendLayout();
            grpScreenshots.SuspendLayout();
            SuspendLayout();
            // 
            // grgDeviceConnect
            // 
            grgDeviceConnect.Controls.Add(btnDisconnect);
            grgDeviceConnect.Controls.Add(lblDeviceConnected);
            grgDeviceConnect.Controls.Add(txtDeviceIP);
            grgDeviceConnect.Controls.Add(btnDeviceConnect);
            grgDeviceConnect.Location = new Point(1158, 26);
            grgDeviceConnect.Name = "grgDeviceConnect";
            grgDeviceConnect.Size = new Size(400, 146);
            grgDeviceConnect.TabIndex = 0;
            grgDeviceConnect.TabStop = false;
            grgDeviceConnect.Text = "Device Connect";
            grgDeviceConnect.Visible = false;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(252, 73);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(142, 29);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // lblDeviceConnected
            // 
            lblDeviceConnected.AutoSize = true;
            lblDeviceConnected.Location = new Point(20, 102);
            lblDeviceConnected.Name = "lblDeviceConnected";
            lblDeviceConnected.Size = new Size(9, 20);
            lblDeviceConnected.TabIndex = 2;
            lblDeviceConnected.Text = "\r\n";
            // 
            // txtDeviceIP
            // 
            txtDeviceIP.Location = new Point(6, 28);
            txtDeviceIP.Name = "txtDeviceIP";
            txtDeviceIP.Size = new Size(240, 27);
            txtDeviceIP.TabIndex = 1;
            txtDeviceIP.TextChanged += txtDeviceIP_TextChanged;
            // 
            // btnDeviceConnect
            // 
            btnDeviceConnect.Location = new Point(252, 26);
            btnDeviceConnect.Name = "btnDeviceConnect";
            btnDeviceConnect.Size = new Size(142, 29);
            btnDeviceConnect.TabIndex = 0;
            btnDeviceConnect.Text = "Connect to iPhone";
            btnDeviceConnect.UseVisualStyleBackColor = true;
            btnDeviceConnect.Click += btnDeviceConnect_Click;
            // 
            // grpListBundles
            // 
            grpListBundles.Controls.Add(btnFridaRemote);
            grpListBundles.Controls.Add(btnObjection);
            grpListBundles.Controls.Add(lblPid);
            grpListBundles.Controls.Add(btnGetPid);
            grpListBundles.Controls.Add(comboBoxListApps);
            grpListBundles.Controls.Add(btnListApps);
            grpListBundles.Location = new Point(12, 152);
            grpListBundles.Name = "grpListBundles";
            grpListBundles.Size = new Size(1115, 125);
            grpListBundles.TabIndex = 1;
            grpListBundles.TabStop = false;
            grpListBundles.Text = "List Bundles";
            grpListBundles.Visible = false;
            // 
            // btnFridaRemote
            // 
            btnFridaRemote.Location = new Point(415, 81);
            btnFridaRemote.Name = "btnFridaRemote";
            btnFridaRemote.Size = new Size(222, 29);
            btnFridaRemote.TabIndex = 5;
            btnFridaRemote.Text = "Connect Remote Frida";
            btnFridaRemote.UseVisualStyleBackColor = true;
            btnFridaRemote.Click += btnFridaRemote_Click;
            // 
            // btnObjection
            // 
            btnObjection.Location = new Point(672, 81);
            btnObjection.Name = "btnObjection";
            btnObjection.Size = new Size(214, 29);
            btnObjection.TabIndex = 4;
            btnObjection.Text = "Open Objection with PID";
            btnObjection.UseVisualStyleBackColor = true;
            btnObjection.Click += btnObjection_Click;
            // 
            // lblPid
            // 
            lblPid.AutoSize = true;
            lblPid.Location = new Point(132, 85);
            lblPid.Name = "lblPid";
            lblPid.Size = new Size(150, 20);
            lblPid.TabIndex = 3;
            lblPid.Text = "PID of Selected App: ";
            // 
            // btnGetPid
            // 
            btnGetPid.Location = new Point(18, 81);
            btnGetPid.Name = "btnGetPid";
            btnGetPid.Size = new Size(94, 29);
            btnGetPid.TabIndex = 2;
            btnGetPid.Text = "Get PID";
            btnGetPid.UseVisualStyleBackColor = true;
            btnGetPid.Click += btnGetPid_Click;
            // 
            // comboBoxListApps
            // 
            comboBoxListApps.FormattingEnabled = true;
            comboBoxListApps.Location = new Point(118, 32);
            comboBoxListApps.Name = "comboBoxListApps";
            comboBoxListApps.Size = new Size(969, 28);
            comboBoxListApps.TabIndex = 1;
            // 
            // btnListApps
            // 
            btnListApps.Location = new Point(18, 31);
            btnListApps.Name = "btnListApps";
            btnListApps.Size = new Size(94, 29);
            btnListApps.TabIndex = 0;
            btnListApps.Text = "List Apps";
            btnListApps.UseVisualStyleBackColor = true;
            btnListApps.Click += btnListApps_Click;
            // 
            // grpWorkingDirectory
            // 
            grpWorkingDirectory.Controls.Add(lblWorkingDirectory);
            grpWorkingDirectory.Controls.Add(btnWorkingDirectory);
            grpWorkingDirectory.Controls.Add(btnWorkingDirSelect);
            grpWorkingDirectory.Location = new Point(12, 12);
            grpWorkingDirectory.Name = "grpWorkingDirectory";
            grpWorkingDirectory.Size = new Size(905, 102);
            grpWorkingDirectory.TabIndex = 2;
            grpWorkingDirectory.TabStop = false;
            grpWorkingDirectory.Text = "Working Directory";
            // 
            // lblWorkingDirectory
            // 
            lblWorkingDirectory.AutoSize = true;
            lblWorkingDirectory.Location = new Point(16, 69);
            lblWorkingDirectory.Name = "lblWorkingDirectory";
            lblWorkingDirectory.Size = new Size(188, 20);
            lblWorkingDirectory.TabIndex = 2;
            lblWorkingDirectory.Text = "Current Working Directory: \r\n";
            // 
            // btnWorkingDirectory
            // 
            btnWorkingDirectory.Location = new Point(154, 26);
            btnWorkingDirectory.Name = "btnWorkingDirectory";
            btnWorkingDirectory.Size = new Size(128, 29);
            btnWorkingDirectory.TabIndex = 1;
            btnWorkingDirectory.Text = "Open Folder";
            btnWorkingDirectory.UseVisualStyleBackColor = true;
            btnWorkingDirectory.Click += btnWorkingDirectory_Click;
            // 
            // btnWorkingDirSelect
            // 
            btnWorkingDirSelect.Location = new Point(6, 26);
            btnWorkingDirSelect.Name = "btnWorkingDirSelect";
            btnWorkingDirSelect.Size = new Size(126, 29);
            btnWorkingDirSelect.TabIndex = 0;
            btnWorkingDirSelect.Text = "Choose Folder";
            btnWorkingDirSelect.UseVisualStyleBackColor = true;
            btnWorkingDirSelect.Click += btnWorkingDirSelect_Click;
            // 
            // grpRespringUI
            // 
            grpRespringUI.Controls.Add(btnRespring);
            grpRespringUI.Location = new Point(12, 304);
            grpRespringUI.Name = "grpRespringUI";
            grpRespringUI.Size = new Size(208, 111);
            grpRespringUI.TabIndex = 3;
            grpRespringUI.TabStop = false;
            grpRespringUI.Text = "Respring UI";
            grpRespringUI.Visible = false;
            // 
            // btnRespring
            // 
            btnRespring.Location = new Point(30, 47);
            btnRespring.Name = "btnRespring";
            btnRespring.Size = new Size(148, 29);
            btnRespring.TabIndex = 0;
            btnRespring.Text = "Kill SpringBoard";
            btnRespring.UseVisualStyleBackColor = true;
            btnRespring.Click += btnRespring_Click;
            // 
            // grpScreenshots
            // 
            grpScreenshots.Controls.Add(btnScreenshots);
            grpScreenshots.Location = new Point(249, 304);
            grpScreenshots.Name = "grpScreenshots";
            grpScreenshots.Size = new Size(219, 111);
            grpScreenshots.TabIndex = 4;
            grpScreenshots.TabStop = false;
            grpScreenshots.Text = "Screenshots";
            grpScreenshots.Visible = false;
            // 
            // btnScreenshots
            // 
            btnScreenshots.Location = new Point(43, 50);
            btnScreenshots.Name = "btnScreenshots";
            btnScreenshots.Size = new Size(94, 29);
            btnScreenshots.TabIndex = 0;
            btnScreenshots.Text = "Pull";
            btnScreenshots.UseVisualStyleBackColor = true;
            btnScreenshots.Click += btnScreenshots_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1608, 692);
            Controls.Add(grpScreenshots);
            Controls.Add(grpRespringUI);
            Controls.Add(grpWorkingDirectory);
            Controls.Add(grpListBundles);
            Controls.Add(grgDeviceConnect);
            Name = "Form1";
            Text = "IOS";
            grgDeviceConnect.ResumeLayout(false);
            grgDeviceConnect.PerformLayout();
            grpListBundles.ResumeLayout(false);
            grpListBundles.PerformLayout();
            grpWorkingDirectory.ResumeLayout(false);
            grpWorkingDirectory.PerformLayout();
            grpRespringUI.ResumeLayout(false);
            grpScreenshots.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grgDeviceConnect;
        private Label lblDeviceConnected;
        private TextBox txtDeviceIP;
        private Button btnDeviceConnect;
        private GroupBox grpListBundles;
        private ComboBox comboBoxListApps;
        private Button btnListApps;
        private Button btnDisconnect;
        private GroupBox grpWorkingDirectory;
        private Label lblWorkingDirectory;
        private Button btnWorkingDirectory;
        private Button btnWorkingDirSelect;
        private GroupBox grpRespringUI;
        private Button btnRespring;
        private Label lblPid;
        private Button btnGetPid;
        private Button btnObjection;
        private Button btnFridaRemote;
        private GroupBox grpScreenshots;
        private Button btnScreenshots;
    }
}
