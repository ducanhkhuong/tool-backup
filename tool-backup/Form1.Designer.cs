namespace tool_backup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectDevice_Passphare = new System.Windows.Forms.TextBox();
            this.ConnectDevice_SSH = new System.Windows.Forms.Button();
            this.ConnectDevice_ExitSSH = new System.Windows.Forms.Button();
            this.ConnectDevice_Status = new System.Windows.Forms.Button();
            this.ConnectDevice_CheckKeyfile = new System.Windows.Forms.CheckBox();
            this.ConnectDevice_Username = new System.Windows.Forms.TextBox();
            this.ConnectDevice_Passworld = new System.Windows.Forms.TextBox();
            this.ConnectDevice_KeyFile = new System.Windows.Forms.TextBox();
            this.ConnectDevice_Ip_index1 = new System.Windows.Forms.TextBox();
            this.ConnectDevice_label_Pass = new System.Windows.Forms.Label();
            this.ConnectDevice_label_Keyfile = new System.Windows.Forms.Label();
            this.ConnectDevice_label_Ip = new System.Windows.Forms.Label();
            this.ConnectDevice_label_Username = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Log_app = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SCP_Download = new System.Windows.Forms.Button();
            this.SCP_Upload = new System.Windows.Forms.Button();
            this.Log_cmd = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.check_cmd = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Scan_IP_textbox = new System.Windows.Forms.TextBox();
            this.Stop_btn_network = new System.Windows.Forms.Button();
            this.Log_network = new System.Windows.Forms.RichTextBox();
            this.Scan_btn_network = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ConnectDevice_Passphare);
            this.groupBox1.Controls.Add(this.ConnectDevice_SSH);
            this.groupBox1.Controls.Add(this.ConnectDevice_ExitSSH);
            this.groupBox1.Controls.Add(this.ConnectDevice_Status);
            this.groupBox1.Controls.Add(this.ConnectDevice_CheckKeyfile);
            this.groupBox1.Controls.Add(this.ConnectDevice_Username);
            this.groupBox1.Controls.Add(this.ConnectDevice_Passworld);
            this.groupBox1.Controls.Add(this.ConnectDevice_KeyFile);
            this.groupBox1.Controls.Add(this.ConnectDevice_Ip_index1);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Pass);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Keyfile);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Ip);
            this.groupBox1.Controls.Add(this.ConnectDevice_label_Username);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 253);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Passphare :";
            // 
            // ConnectDevice_Passphare
            // 
            this.ConnectDevice_Passphare.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Passphare.Location = new System.Drawing.Point(106, 140);
            this.ConnectDevice_Passphare.Multiline = true;
            this.ConnectDevice_Passphare.Name = "ConnectDevice_Passphare";
            this.ConnectDevice_Passphare.Size = new System.Drawing.Size(218, 21);
            this.ConnectDevice_Passphare.TabIndex = 10;
            // 
            // ConnectDevice_SSH
            // 
            this.ConnectDevice_SSH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_SSH.Location = new System.Drawing.Point(266, 213);
            this.ConnectDevice_SSH.Name = "ConnectDevice_SSH";
            this.ConnectDevice_SSH.Size = new System.Drawing.Size(101, 31);
            this.ConnectDevice_SSH.TabIndex = 6;
            this.ConnectDevice_SSH.Text = "SSH";
            this.ConnectDevice_SSH.UseVisualStyleBackColor = true;
            this.ConnectDevice_SSH.Click += new System.EventHandler(this.ConnectDevice_SSH_Click);
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
            this.ConnectDevice_Status.Location = new System.Drawing.Point(332, 18);
            this.ConnectDevice_Status.Margin = new System.Windows.Forms.Padding(0);
            this.ConnectDevice_Status.Name = "ConnectDevice_Status";
            this.ConnectDevice_Status.Size = new System.Drawing.Size(32, 19);
            this.ConnectDevice_Status.TabIndex = 6;
            this.ConnectDevice_Status.UseVisualStyleBackColor = false;
            // 
            // ConnectDevice_CheckKeyfile
            // 
            this.ConnectDevice_CheckKeyfile.AutoSize = true;
            this.ConnectDevice_CheckKeyfile.Location = new System.Drawing.Point(332, 103);
            this.ConnectDevice_CheckKeyfile.Name = "ConnectDevice_CheckKeyfile";
            this.ConnectDevice_CheckKeyfile.Size = new System.Drawing.Size(18, 17);
            this.ConnectDevice_CheckKeyfile.TabIndex = 11;
            this.ConnectDevice_CheckKeyfile.UseVisualStyleBackColor = true;
            this.ConnectDevice_CheckKeyfile.CheckedChanged += new System.EventHandler(this.ConnectDevice_CheckKeyfile_CheckedChanged);
            // 
            // ConnectDevice_Username
            // 
            this.ConnectDevice_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Username.Location = new System.Drawing.Point(106, 24);
            this.ConnectDevice_Username.Multiline = true;
            this.ConnectDevice_Username.Name = "ConnectDevice_Username";
            this.ConnectDevice_Username.Size = new System.Drawing.Size(218, 21);
            this.ConnectDevice_Username.TabIndex = 9;
            this.ConnectDevice_Username.Text = "root";
            // 
            // ConnectDevice_Passworld
            // 
            this.ConnectDevice_Passworld.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Passworld.Location = new System.Drawing.Point(106, 176);
            this.ConnectDevice_Passworld.Multiline = true;
            this.ConnectDevice_Passworld.Name = "ConnectDevice_Passworld";
            this.ConnectDevice_Passworld.Size = new System.Drawing.Size(218, 21);
            this.ConnectDevice_Passworld.TabIndex = 10;
            // 
            // ConnectDevice_KeyFile
            // 
            this.ConnectDevice_KeyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_KeyFile.Location = new System.Drawing.Point(106, 101);
            this.ConnectDevice_KeyFile.Multiline = true;
            this.ConnectDevice_KeyFile.Name = "ConnectDevice_KeyFile";
            this.ConnectDevice_KeyFile.Size = new System.Drawing.Size(218, 21);
            this.ConnectDevice_KeyFile.TabIndex = 9;
            // 
            // ConnectDevice_Ip_index1
            // 
            this.ConnectDevice_Ip_index1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_Ip_index1.Location = new System.Drawing.Point(106, 62);
            this.ConnectDevice_Ip_index1.MaxLength = 20;
            this.ConnectDevice_Ip_index1.Multiline = true;
            this.ConnectDevice_Ip_index1.Name = "ConnectDevice_Ip_index1";
            this.ConnectDevice_Ip_index1.Size = new System.Drawing.Size(218, 21);
            this.ConnectDevice_Ip_index1.TabIndex = 8;
            // 
            // ConnectDevice_label_Pass
            // 
            this.ConnectDevice_label_Pass.AutoSize = true;
            this.ConnectDevice_label_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Pass.Location = new System.Drawing.Point(11, 179);
            this.ConnectDevice_label_Pass.Name = "ConnectDevice_label_Pass";
            this.ConnectDevice_label_Pass.Size = new System.Drawing.Size(76, 16);
            this.ConnectDevice_label_Pass.TabIndex = 7;
            this.ConnectDevice_label_Pass.Text = "Password : ";
            // 
            // ConnectDevice_label_Keyfile
            // 
            this.ConnectDevice_label_Keyfile.AutoSize = true;
            this.ConnectDevice_label_Keyfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Keyfile.Location = new System.Drawing.Point(11, 101);
            this.ConnectDevice_label_Keyfile.Name = "ConnectDevice_label_Keyfile";
            this.ConnectDevice_label_Keyfile.Size = new System.Drawing.Size(56, 16);
            this.ConnectDevice_label_Keyfile.TabIndex = 7;
            this.ConnectDevice_label_Keyfile.Text = "Key file :";
            // 
            // ConnectDevice_label_Ip
            // 
            this.ConnectDevice_label_Ip.AutoSize = true;
            this.ConnectDevice_label_Ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Ip.Location = new System.Drawing.Point(11, 62);
            this.ConnectDevice_label_Ip.Name = "ConnectDevice_label_Ip";
            this.ConnectDevice_label_Ip.Size = new System.Drawing.Size(25, 16);
            this.ConnectDevice_label_Ip.TabIndex = 7;
            this.ConnectDevice_label_Ip.Text = "IP :";
            // 
            // ConnectDevice_label_Username
            // 
            this.ConnectDevice_label_Username.AutoSize = true;
            this.ConnectDevice_label_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDevice_label_Username.Location = new System.Drawing.Point(11, 27);
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
            this.groupBox2.Location = new System.Drawing.Point(731, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(840, 329);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "log";
            // 
            // Log_app
            // 
            this.Log_app.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_app.Location = new System.Drawing.Point(0, 54);
            this.Log_app.Name = "Log_app";
            this.Log_app.Size = new System.Drawing.Size(825, 261);
            this.Log_app.TabIndex = 0;
            this.Log_app.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SCP_Download
            // 
            this.SCP_Download.Location = new System.Drawing.Point(511, 291);
            this.SCP_Download.Name = "SCP_Download";
            this.SCP_Download.Size = new System.Drawing.Size(101, 31);
            this.SCP_Download.TabIndex = 7;
            this.SCP_Download.Text = "Download";
            this.SCP_Download.UseVisualStyleBackColor = true;
            this.SCP_Download.Click += new System.EventHandler(this.SCP_Download_Click);
            // 
            // SCP_Upload
            // 
            this.SCP_Upload.Location = new System.Drawing.Point(511, 254);
            this.SCP_Upload.Name = "SCP_Upload";
            this.SCP_Upload.Size = new System.Drawing.Size(101, 31);
            this.SCP_Upload.TabIndex = 8;
            this.SCP_Upload.Text = "Upload";
            this.SCP_Upload.UseVisualStyleBackColor = true;
            this.SCP_Upload.Click += new System.EventHandler(this.SCP_Upload_Click);
            // 
            // Log_cmd
            // 
            this.Log_cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_cmd.Location = new System.Drawing.Point(6, 22);
            this.Log_cmd.Name = "Log_cmd";
            this.Log_cmd.Size = new System.Drawing.Size(828, 282);
            this.Log_cmd.TabIndex = 8;
            this.Log_cmd.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox4.Controls.Add(this.check_cmd);
            this.groupBox4.Controls.Add(this.Log_cmd);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(731, 352);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(840, 331);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cmd-Output";
            // 
            // check_cmd
            // 
            this.check_cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_cmd.Location = new System.Drawing.Point(6, 302);
            this.check_cmd.Name = "check_cmd";
            this.check_cmd.Size = new System.Drawing.Size(75, 23);
            this.check_cmd.TabIndex = 9;
            this.check_cmd.Text = "CMD";
            this.check_cmd.UseVisualStyleBackColor = true;
            this.check_cmd.Click += new System.EventHandler(this.check_cmd_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.Scan_IP_textbox);
            this.groupBox5.Controls.Add(this.Stop_btn_network);
            this.groupBox5.Controls.Add(this.Log_network);
            this.groupBox5.Controls.Add(this.Scan_btn_network);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 354);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(709, 329);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "IP :";
            // 
            // Scan_IP_textbox
            // 
            this.Scan_IP_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scan_IP_textbox.Location = new System.Drawing.Point(37, 21);
            this.Scan_IP_textbox.Multiline = true;
            this.Scan_IP_textbox.Name = "Scan_IP_textbox";
            this.Scan_IP_textbox.Size = new System.Drawing.Size(209, 21);
            this.Scan_IP_textbox.TabIndex = 13;
            // 
            // Stop_btn_network
            // 
            this.Stop_btn_network.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_btn_network.Location = new System.Drawing.Point(359, 17);
            this.Stop_btn_network.Name = "Stop_btn_network";
            this.Stop_btn_network.Size = new System.Drawing.Size(101, 31);
            this.Stop_btn_network.TabIndex = 12;
            this.Stop_btn_network.Text = "Stop";
            this.Stop_btn_network.UseVisualStyleBackColor = true;
            this.Stop_btn_network.Click += new System.EventHandler(this.Stop_btn_network_Click);
            // 
            // Log_network
            // 
            this.Log_network.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log_network.Location = new System.Drawing.Point(6, 54);
            this.Log_network.Name = "Log_network";
            this.Log_network.Size = new System.Drawing.Size(697, 248);
            this.Log_network.TabIndex = 11;
            this.Log_network.Text = "";
            // 
            // Scan_btn_network
            // 
            this.Scan_btn_network.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scan_btn_network.Location = new System.Drawing.Point(252, 17);
            this.Scan_btn_network.Name = "Scan_btn_network";
            this.Scan_btn_network.Size = new System.Drawing.Size(101, 31);
            this.Scan_btn_network.TabIndex = 10;
            this.Scan_btn_network.Text = "Scan";
            this.Scan_btn_network.UseVisualStyleBackColor = true;
            this.Scan_btn_network.Click += new System.EventHandler(this.Scan_btn_network_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1597, 693);
            this.Controls.Add(this.SCP_Download);
            this.Controls.Add(this.SCP_Upload);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool-Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ConnectDevice_label_Pass;
        private System.Windows.Forms.Label ConnectDevice_label_Keyfile;
        private System.Windows.Forms.Label ConnectDevice_label_Ip;
        private System.Windows.Forms.Label ConnectDevice_label_Username;
        private System.Windows.Forms.Button ConnectDevice_Status;
        private System.Windows.Forms.CheckBox ConnectDevice_CheckKeyfile;
        private System.Windows.Forms.TextBox ConnectDevice_Username;
        private System.Windows.Forms.TextBox ConnectDevice_Passworld;
        private System.Windows.Forms.TextBox ConnectDevice_KeyFile;
        private System.Windows.Forms.TextBox ConnectDevice_Ip_index1;
        private System.Windows.Forms.Button ConnectDevice_ExitSSH;
        private System.Windows.Forms.Button ConnectDevice_SSH;
        private System.Windows.Forms.RichTextBox Log_app;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button SCP_Download;
        private System.Windows.Forms.Button SCP_Upload;
        private System.Windows.Forms.TextBox ConnectDevice_Passphare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox Log_cmd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button Scan_btn_network;
        private System.Windows.Forms.RichTextBox Log_network;
        private System.Windows.Forms.TextBox Scan_IP_textbox;
        private System.Windows.Forms.Button Stop_btn_network;
        private System.Windows.Forms.Button check_cmd;
        private System.Windows.Forms.Label label2;
    }
}

