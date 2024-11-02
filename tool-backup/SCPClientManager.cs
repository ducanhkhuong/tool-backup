using Renci.SshNet;
using Renci.SshNet.Common;
using Serilog;
using System;
using System.IO;

namespace tool_backup
{
    public class SCPClientManager
    {
        //not key
        private string host_notkey;
        private string username_notkey;
        private string password_notkey;

        //key
        private string host;
        private string username;
        private string keyFilePath;
        private string passphrase;

        
        public SCPClientManager(string host_notkey, string username_notkey, string password_notkey)
        {
            this.host_notkey = host_notkey;
            this.username_notkey = username_notkey;
            this.password_notkey = password_notkey;
        }

        
        public SCPClientManager(string host, string username, string keyFilePath, string passphrase)
        {
            this.host = host;
            this.username = username;
            this.keyFilePath = keyFilePath;
            this.passphrase = passphrase;
        }

        public bool UploadFile(string localFilePath, string remoteFilePath)
        {
            try
            {
                using (var scpClient = CreateScpClient())
                {
                    scpClient.Connect();

                    if (scpClient.IsConnected)
                    {
                        using (var fileStream = new FileStream(localFilePath, FileMode.Open))
                        {
                            scpClient.Upload(fileStream, remoteFilePath);
                        }
                        scpClient.Disconnect();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("SCP: Error during upload: " + ex.Message);
                return false;
            }
        }

        public bool DownloadFile(string remoteFilePath, string localFilePath)
        {
            try
            {
                using (var scpClient = CreateScpClient())
                {
                    scpClient.Connect();

                    if (scpClient.IsConnected)
                    {
                        using (var fileStream = new FileStream(localFilePath, FileMode.Create))
                        {
                            scpClient.Download(remoteFilePath, fileStream);
                        }
                        scpClient.Disconnect();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }

        private ScpClient CreateScpClient()
        {
            if (!string.IsNullOrEmpty(keyFilePath) && !string.IsNullOrEmpty(passphrase))
            {
                var keyFile = new PrivateKeyFile(keyFilePath, passphrase);
                var keyFiles = new[] { keyFile };
                var connectionInfo = new ConnectionInfo(host, username, new[] { new PrivateKeyAuthenticationMethod(username, keyFiles) });
                return new ScpClient(connectionInfo);
            }
            else if (!string.IsNullOrEmpty(password_notkey))
            {
                var connectionInfo = new ConnectionInfo(host_notkey, username_notkey, new[] { new PasswordAuthenticationMethod(username_notkey, password_notkey) });
                return new ScpClient(connectionInfo);
            }

            throw new InvalidOperationException("Invalid authentication method.");
        }
    }
}
