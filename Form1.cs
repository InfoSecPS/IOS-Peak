using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
using System.Net;
using WinSCP;
using static System.Windows.Forms.DataFormats;

namespace IOS_Peak
{
    public partial class Form1 : Form
    {
        private SshClient sshClient; // Declared at the class level
        private string pid; // Declare pid variable   
        private string storedPassword;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtDeviceIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeviceConnect_Click(object sender, EventArgs e)
        {
            string ipAddress = txtDeviceIP.Text;

            if (!string.IsNullOrEmpty(ipAddress))
            {
                PromptForPasswordAndConnect(ipAddress);
            }
            else
            {
                MessageBox.Show("Please enter an IP address.");
            }
        }
        private void PromptForPasswordAndConnect(string ipAddress)
        {
            // Show a prompt to enter the password
            storedPassword = Prompt.ShowDialog("Enter Root Password", "Password");

            if (!string.IsNullOrEmpty(storedPassword))
            {
                ConnectToDevice(ipAddress, storedPassword);
            }
            else
            {
                MessageBox.Show("Password cannot be empty.");
            }
        }
        // Custom dialog to prompt for password
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 200,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 200 };
                System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void ConnectToDevice(string ipAddress, string password)
        {
            try
            {
                sshClient = new SshClient(ipAddress, "root", storedPassword);
                sshClient.Connect();
                if (sshClient.IsConnected)
                {
                    // Execute command and display output
                    var commandResult = sshClient.RunCommand("uname -n && uname -m");
                    if (!string.IsNullOrEmpty(commandResult.Result))
                    {
                        lblDeviceConnected.Text = "Connected to : " + commandResult.Result;
                        grpListBundles.Visible = true;
                        grpRespringUI.Visible = true;
                        grpScreenshots.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to connect to the device.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the device: {ex.Message}");
            }
        }

        private void btnListApps_Click(object sender, EventArgs e)
        {
            if (sshClient != null && sshClient.IsConnected)
            {
                ListInstalledApps();
            }
            else
            {
                MessageBox.Show("SSH connection is not established.");
            }
        }
        public class AppInfo
        {
            public string BundleId { get; set; }
            public string AppName { get; set; }

            public AppInfo(string bundleId, string appName)
            {
                BundleId = bundleId;
                AppName = appName;
            }

            public override string ToString()
            {
                return $"{BundleId} {AppName}";
            }
        }

        private void ListInstalledApps()
        {
            try
            {
                var commandResult = sshClient.RunCommand("find /var/containers/Bundle/Application/ -maxdepth 2 -name '*.app' | awk -F \"/\" '{print $6 \" \" substr($0, index($0,$7))}'");
                if (!string.IsNullOrEmpty(commandResult.Result))
                {
                    string[] lines = commandResult.Result.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(new[] { ' ' }, 2);
                        if (parts.Length == 2)
                        {
                            string bundleId = parts[0];
                            string appName = parts[1];
                            comboBoxListApps.Items.Add(new AppInfo(bundleId, appName));
                        }
                    }
                    MessageBox.Show("Listed installed apps successfully.");
                }
                else
                {
                    MessageBox.Show("No installed apps found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error listing installed apps: {ex.Message}");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (sshClient != null && sshClient.IsConnected)
            {
                sshClient.Disconnect();
                MessageBox.Show("SSH connection closed successfully.");
                lblDeviceConnected.Text = "";
                txtDeviceIP.Text = "";
                grpListBundles.Visible = false;
            }
            else
            {
                MessageBox.Show("SSH connection is not established.");
            }
        }
        private string workingDirectory = ""; // Variable to store the selected folder path
        private void btnWorkingDirSelect_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Store the selected folder path in the variable
                    workingDirectory = folderBrowserDialog.SelectedPath;
                    lblWorkingDirectory.Text = "";
                    lblWorkingDirectory.Text += workingDirectory;
                    btnWorkingDirectory.Visible = true;
                    grgDeviceConnect.Visible = true;

                }
            }

        }

        private void btnWorkingDirectory_Click(object sender, EventArgs e)
        {
            string pathToFolder = workingDirectory;
            System.Diagnostics.Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", pathToFolder);
        }

