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
using System.Threading;
using Renci.SshNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace tool_backup
{
    public partial class Form1 : Form
    {
        //var-opject
        private SSHClientManager            sshManager_key;
        private SCPClientManager            scpManager_key;
        private LogManager                  logManager;
        private NetworkManager              networkManager;
        private OptionManager               optionManager;
        private JsonManager                 jsonManager;
        private Config                      config;
        private TreeViewManager             treeViewManager;
        private System.Windows.Forms.Timer  logUpdateTimer;

        //var-data log-file and timer-update
        string logFileName = "tool-backup.log";
        string logFilePath = "";
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        //var-data SSH
        string ip;
        string keyFilePath;

        //var-data-JSON
        string username_JSON;
        string key_JSON;
        string pathhome_JSON;
        string pathDB_JSON;
        string pathLog_JSON;
        string start_JSON;
        string stop_JSON;
        string command;

        //map-string
        Dictionary<string, string> stringMap = new Dictionary<string, string>();


        public Form1()
        {
            InitializeComponent();

            //object-constructor
            logFilePath      = Path.Combine(currentDirectory, logFileName);
            logUpdateTimer   = new System.Windows.Forms.Timer();
            networkManager   = new NetworkManager(dataGridView1);
            logManager       = new LogManager(logFilePath);
            optionManager    = new OptionManager();
            jsonManager      = new JsonManager();
            treeViewManager  = new TreeViewManager(treeView1, Device_Download, UpdateSelectedPath);
           

            //type-device
            optionManager.AddItem("MT7688", "MT7688");
            optionManager.AddItem("AI-V2", "AI-V2");
            optionManager.AddItem("AI-V3", "AI-V3");
            comboBoxOptions.DataSource = optionManager.GetItems();
            comboBoxOptions.SelectedIndexChanged += comboBoxOptions_SelectedIndexChanged;

            //timer-update
            logUpdateTimer.Interval = 50;
            logUpdateTimer.Tick += timer1_Tick;
            logUpdateTimer.Start();

        }

        //return 
        private void UpdateSelectedPath(string path)
        {
            command = path;
        }


        void autoload_disconected()
        {
            ConnectDevice_Status.BackColor = Color.Red;
        }

        void autoload_connected()
        {
            ConnectDevice_Status.BackColor = Color.Green;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoload_disconected();
        }



        //CHECK-OPTION
        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (ComboBoxItem)comboBoxOptions.SelectedItem;
            if (selectedItem != null)
            {
                string selectedValue = optionManager.GetSelectedValue(selectedItem);
                LoadConfig(selectedValue);
            }
        }
        private void LoadConfig(string selectedValue)
        {
            try
            {
                jsonManager.ConfigReader("setting.json");
                config = jsonManager.ReadConfig();

                DeviceConfig selectedConfig = null;
                switch (selectedValue)
                {
                    case "MT7688":
                        selectedConfig = config.MT;
                        break;
                    case "AI-V2":
                        selectedConfig = config.AI_V2;
                        break;
                    case "AI-V3":
                        selectedConfig = config.AI_V3;
                        break;
                }

                if (selectedConfig != null)
                {
                    username_JSON = selectedConfig.username;
                    key_JSON      = selectedConfig.key;
                    pathhome_JSON = selectedConfig.pathhome;
                    pathDB_JSON   = selectedConfig.pathDB;
                    pathLog_JSON  = selectedConfig.pathlog;
                    stop_JSON     = selectedConfig.stop;
                    start_JSON    = selectedConfig.start;

                    ConnectDevice_Username.Text = username_JSON;
                    ConnectDevice_Passphare.Text = key_JSON;

                    treeViewManager.UpdatePaths(pathLog_JSON, pathDB_JSON);

                    var allPaths = treeViewManager.GetAllPaths();
                    Device_Download.Clear();
                    foreach (var path in allPaths)
                    {
                        Device_Download.AppendText(path + Environment.NewLine);
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config: {ex.Message}");
            }
        }



        //OPEN-KEY-FILE
        private void ConnectDevice_CheckKeyfile_CheckedChanged(object sender, EventArgs e)
        {
            string key;
            try
            {
                
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
                }
            }
            catch (Exception)
            {
                key = "";
            }

        }

        //SSH
        private void ConnectDevice_SSH_Click(object sender, EventArgs e)
        {
            try
            {
                ip          = ConnectDevice_Ip_index1.Text.Trim();
                keyFilePath = ConnectDevice_KeyFile  .Text.Trim();

                sshManager_key = new SSHClientManager(ip, username_JSON, keyFilePath, key_JSON);
                if (sshManager_key.Connect())
                {
                    try
                    {
                        sshManager_key.Connect();
                        Log.Information("SSH: successfully");
                        autoload_connected();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("SSH: connection failed: " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
            }

        }


        //EXIT SSH
        private void ConnectDevice_ExitSSH_Click(object sender, EventArgs e)
        {
            if (sshManager_key    != null && sshManager_key.IsConnected)
            {
                autoload_disconected();
                sshManager_key.Disconnect();
                Log.Information("SSH: disconnected connection with " + username_JSON + "@" + ip);
            }
            logManager.ClearLog(Log_app);
        }


        //CMD-INPUT-OUTPUT
        private void check_cmd_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = cmd_input.Text.Trim();
                sshManager_key.ExecuteCommand(commandText, message =>
                              {
                                    Log_cmd.AppendText(message + "\n");
                              });
            }
            catch (Exception)
            {
                MessageBox.Show("Not SSH");
            }
        }



        //CHECK-LOG-APP
        private void timer1_Tick(object sender, EventArgs e)
        {  
            logManager.ReadLog(Log_app);              
        }



        //DOWNLOAD FILE
        private void SCP_Download_Click(object sender, EventArgs e)
        {
            try
            {
                string remoteFilePath = $@"{command}";
                string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string fileName = Path.GetFileName(command);
                string localFilePath = Path.Combine(downloadsFolder, fileName);

                Local_Download.Text = localFilePath;

                if(username_JSON == "root" && sshManager_key.IsConnected)
                {
                    //scp file device to local
                    scpManager_key = new SCPClientManager(ip, username_JSON, keyFilePath, key_JSON);
                    if (scpManager_key.DownloadFile(remoteFilePath, localFilePath))
                    {
                        Log.Information("Downloaded Successfully!");
                        MessageBox.Show("Downloaded Successfully!");
                    }
                }
                else
                {
                    string sudoPassword = "Lumivn274@aihubcamera";
                    if (sshManager_key.IsConnected)
                    {
                        //step 1 :  move file root -> user
                        string moveCommand = $"echo \"{sudoPassword}\" | sudo -S cp {remoteFilePath} {pathhome_JSON}";
                        string result = sshManager_key.ExecuteCommand(moveCommand);

                        //step 2 : scp file device to local
                        string remoteMovedFilePath = $"{pathhome_JSON}/{fileName}";
                        scpManager_key = new SCPClientManager(ip, username_JSON, keyFilePath, key_JSON);
                        if (scpManager_key.DownloadFile(remoteMovedFilePath, localFilePath))
                        {
                            Log.Information("downloaded successfully!");
                            MessageBox.Show("Downloaded Successfully!");
                        }

                        //step 3 : remove file copy
                        string moveCommand_rm = $"rm -rf {pathhome_JSON}/{fileName}";
                        string result_rm = sshManager_key.ExecuteCommand(moveCommand_rm);
                    }           
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
            }
        }





        //UPLOAD FILE
        private void SCP_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                string localFilePath = @"";
                string fileName = Path.GetFileName(localFilePath);
                //string remoteFilePath = @"";
                if(username_JSON == "root")
                {
                    //step 1 : open file local 
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Title = "Select a File",
                        Filter = "All Files (*.*)|*.*"
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        localFilePath = openFileDialog.FileName;
                        Local_Upload.Text = localFilePath;
                        Device_Upload.Text = pathDB_JSON;
                    }
                    

                    //step 2 : stop device
                    string stopCommand = $"{stop_JSON}";
                    string resultstop = sshManager_key.ExecuteCommand(stopCommand);
                    Thread.Sleep(1000);

                    //step 3 : scp local to home device
                    scpManager_key = new SCPClientManager(ip, username_JSON, keyFilePath, key_JSON);
                    if (scpManager_key.UploadFile(localFilePath, pathDB_JSON))
                    {
                        Log.Information("Uploaded Successfully");
                    }
                    Thread.Sleep(3000);

                    //step 4 : start device
                    string startCommand = $"{start_JSON}";
                    string resultstart = sshManager_key.ExecuteCommand(startCommand);

                    Console.WriteLine(localFilePath);
                    Console.WriteLine(stop_JSON);
                    Console.WriteLine(pathDB_JSON);
                    Console.WriteLine(start_JSON);
                }
                else
                {
                    if (sshManager_key.IsConnected){
                        ;
                        //Local_Upload.Text = localFilePath;  
                        ////step 1 : open file local 
                        //OpenFileDialog openFileDialog = new OpenFileDialog
                        //{
                        //    Title = "Select a File",
                        //    Filter = "All Files (*.*)|*.*"
                        //};
                        //if (openFileDialog.ShowDialog() == DialogResult.OK)
                        //{
                        //    localFilePath = openFileDialog.FileName;
                        //}



                        ////step 2 : stop device
                        //string stopCommand = $"{stop_JSON}";
                        //string resultstop = sshManager_key.ExecuteCommand(stopCommand);
                        //Thread.Sleep(500);


                        ////step 3 : scp local to home device
                        //scpManager_key = new SCPClientManager(ip, username_JSON, keyFilePath, key_JSON);
                        //if (scpManager_key.UploadFile(localFilePath, pathhome_JSON))
                        //{
                        //    Log.Information("Uploaded Successfully");
                        //}
                        //Thread.Sleep(500);

                        ////step 4 : move home device to folder DB
                        //string moveCommand = $"mv {pathhome_JSON} {pathLog_JSON}";
                        //string resultmove = sshManager_key.ExecuteCommand(moveCommand);
                        //Thread.Sleep(500);

                        ////step 5 : start device
                        //string startCommand = $"{start_JSON}";
                        //string resultstart = sshManager_key.ExecuteCommand(startCommand);
                        //Console.WriteLine("Thanh Cong");
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Try Again");
            }
        }


        private bool isScanning = false;
        //SCAN IP & NETWORK
        private async void Scan_btn_network_Click(object sender, EventArgs e)
        {
            if (isScanning)
            {
                return;
            }
            Scan_btn_network.Enabled = false;
            isScanning = true;
            string ipRange = Scan_IP_textbox.Text.Trim();
            await Task.Run(() => 
                networkManager.ScanNetworks(ipRange)
            );
            isScanning = false;
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




        //SEARCH BY MAC
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchValue = Scan_Search.Text.Trim();
            networkManager.dgvManager.SearchByMac(searchValue);
        }
    }
}
