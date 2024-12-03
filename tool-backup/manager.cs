using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tool_backup
{
    public class manager
    {
        public ssh sshManager_key { get; set; }
        public scp scpManager_key { get; set; }
        public sftp sftpManager_key { get; set; }
        public log logManager { get; set; }
        public network networkManager { get; set; }
        public JsonManager jsonManager { get; set; }
        public Config config { get; set; }
        public treeview treeViewManager { get; set; }


        public string ip { get; set; }
        public string keyFilePath { get; set; }
        public string username_JSON { get; set; }
        public string key_JSON { get; set; }
        public string pathhome_JSON { get; set; }
        public string pathDB_JSON { get; set; }
        public string pathLog_JSON { get; set; }
        public string start_JSON { get; set; }
        public string stop_JSON { get; set; }
        public string command { get; set; }


        Dictionary<string, string> stringMap { get; set; } = new Dictionary<string, string>();

        public manager (DataGridView dataGridView , TreeView treeView , TextBox textbox){
            networkManager  = new network(dataGridView);
            logManager      = new log();
            jsonManager     = new JsonManager();
            treeViewManager = new treeview(treeView , textbox, UpdateSelectedPath);
        }

        public void UpdateSelectedPath(string path)
        {
            command = path;
        }


        public void autoload_disconected(Button button)
        {
            button.BackColor = Color.Red;
        }

        public void autoload_connected(Button button)
        {
            button.BackColor = Color.Green;
        }


        public void form1_load(RichTextBox richTextBox , string team , string version)
        {
            logManager.WriteLog(richTextBox, $"{team}");
            logManager.WriteLog(richTextBox, $"{version}");
        }

        public void LoadConfig(string fileconfig , string selectedValue , TextBox textBox_usr , TextBox textBox_passphare ,TextBox deviceDownload)
        {
            try
            {
                jsonManager.ConfigReader($"{fileconfig}");
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
                    key_JSON = selectedConfig.key;
                    pathhome_JSON = selectedConfig.pathhome;
                    pathDB_JSON = selectedConfig.pathDB;
                    pathLog_JSON = selectedConfig.pathlog;
                    stop_JSON = selectedConfig.stop;
                    start_JSON = selectedConfig.start;

                    textBox_usr.Text  = username_JSON;
                    textBox_passphare.Text = key_JSON;

                    treeViewManager.UpdatePaths(pathLog_JSON, pathDB_JSON);

                    var allPaths = treeViewManager.GetAllPaths();
                    deviceDownload.Clear();
                    foreach (var path in allPaths)
                    {
                        deviceDownload.AppendText(path + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading config: {ex.Message}");
            }
        }

        public void get_ip_status(CheckBox ip_get,TextBox textBox)
        {
            if (ip_get.Checked) { 
                textBox.Enabled = true;
            }
            else
            {
                textBox.Enabled = false;
            }
        }

        public void get_ip_input(CheckBox ip_get, TextBox textBox)
        {
            if (ip_get.Checked)
            {
                ip = textBox.Text;
                textBox.Text = ip;
            }
        }

        public void connect(CheckBox ip_get, Button button, TextBox textBox)
        {
            try
            {
                if (!ip_get.Checked)
                {
                    ip = networkManager.get_ip_scan_succesfully();
                    textBox.Text = ip;  
                }

                Console.WriteLine($" {ip} \n {username_JSON} \n {keyFilePath} \n {key_JSON}");

                sshManager_key = new ssh(ip, username_JSON, keyFilePath, key_JSON);
                if (sshManager_key.Connect())
                {
                    autoload_connected(button);
                }
            }
            catch
            {
                MessageBox.Show("Try Again");
            }

        }

        public void disconnect(Button button)
        {
            try
            {
                if (sshManager_key != null)
                {
                    sshManager_key.Disconnect();
                    autoload_disconected(button);
                    MessageBox.Show("Đã ngắt kết nối thiết bị");
                }
            }
            catch
            {
                MessageBox.Show("Try Again");
            }
        }

        public void get_key_file(CheckBox keyfile, TextBox textBox)
        {
            try
            {
                if (keyfile.Checked)
                {
                    textBox.Enabled = true;
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Title = "Select a File",
                        Filter = "All Files (*.*)|*.*"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        keyFilePath = openFileDialog.FileName;
                        textBox.Text = keyFilePath;
                    }
                }
                else
                {
                    textBox.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
            }
        }


        private void check_empty()
        {
            //check empty
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("ip is empty, please try again.");
                return;
            }
            if (string.IsNullOrEmpty(username_JSON))
            {
                MessageBox.Show("username is empty, please try again.");
                return;
            }
            if (string.IsNullOrEmpty(keyFilePath))
            {
                MessageBox.Show("keyfile is empty, please try again.");
                return;
            }
            if (string.IsNullOrEmpty(key_JSON))
            {
                MessageBox.Show("passphare is empty, please try again.");
                return;
            }
        }

        public void download(TextBox local_upload , TextBox device , TextBox local_download,RichTextBox richtextbox)
        {
            local_upload.Text = null;
            device.Text = null;

            //handle
            try
            {
                string remoteFilePath = $@"{command}";
                string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string fileName = Path.GetFileName(command);
                
                //check empty
                if (string.IsNullOrEmpty(fileName))
                {
                    MessageBox.Show("File name is empty, please try again.");
                    return;
                }

                string localFilePath = Path.Combine(downloadsFolder, fileName);
                local_download.Text = localFilePath;


                if (username_JSON == "root")
                {
                    check_empty();
                    scpManager_key = new scp(ip, username_JSON, keyFilePath, key_JSON);
                    if (scpManager_key.DownloadFile(remoteFilePath, localFilePath))
                    {
                        logManager.WriteLog(richtextbox, "Downloading");
                        MessageBox.Show("Downloaded Successfully!");
                    }
                }
                else
                {
                    check_empty();
                    string sudoPassword = "Lumivn274@aihubcamera";
                    if (sshManager_key.IsConnected)
                    {

                        //step 1 :  move file root -> user
                        string moveCommand = $"echo \"{sudoPassword}\" | sudo -S cp {remoteFilePath} {pathhome_JSON}";
                        string result = sshManager_key.ExecuteCommand(moveCommand);

                        //step 2 : scp file device to local
                        string remoteMovedFilePath = $"{pathhome_JSON}/{fileName}";
                        scpManager_key = new scp(ip, username_JSON, keyFilePath, key_JSON);
                        if (scpManager_key.DownloadFile(remoteMovedFilePath, localFilePath))
                        {
                            logManager.WriteLog(richtextbox, "Downloading");
                        }


                        //step 3 : remove file copy
                        //string moveCommand_rm = $"rm -rf {pathhome_JSON}/{filename}";
                        //string result_rm = sshManager_key.ExecuteCommand(moveCommand_rm);
                        MessageBox.Show("Downloaded Successfully!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
            }
        }


        public void upload(TextBox local_download, TextBox device_download,TextBox local_upload , TextBox device_upload ,RichTextBox log)
        {
            local_download.Text = null;
            device_download.Text = null;

            //handle
            try
            {
                
                if (username_JSON == "root")
                {   
                    check_empty();
                    string localFilePath = $@"";

                    //step 1 : open file local 
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Title = "Select a File",
                        Filter = "All Files (*.*)|*.*"
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        localFilePath = openFileDialog.FileName;
                        local_upload.Text = localFilePath;
                        device_upload.Text = pathDB_JSON;
                    }

                    if (string.IsNullOrEmpty(localFilePath))
                    {
                        MessageBox.Show("Local file is empty, please try again.");
                        return;
                    }

                    //step 2 : stop device             
                    string stopCommand = $"{stop_JSON}";
                    sshManager_key.ExecuteCommand(stopCommand, message =>
                    {
                        //Log_cmd.AppendText("1." + message + "\n");
                    });


                    //step 3 : scp local to home device
                    scpManager_key = new scp(ip, username_JSON, keyFilePath, key_JSON);
                    if (scpManager_key.UploadFile(localFilePath, pathDB_JSON))
                    {
                        logManager.WriteLog(log, "Uploading");
                    }

                    //step 4 : start device
                    string startCommand = $"{start_JSON}";
                    sshManager_key.ExecuteCommand(startCommand, message =>
                    {
                        //Log_cmd.AppendText("2." + message + "\n");
                    });
                    MessageBox.Show("Uploaded Successfully");
                }
                else
                {
                    string localFilePath = $@"";
                    string sudoPassword = "Lumivn274@aihubcamera";
                    string fileName;
                    check_empty();
                    if (sshManager_key.IsConnected)
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
                            local_upload.Text = localFilePath;
                        }


                        //check empty
                        fileName = Path.GetFileName(localFilePath);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            MessageBox.Show("File name is empty, please try again.");
                            return;
                        }



                        //step 2 : stop device
                        string stopCommand = $"echo \"{sudoPassword}\" | sudo -S {stop_JSON}";
                        sshManager_key.ExecuteCommand(stopCommand, message =>
                        {
                            //Log_cmd.AppendText("3." + message + "\n");
                        });



                        //step 3 : scp local to home device
                        scpManager_key = new scp(ip, username_JSON, keyFilePath, key_JSON);
                        if (scpManager_key.UploadFile(localFilePath, pathhome_JSON))
                        {
                            logManager.WriteLog(log, $"Uploading {fileName}");
                        }



                        //step 4 : move home device to folder DB
                        string moveCommand = $" echo \"{sudoPassword}\" | sudo -S cp {pathhome_JSON}{fileName}  {pathDB_JSON}";
                        sshManager_key.ExecuteCommand(moveCommand, message =>
                        {
                            //Log_cmd.AppendText("4." + message + "\n");
                        });
                        Console.WriteLine(moveCommand);


                        //step 5 : start device
                        string startCommand = $"echo \"{sudoPassword}\" | sudo -S {start_JSON}";
                        sshManager_key.ExecuteCommand(startCommand, message =>
                        {
                            //Log_cmd.AppendText("5." + message + "\n");
                        });
                        MessageBox.Show("Uploaded Successfully");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
            }
        }


        public async void scan_ip_mac(TextBox ip, TextBox mac, TextBox keyfile,ProgressBar progress)
        {
            string ipRange = ip.Text.Trim();
            string macAddr = mac.Text.Trim();
            keyFilePath = keyfile.Text.Trim();

            //check empty
            if (string.IsNullOrEmpty(keyFilePath))
            {
                MessageBox.Show("key File is empty, please try again.");
                return;
            }
            if (string.IsNullOrEmpty(ipRange))
            {
                MessageBox.Show("iprange is empty, please try again.");
                return;
            }
            if (string.IsNullOrEmpty(macAddr))
            {
                MessageBox.Show("mac is empty, please try again.");
                return;
            }

            //handle
            try
            {
                await Task.Run(() => networkManager.ScanNetworks(ipRange, macAddr, username_JSON, keyFilePath, key_JSON, progress));
            }
            catch (Exception)
            {
                MessageBox.Show("Try Again");
            }
        }


        public void search_by_mac(TextBox textBox)
        {
            string searchValue = textBox.Text.Trim();
            networkManager.dgvManager.SearchByMac(searchValue);
        }
    }
}
