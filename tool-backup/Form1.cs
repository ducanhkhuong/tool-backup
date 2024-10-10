using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using System.IO;
using tool_backup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace tool_backup
{
    public partial class Form1 : Form
    {
        
        private SSHClientManager sshManager_key;
        private SSHClientManager sshManager_notkey;
        private SCPClientManager scpManager_key;
        private SCPClientManager scpManager_notkey;
        private LogClientManager logClientManager;
        private CancellationTokenSource cancellationTokenSource;
        private NetworkScanner   networkScanner;
        private System.Windows.Forms.Timer logUpdateTimer;


        string logFileName = "tool-backup.log";
        string logFilePath = "";
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        

        string username;
        string password;
        string ip;
        string passphrase;
        string keyFilePath ;
        int switchtype = 0;

        public Form1()
        {
            InitializeComponent();
            logFilePath      = Path.Combine(currentDirectory, logFileName);
            logUpdateTimer   = new System.Windows.Forms.Timer();
            networkScanner   = new NetworkScanner();
            logClientManager = new LogClientManager(logFilePath);
            logUpdateTimer.Interval = 100;
            logUpdateTimer.Tick += timer1_Tick;
            logUpdateTimer.Start();
        }

        void autoload_disconected()
        {
            ConnectDevice_Status.BackColor = Color.Red;
            ConnectDevice_CheckKeyfile.Checked = false;
            ConnectDevice_KeyFile.Enabled = false;
            ConnectDevice_Passphare.Enabled = false;
        }

        void autoload_connected()
        {
            ConnectDevice_Status.BackColor = Color.Green;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoload_disconected();
        }


        //CHECK-TYPE-SSH(KEY OR NOT KEY)
        private void ConnectDevice_CheckKeyfile_CheckedChanged(object sender, EventArgs e)
        {
            string key;
            switchtype = 0;
            if (ConnectDevice_CheckKeyfile.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Select a File",
                    Filter = "All Files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                        key = openFileDialog.FileName;
                        ConnectDevice_KeyFile.Text = key;
                }
                ConnectDevice_KeyFile.Enabled   = true;
                ConnectDevice_Passphare.Enabled = true;
                ConnectDevice_Passworld.Enabled = false;
                switchtype++;
            }
            else
            {
                ConnectDevice_KeyFile.Enabled   = false;
                ConnectDevice_Passphare.Enabled = false;
                ConnectDevice_Passworld.Enabled = true;
                switchtype++;
            }
            Console.WriteLine(switchtype);
            if(switchtype == 100)
            {
                switchtype = 0;
            }
        }

        //SSH
        private void ConnectDevice_SSH_Click(object sender, EventArgs e)
        {
            username    = ConnectDevice_Username .Text.Trim();
            password    = ConnectDevice_Passworld.Text.Trim();
            ip          = ConnectDevice_Ip_index1.Text.Trim();
            passphrase  = ConnectDevice_Passphare.Text.Trim();
            keyFilePath = ConnectDevice_KeyFile  .Text.Trim();

            //key
            sshManager_key = new SSHClientManager(ip, username, keyFilePath, passphrase);
            if (sshManager_key.Connect() && switchtype%2!=0)
            {
                try
                {
                    sshManager_key.Connect();
                    Log.Information($"SSH successfully with :\nUser : {username}\nIP : {ip}\nKeyFilePath : {keyFilePath}\nPassphrase : {passphrase}\nLogfile : {logFilePath}");
                    autoload_connected();
                }
                catch (Exception ex)
                {
                    Log.Error("SSH connection failed: " + ex.Message);
                }
            }


            //notkey
            sshManager_notkey = new SSHClientManager(ip, username, password);
            if (sshManager_notkey.Connect() && switchtype % 2 == 0)
            {
                try
                {
                    sshManager_notkey.Connect();
                    Log.Information($"SSH successfully with :\nUser : {username}\nIP : {ip}\nPassword : {password}\nLogfile : {logFilePath}");
                    autoload_connected();
                }
                catch (Exception ex)
                {
                    Log.Error("SSH connection failed: " + ex.Message);
                }
            }
        }


        //EXIT SSH
        private void ConnectDevice_ExitSSH_Click(object sender, EventArgs e)
        {
            //exit not key
            if (sshManager_notkey != null && sshManager_notkey.IsConnected && switchtype % 2 == 0)
            {
                autoload_disconected();
                sshManager_notkey.Disconnect();
                Log.Information("SSH: disconnected connection with " + username + "@" + ip);
            }

            //exit key
            if (sshManager_key    != null && sshManager_key.IsConnected && switchtype % 2 != 0)
            {
                autoload_disconected();
                sshManager_key.Disconnect();
                Log.Information("SSH: disconnected connection with " + username + "@" + ip);
            }
            //clear Log-app
            logClientManager.ClearLog(Log_app);
        }


        //CMD OUTPUT
        private void check_cmd_Click(object sender, EventArgs e)
        {
            string commandText = "tail -f /home/ducanhkhuong/hc_config.json";
            sshManager_notkey.ExecuteCommand(commandText, message =>
                          {
                                Log_cmd.AppendText(message + "\n");
                          });
        }



        //CHECK-LOG-APP
        private void timer1_Tick(object sender, EventArgs e)
        {
            //read Log-App
            logClientManager.ReadLog(Log_app);
        }



        //DOWNLOAD FILE
        private void SCP_Download_Click(object sender, EventArgs e)
        {
            //not handle
            string remoteFilePath = @"";
            string localFilePath  = @"";
            //key
            if (switchtype == 1)
            {
                scpManager_key = new SCPClientManager(ip, username, keyFilePath, passphrase);
                if (scpManager_key.DownloadFile(remoteFilePath, localFilePath))
                    Log.Information("SCP : downloaded successfully!");
            }//not key
            else
            {
                scpManager_notkey = new SCPClientManager(ip, username, password);
                if (scpManager_notkey.DownloadFile(remoteFilePath, localFilePath))
                    Log.Information("SCP : downloaded successfully!");
            }
        }


        //UPLOAD FILE
        private void SCP_Upload_Click(object sender, EventArgs e)
        {
            string localFilePath =  @"";
            string remoteFilePath = @"/testtool/noise.txt";

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a File",
                Filter = "All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                localFilePath = openFileDialog.FileName;
            }

            if (switchtype % 2 != 0)
            {
                scpManager_key = new SCPClientManager(ip, username, keyFilePath, passphrase);
                if (scpManager_key.UploadFile(localFilePath, remoteFilePath))
                    Log.Information("SCP : uploaded successfully with key!");
            }
            if (switchtype % 2 == 0)
            {
                scpManager_notkey = new SCPClientManager(ip, username, password);
                if (scpManager_notkey.UploadFile(localFilePath, remoteFilePath))
                    Log.Information("SCP : uploaded successfully no key");
            }
        }





        //SCAN IP & NETWORK
        private async void Scan_btn_network_Click(object sender, EventArgs e)
        {
            Log_network.Clear();
            Scan_btn_network.Enabled = false;
            string ipRange = Scan_IP_textbox.Text.Trim();
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            await Task.Run(() => networkScanner.ScanNetworks(LogMessage, ipRange, cancellationToken));
            Scan_btn_network.Enabled = true;
        }

        private void LogMessage(string message)
        {
            if (Log_network.InvokeRequired)
            {
                Log_network.Invoke(new Action<string>(LogMessage), message);
            }
            else
            {
                Log_network.AppendText(message + Environment.NewLine);
                Log_network.SelectionStart = Log_network.Text.Length;
                Log_network.ScrollToCaret();
            }
        }

        private void Stop_btn_network_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }




        //EXIT FORM
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sshManager_key != null && sshManager_key.IsConnected)
            {
                sshManager_key.Disconnect();
            }

            if (sshManager_notkey != null && sshManager_notkey.IsConnected)
            {
                sshManager_notkey.Disconnect();
            }
        }
    }
}
