using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace tool_backup
{
    public class sftp
    {
        private SftpClient sftpClient;

        // key
        public sftp(string ip, string username, string keyFilePath, string passphrase, int port = 22)
        {
            PrivateKeyFile keyFile = new PrivateKeyFile(keyFilePath, passphrase);
            PrivateKeyFile[] keyFiles = new[] { keyFile };
            AuthenticationMethod[] authMethods = new AuthenticationMethod[]
            {
        new PrivateKeyAuthenticationMethod(username, keyFiles)
            };
            ConnectionInfo connectionInfo = new ConnectionInfo(ip, port, username, authMethods);
            this.sftpClient = new SftpClient(connectionInfo);
        }


        // no key
        public sftp(string ip, string username, string password, int port = 22)
        {
            AuthenticationMethod[] authMethods = new AuthenticationMethod[]
            {
        new PasswordAuthenticationMethod(username, password)
            };
            ConnectionInfo connectionInfo = new ConnectionInfo(ip, port, username, authMethods);
            this.sftpClient = new SftpClient(connectionInfo);
        }



        public bool Connect()
        {
            try
            {
                sftpClient.Connect();
                Console.WriteLine("SFTP connection successful!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect: {ex.Message}");
                return false;
            }
        }


        public void Disconnect()
        {
            if (sftpClient != null && sftpClient.IsConnected)
            {
                sftpClient.Disconnect();
            }
        }


        public bool IsConnected => sftpClient != null && sftpClient.IsConnected;



        public bool DownloadFile(string remoteFilePath, string localFilePath)
        {
            try
            {
                using (var fileStream = File.OpenWrite(localFilePath))
                {
                    sftpClient.DownloadFile(remoteFilePath, fileStream);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file: {ex.Message}");
                return false;
            }
        }

        public bool UploadFile(string localFilePath, string remoteFilePath)
        {
            try
            {
                using (var fileStream = File.OpenRead(localFilePath))
                {
                    sftpClient.UploadFile(fileStream, remoteFilePath);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return false;
            }
        }

        public List<Renci.SshNet.Sftp.ISftpFile> ListDirectory(string path)
        {
            if (sftpClient.IsConnected)
            {
                var files = new List<Renci.SshNet.Sftp.ISftpFile>(sftpClient.ListDirectory(path));
                return files;
            }
            return new List<Renci.SshNet.Sftp.ISftpFile>();
        }



        public bool DeleteFile(string remoteFilePath)
        {
            try
            {
                sftpClient.DeleteFile(remoteFilePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
                return false;
            }
        }


        public bool CreateDirectory(string remoteDirectoryPath)
        {
            try
            {
                sftpClient.CreateDirectory(remoteDirectoryPath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
                return false;
            }
        }
    }
}