        private void btnRespring_Click(object sender, EventArgs e)
        {
            sshClient.RunCommand("killall -HUP SpringBoard");
        }
        private string GetPID(string bundleId)
        {
            try
            {
                // Execute command to find PID of the app
                var commandResult = sshClient.RunCommand($"ps aux | grep -e '{bundleId}' | grep -v grep | awk '{{print $2}}'");
                return commandResult.Result.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting PID: {ex.Message}");
                return null;
            }
        }
        private void btnGetPid_Click(object sender, EventArgs e)
        {
            if (comboBoxListApps.SelectedItem != null)
            {
                var selectedApp = (AppInfo)comboBoxListApps.SelectedItem;
                pid = GetPID(selectedApp.BundleId);

                if (!string.IsNullOrEmpty(pid))
                {
                    lblPid.Text += "";
                    lblPid.Text += pid;
                }
                else
                {
                    MessageBox.Show($"App with bundle ID {selectedApp.BundleId} is not running.");
                }
            }
            else
            {
                MessageBox.Show("Please select an app from the list.");
            }
        }

        private void btnObjection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pid))
            {
                MessageBox.Show("No PID available. Please get the PID first.");
                return;
            }

            // Command to run
            string command = $"objection --network -g {pid} explore";

            // Start a new process to execute the command
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe", // Command prompt
                Arguments = $"/k {command}", // Run command and keep window open
                UseShellExecute = false, // Do not use OS shell
                CreateNoWindow = false, // Do not create window
                RedirectStandardOutput = false, // Do not redirect standard output
                RedirectStandardError = false // Do not redirect standard error
            };

            Process process = new Process { StartInfo = startInfo };

            try
            {
                // Start the process
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting command prompt: {ex.Message}");
            }

        }

        private void btnFridaRemote_Click(object sender, EventArgs e)
        {
            int localPort = 27042;
            int remotePort = 27042;

            try
            {
                if (sshClient == null || !sshClient.IsConnected)
                {
                    MessageBox.Show("SSH connection is not established.");
                    return;
                }

                // Check if port forward is already established for the local port
                bool portForwardExists = false;
                foreach (var forwardedPort in sshClient.ForwardedPorts)
                {
                    if (forwardedPort is ForwardedPortLocal && ((ForwardedPortLocal)forwardedPort).Port == localPort)
                    {
                        portForwardExists = true;
                        break;
                    }
                }

                if (!portForwardExists)
                {
                    // Establish port forwarding
                    var portForward = new ForwardedPortLocal("127.0.0.1", (uint)localPort, "127.0.0.1", (uint)remotePort);
                    sshClient.AddForwardedPort(portForward);
                    portForward.Start();

                    Console.WriteLine($"Port forward established: localhost:{localPort} -> localhost:{remotePort}");
                    MessageBox.Show($"Port forward established: localhost:{localPort} -> localhost:{remotePort}");
                }
                else
                {
                    MessageBox.Show($"Port forward already established: localhost:{localPort} -> localhost:{remotePort}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnScreenshots_Click(object sender, EventArgs e)
        {
            // Replace these values with your actual parameters
            string ipAddress = txtDeviceIP.Text;

            try
            {
                // Ensure workingDirectory ends with a directory separator
                if (!workingDirectory.EndsWith("\\"))
                {
                    workingDirectory += "\\";
                }
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = ipAddress,
                    UserName = "root",
                    Password = storedPassword,
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                    // Add any other authentication options as needed
                };
                sessionOptions.AddRawSettings("LogPath", @"C:\WorkingDirectory\File.log");

                using (WinSCP.Session session = new WinSCP.Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Transfer files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary; // Use binary mode for image files

                    // Download all PNG files from the remote directory to the local working directory
                    TransferOperationResult transferResult = session.GetFiles("/var/mobile/Media/DCIM/100APPLE/*.PNG", workingDirectory, false, transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    // Print out results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        MessageBox.Show($"Download of {transfer.FileName} succeeded");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }        
    }
}
