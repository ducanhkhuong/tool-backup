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
using Newtonsoft.Json;

namespace tool_backup
{
    public partial class Form1 : Form
    {
        
        private SSHClientManager    sshManager_key;
        private SCPClientManager    scpManager_key;
        private LogManager          logManager;
        private NetworkManager      networkManager;
        private OptionManager       optionManager;
        private System.Windows.Forms.Timer logUpdateTimer;


        string logFileName = "tool-backup.log";
        string logFilePath = "";
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;


        string username;
        string ip;
        string passphrase;
        string keyFilePath ;


        public Form1()
        {
            InitializeComponent();
            logFilePath      = Path.Combine(currentDirectory, logFileName);
            logUpdateTimer   = new System.Windows.Forms.Timer();
            networkManager   = new NetworkManager(dataGridView1);
            logManager       = new LogManager(logFilePath);
            optionManager    = new OptionManager();

            logUpdateTimer.Interval = 50;
            logUpdateTimer.Tick += timer1_Tick;
            logUpdateTimer.Start();

            optionManager.AddItem("MT7688", "MT7688");
            optionManager.AddItem("AI-V2",  "AI-V2");
            optionManager.AddItem("AI-V3",  "AI-V3");
            comboBoxOptions.DataSource = optionManager.GetItems();
        }

        void autoload_disconected()
        {
            ConnectDevice_Status.BackColor = Color.Red;
            ConnectDevice_CheckKeyfile.Checked = false;
            ConnectDevice_KeyFile.Enabled      = false;
            ConnectDevice_Passphare.Enabled    = false;
        }

        void autoload_connected()
        {
            ConnectDevice_Status.BackColor = Color.Green;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoload_disconected();
            
            //CHECK JSON
            //JsonManager jsonReader = new JsonManager();
            //jsonReader.ConfigReader("setting.json");
            //try
            //{
            //    Config config = jsonReader.ReadConfig();
            //    Console.WriteLine($"Username: {config.AIV2.username}\n" +
            //                    $"Path Home : {config.AIV2.pathhome}\n" +
            //                    $"Keyfile   : {config.AIV2.key}\n"      +
            //                    $"Path DB   : {config.AIV2.pathDB}\n"   +
            //                    $"Path Log  : {config.AIV2.pathlog}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Lỗi: {ex.Message}");
            //}
            //
        }

        //CHECK-OPTION
        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem is ComboBoxItem selectedItem)
            {
                string value = optionManager.GetSelectedValue(selectedItem);
                Console.WriteLine(value);
            }
        }

        //CHECK-TYPE-SSH(KEY)
        private void ConnectDevice_CheckKeyfile_CheckedChanged(object sender, EventArgs e)
        {
            string key;
            if (ConnectDevice_CheckKeyfile.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title =  "Select a File",
                    Filter = "All Files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                        key = openFileDialog.FileName;
                        ConnectDevice_KeyFile.Text = key;
                }
                ConnectDevice_KeyFile.Enabled   = true;
                ConnectDevice_Passphare.Enabled = true;
            }
            else
            {
                ConnectDevice_KeyFile.Enabled   = false;
                ConnectDevice_Passphare.Enabled = false;
            }
        }

        //SSH
        private void ConnectDevice_SSH_Click(object sender, EventArgs e)
        {
            username    = ConnectDevice_Username .Text.Trim();
            ip          = ConnectDevice_Ip_index1.Text.Trim();
            passphrase  = ConnectDevice_Passphare.Text.Trim();
            keyFilePath = ConnectDevice_KeyFile  .Text.Trim();

            sshManager_key = new SSHClientManager(ip, username, keyFilePath, passphrase);
            if (sshManager_key.Connect())
            {
                try
                {
                    sshManager_key.Connect();
                    Log.Information($"SSH successfully with :\nUser : {username}\nIP : {ip}\nKeyFilePath : {keyFilePath}\nPassphrase : {passphrase}");
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
            if (sshManager_key    != null && sshManager_key.IsConnected)
            {
                autoload_disconected();
                sshManager_key.Disconnect();
                Log.Information("SSH: disconnected connection with " + username + "@" + ip);
            }
            logManager.ClearLog(Log_app);
        }


        //CMD INPUT-OUTPUT
        private void check_cmd_Click(object sender, EventArgs e)
        {
            string commandText = cmd_input.Text.Trim();
            sshManager_key.ExecuteCommand(commandText, message =>
                          {
                                Log_cmd.AppendText(message + "\n");
                          });
        }



        //CHECK-LOG-APP
        private void timer1_Tick(object sender, EventArgs e)
        {   //logManager.ClearLog(Log_app);
            logManager.ReadLog(Log_app);              
        }



        //DOWNLOAD FILE
        private void SCP_Download_Click(object sender, EventArgs e)
        {
            //not handle
            string remoteFilePath = @"";
            string localFilePath  = @"";
            //key
            scpManager_key = new SCPClientManager(ip, username, keyFilePath, passphrase);
            if (scpManager_key.DownloadFile(remoteFilePath, localFilePath))
            {
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
            //key
            scpManager_key = new SCPClientManager(ip, username, keyFilePath, passphrase);
            if (scpManager_key.UploadFile(localFilePath, remoteFilePath))
            {
                Log.Information("SCP : uploaded successfully with key!");
            }            
        }



        //SCAN IP & NETWORK
        private async void Scan_btn_network_Click(object sender, EventArgs e)
        {
            Scan_btn_network.Enabled = false;
            string ipRange = Scan_IP_textbox.Text.Trim();
            await Task.Run(() => 
                networkManager.ScanNetworks(ipRange)
            );
            Scan_btn_network.Enabled = true;
        }



        //EXIT FORM
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sshManager_key != null && sshManager_key.IsConnected)
            {
                sshManager_key.Disconnect();
            }
        }
    }
}
