﻿namespace tool_backup
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectDevice_Passphare = new System.Windows.Forms.TextBox();
            this.ConnectDevice_SSH = new System.Windows.Forms.Button();
            this.comboBoxOptions = new System.Windows.Forms.ComboBox();
            this.ConnectDevice_ExitSSH = new System.Windows.Forms.Button();
            this.ConnectDevice_Status = new System.Windows.Forms.Button();
            this.ConnectDevice_CheckKeyfile = new System.Windows.Forms.CheckBox();
            this.ConnectDevice_Username = new System.Windows.Forms.TextBox();
            this.ConnectDevice_KeyFile = new System.Windows.Forms.TextBox();
            this.ConnectDevice_Ip_index1 = new System.Windows.Forms.TextBox();
            this.ConnectDevice_label_Keyfile = new System.Windows.Forms.Label();
            this.ConnectDevice_label_Ip = new System.Windows.Forms.Label();
            this.ConnectDevice_label_Username = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Log_app = new System.Windows.Forms.RichTextBox();
            this.SCP_Download = new System.Windows.Forms.Button();
            this.SCP_Upload = new System.Windows.Forms.Button();
            this.Log_cmd = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmd_input = new System.Windows.Forms.TextBox();
            this.check_cmd = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Scan_Search = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Scan_IP_textbox = new System.Windows.Forms.TextBox();
            this.Scan_btn_network = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Device_Download = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Local_Download = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Device_Upload = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Local_Upload = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ConnectDevice_Passphare);
            this.groupBox1.Controls.Add(this.ConnectDevice_SSH);
            this.groupBox1.Controls.Add(this.comboBoxOptions);
            this.groupBox1.Controls.Add(this.ConnectDevice_ExitSSH);
            this.groupBox1.Controls.Add(this.ConnectDevice_Status);
            this.groupBox1.Controls.Add(this.ConnectDevice_CheckKeyfile);
            this.groupBox1.Controls.Add(this.ConnectDevice_Username);
            this.groupBox1.Controls.Add(this.ConnectDevice_KeyFile);
            this.groupBox1.Controls.Add(this.ConnectDevice_Ip_index1);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Keyfile);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Ip);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Username);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 349);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Device";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Passphare :";
            // 
            // ConnectDevice_Passphare
            // 
            this.ConnectDevice_Passphare.Enabled = false;
            this.ConnectDevice_Passphare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Passphare.Location = new System.Drawing.Point(101, 176);
            this.ConnectDevice_Passphare.Name = "ConnectDevice_Passphare";
            this.ConnectDevice_Passphare.Size = new System.Drawing.Size(211, 24);
            this.ConnectDevice_Passphare.TabIndex = 10;
            this.ConnectDevice_Passphare.UseSystemPasswordChar = true;
            // 
            // ConnectDevice_SSH
            // 
            this.ConnectDevice_SSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_SSH.Location = new System.Drawing.Point(264, 210);
            this.ConnectDevice_SSH.Name = "ConnectDevice_SSH";
            this.ConnectDevice_SSH.Size = new System.Drawing.Size(101, 31);
            this.ConnectDevice_SSH.TabIndex = 6;
            this.ConnectDevice_SSH.Text = "SSH";
            this.ConnectDevice_SSH.UseVisualStyleBackColor = true;
            this.ConnectDevice_SSH.Click += new System.EventHandler(this.ConnectDevice_SSH_Click);
            // 
            // comboBoxOptions
            // 
            this.comboBoxOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOptions.FormattingEnabled = true;
            this.comboBoxOptions.Location = new System.Drawing.Point(101, 16);
            this.comboBoxOptions.Name = "comboBoxOptions";
            this.comboBoxOptions.Size = new System.Drawing.Size(211, 26);
            this.comboBoxOptions.TabIndex = 11;
            this.comboBoxOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxOptions_SelectedIndexChanged);
            // 
            // ConnectDevice_ExitSSH
            // 
            this.ConnectDevice_ExitSSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_ExitSSH.Location = new System.Drawing.Point(14, 213);
            this.ConnectDevice_ExitSSH.Name = "ConnectDevice_ExitSSH";
            this.ConnectDevice_ExitSSH.Size = new System.Drawing.Size(101, 31);
            this.ConnectDevice_ExitSSH.TabIndex = 6;
            this.ConnectDevice_ExitSSH.Text = "Exit";
            this.ConnectDevice_ExitSSH.UseVisualStyleBackColor = true;
            this.ConnectDevice_ExitSSH.Click += new System.EventHandler(this.ConnectDevice_ExitSSH_Click);
            // 
            // ConnectDevice_Status
            // 
            this.ConnectDevice_Status.BackColor = System.Drawing.SystemColors.Window;
            this.ConnectDevice_Status.Location = new System.Drawing.Point(352, 18);
            this.ConnectDevice_Status.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectDevice_Status.Name = "ConnectDevice_Status";
            this.ConnectDevice_Status.Size = new System.Drawing.Size(22, 23);
            this.ConnectDevice_Status.TabIndex = 6;
            this.ConnectDevice_Status.UseVisualStyleBackColor = false;
            // 
            // ConnectDevice_CheckKeyfile
            // 
            this.ConnectDevice_CheckKeyfile.AutoSize = true;
            this.ConnectDevice_CheckKeyfile.Location = new System.Drawing.Point(352, 142);
            this.ConnectDevice_CheckKeyfile.Name = "ConnectDevice_CheckKeyfile";
            this.ConnectDevice_CheckKeyfile.Size = new System.Drawing.Size(18, 17);
            this.ConnectDevice_CheckKeyfile.TabIndex = 11;
            this.ConnectDevice_CheckKeyfile.UseVisualStyleBackColor = true;
            this.ConnectDevice_CheckKeyfile.CheckedChanged += new System.EventHandler(this.ConnectDevice_CheckKeyfile_CheckedChanged);
            // 
            // ConnectDevice_Username
            // 
            this.ConnectDevice_Username.Enabled = false;
            this.ConnectDevice_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Username.Location = new System.Drawing.Point(101, 57);
            this.ConnectDevice_Username.Name = "ConnectDevice_Username";
            this.ConnectDevice_Username.Size = new System.Drawing.Size(211, 24);
            this.ConnectDevice_Username.TabIndex = 9;
            // 
            // ConnectDevice_KeyFile
            // 
            this.ConnectDevice_KeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_KeyFile.Location = new System.Drawing.Point(101, 137);
            this.ConnectDevice_KeyFile.Name = "ConnectDevice_KeyFile";
            this.ConnectDevice_KeyFile.Size = new System.Drawing.Size(211, 24);
            this.ConnectDevice_KeyFile.TabIndex = 9;
            // 
            // ConnectDevice_Ip_index1
            // 
            this.ConnectDevice_Ip_index1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Ip_index1.Location = new System.Drawing.Point(101, 98);
            this.ConnectDevice_Ip_index1.MaxLength = 20;
            this.ConnectDevice_Ip_index1.Name = "ConnectDevice_Ip_index1";
            this.ConnectDevice_Ip_index1.Size = new System.Drawing.Size(211, 24);
            this.ConnectDevice_Ip_index1.TabIndex = 8;
            // 
            // ConnectDevice_label_Keyfile
            // 
            this.ConnectDevice_label_Keyfile.AutoSize = true;
            this.ConnectDevice_label_Keyfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Keyfile.Location = new System.Drawing.Point(19, 142);
            this.ConnectDevice_label_Keyfile.Name = "ConnectDevice_label_Keyfile";
            this.ConnectDevice_label_Keyfile.Size = new System.Drawing.Size(56, 16);
            this.ConnectDevice_label_Keyfile.TabIndex = 7;
            this.ConnectDevice_label_Keyfile.Text = "Key file :";
            // 
            // ConnectDevice_label_Ip
            // 
            this.ConnectDevice_label_Ip.AutoSize = true;
            this.ConnectDevice_label_Ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Ip.Location = new System.Drawing.Point(19, 103);
            this.ConnectDevice_label_Ip.Name = "ConnectDevice_label_Ip";
            this.ConnectDevice_label_Ip.Size = new System.Drawing.Size(25, 16);
            this.ConnectDevice_label_Ip.TabIndex = 7;
            this.ConnectDevice_label_Ip.Text = "IP :";
            // 
            // ConnectDevice_label_Username
            // 
            this.ConnectDevice_label_Username.AutoSize = true;
            this.ConnectDevice_label_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Username.Location = new System.Drawing.Point(19, 62);
            this.ConnectDevice_label_Username.Name = "ConnectDevice_label_Username";
            this.ConnectDevice_label_Username.Size = new System.Drawing.Size(76, 16);
            this.ConnectDevice_label_Username.TabIndex = 6;
            this.ConnectDevice_label_Username.Text = "Username :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox2.Controls.Add(this.Log_app);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1184, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 678);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "log";
            // 
            // Log_app
            // 
            this.Log_app.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_app.Location = new System.Drawing.Point(6, 21);
            this.Log_app.Name = "Log_app";
            this.Log_app.Size = new System.Drawing.Size(327, 651);
            this.Log_app.TabIndex = 0;
            this.Log_app.Text = "";
            // 
            // SCP_Download
            // 
            this.SCP_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCP_Download.Location = new System.Drawing.Point(462, 22);
            this.SCP_Download.Name = "SCP_Download";
            this.SCP_Download.Size = new System.Drawing.Size(101, 31);
            this.SCP_Download.TabIndex = 7;
            this.SCP_Download.Text = "Download";
            this.SCP_Download.UseVisualStyleBackColor = true;
            this.SCP_Download.Click += new System.EventHandler(this.SCP_Download_Click);
            // 
            // SCP_Upload
            // 
            this.SCP_Upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCP_Upload.Location = new System.Drawing.Point(462, 71);
            this.SCP_Upload.Name = "SCP_Upload";
            this.SCP_Upload.Size = new System.Drawing.Size(101, 31);
            this.SCP_Upload.TabIndex = 8;
            this.SCP_Upload.Text = "Upload";
            this.SCP_Upload.UseVisualStyleBackColor = true;
            this.SCP_Upload.Click += new System.EventHandler(this.SCP_Upload_Click);
            // 
            // Log_cmd
            // 
            this.Log_cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_cmd.Location = new System.Drawing.Point(6, 54);
            this.Log_cmd.Name = "Log_cmd";
            this.Log_cmd.Size = new System.Drawing.Size(440, 250);
            this.Log_cmd.TabIndex = 8;
            this.Log_cmd.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox4.Controls.Add(this.cmd_input);
            this.groupBox4.Controls.Add(this.check_cmd);
            this.groupBox4.Controls.Add(this.Log_cmd);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(719, 367);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(459, 321);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cmd-Output";
            // 
            // cmd_input
            // 
            this.cmd_input.Enabled = false;
            this.cmd_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_input.Location = new System.Drawing.Point(6, 21);
            this.cmd_input.Multiline = true;
            this.cmd_input.Name = "cmd_input";
            this.cmd_input.ReadOnly = true;
            this.cmd_input.Size = new System.Drawing.Size(225, 26);
            this.cmd_input.TabIndex = 10;
            // 
            // check_cmd
            // 
            this.check_cmd.Enabled = false;
            this.check_cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_cmd.Location = new System.Drawing.Point(237, 21);
            this.check_cmd.Name = "check_cmd";
            this.check_cmd.Size = new System.Drawing.Size(75, 26);
            this.check_cmd.TabIndex = 9;
            this.check_cmd.Text = "CMD";
            this.check_cmd.UseVisualStyleBackColor = true;
            this.check_cmd.Click += new System.EventHandler(this.check_cmd_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.Scan_Search);
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.Scan_IP_textbox);
            this.groupBox5.Controls.Add(this.Scan_btn_network);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 367);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(701, 321);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(432, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Search :";
            // 
            // Scan_Search
            // 
            this.Scan_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scan_Search.Location = new System.Drawing.Point(501, 21);
            this.Scan_Search.Multiline = true;
            this.Scan_Search.Name = "Scan_Search";
            this.Scan_Search.Size = new System.Drawing.Size(194, 26);
            this.Scan_Search.TabIndex = 15;
            this.Scan_Search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(686, 250);
            this.dataGridView1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "IP :";
            // 
            // Scan_IP_textbox
            // 
            this.Scan_IP_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scan_IP_textbox.Location = new System.Drawing.Point(37, 21);
            this.Scan_IP_textbox.Multiline = true;
            this.Scan_IP_textbox.Name = "Scan_IP_textbox";
            this.Scan_IP_textbox.Size = new System.Drawing.Size(194, 26);
            this.Scan_IP_textbox.TabIndex = 13;
            // 
            // Scan_btn_network
            // 
            this.Scan_btn_network.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scan_btn_network.Location = new System.Drawing.Point(237, 21);
            this.Scan_btn_network.Name = "Scan_btn_network";
            this.Scan_btn_network.Size = new System.Drawing.Size(75, 26);
            this.Scan_btn_network.TabIndex = 10;
            this.Scan_btn_network.Text = "SCAN";
            this.Scan_btn_network.UseVisualStyleBackColor = true;
            this.Scan_btn_network.Click += new System.EventHandler(this.Scan_btn_network_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox3.Controls.Add(this.SCP_Upload);
            this.groupBox3.Controls.Add(this.SCP_Download);
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(401, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 197);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Option";
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(55, 22);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(370, 149);
            this.treeView1.TabIndex = 9;
            // 
            // Device_Download
            // 
            this.Device_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Device_Download.Location = new System.Drawing.Point(446, 56);
            this.Device_Download.Multiline = true;
            this.Device_Download.Name = "Device_Download";
            this.Device_Download.Size = new System.Drawing.Size(302, 26);
            this.Device_Download.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(356, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "<-----";
            // 
            // Local_Download
            // 
            this.Local_Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local_Download.Location = new System.Drawing.Point(38, 56);
            this.Local_Download.Multiline = true;
            this.Local_Download.Name = "Local_Download";
            this.Local_Download.Size = new System.Drawing.Size(268, 26);
            this.Local_Download.TabIndex = 19;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.Device_Upload);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.Local_Upload);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.Local_Download);
            this.groupBox6.Controls.Add(this.Device_Download);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(401, 215);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(777, 146);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Rule";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(585, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Device";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(157, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "PC";
            // 
            // Device_Upload
            // 
            this.Device_Upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Device_Upload.Location = new System.Drawing.Point(446, 97);
            this.Device_Upload.Multiline = true;
            this.Device_Upload.Name = "Device_Upload";
            this.Device_Upload.Size = new System.Drawing.Size(302, 29);
            this.Device_Upload.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(356, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "----->";
            // 
            // Local_Upload
            // 
            this.Local_Upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local_Upload.Location = new System.Drawing.Point(39, 97);
            this.Local_Upload.Multiline = true;
            this.Local_Upload.Name = "Local_Upload";
            this.Local_Upload.Size = new System.Drawing.Size(268, 29);
            this.Local_Upload.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1535, 702);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OS-Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ConnectDevice_label_Keyfile;
        private System.Windows.Forms.Label ConnectDevice_label_Ip;
        private System.Windows.Forms.Label ConnectDevice_label_Username;
        private System.Windows.Forms.Button ConnectDevice_Status;
        private System.Windows.Forms.TextBox ConnectDevice_Username;
        private System.Windows.Forms.TextBox ConnectDevice_KeyFile;
        private System.Windows.Forms.TextBox ConnectDevice_Ip_index1;
        private System.Windows.Forms.Button ConnectDevice_ExitSSH;
        private System.Windows.Forms.Button ConnectDevice_SSH;
        private System.Windows.Forms.RichTextBox Log_app;
        private System.Windows.Forms.Button SCP_Download;
        private System.Windows.Forms.Button SCP_Upload;
        private System.Windows.Forms.TextBox ConnectDevice_Passphare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Log_cmd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button Scan_btn_network;
        private System.Windows.Forms.TextBox Scan_IP_textbox;
        private System.Windows.Forms.Button check_cmd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxOptions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cmd_input;
        private System.Windows.Forms.CheckBox ConnectDevice_CheckKeyfile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Scan_Search;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox Device_Download;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Local_Download;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox Device_Upload;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Local_Upload;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}
