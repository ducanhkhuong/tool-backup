
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tool_backup
{

    public class NetworkManager
    {
        public DataGridViewManager dgvManager;

        public NetworkManager(DataGridView dataGridView)
        {
            dgvManager = new DataGridViewManager(dataGridView);
        }

        public void ScanNetworks(string ipRange)
        {
            //quét ip không quan tâm đến các giao diện mạng
            ScanIpRange(ipRange); 
        }

        private async void ScanIpRange(string ipRange){
            var parts = ipRange.Split('.');
            if (parts.Length != 4)
            {
                return;
            }

            var baseIp = $"{parts[0]}.{parts[1]}.{parts[2]}.";
            var tasks = new Task[255];
            var scannedIps = new HashSet<string>();
            dgvManager.Clear();
            for (int i = 0; i < 255; i++)
            {
                string currentIp = baseIp + (i + 1);
                if (scannedIps.Contains(currentIp))
                {
                    continue;
                }
                scannedIps.Add(currentIp);

                tasks[i] = Task.Run(async () =>
                {
                    if (await PingIpAsync(currentIp))
                    {
                        string macAddress = GetMacAddress(currentIp);
                        string hostname = GetHostname(currentIp);
                        dgvManager.AddRow(currentIp, macAddress, hostname);
                    }
                    else
                    {
                        dgvManager.AddRow(currentIp, "", "");
                    }
                });
            }

            try
            {
                await Task.WhenAll(tasks);
                MessageBox.Show("Successfully Scanner !");
            }
            catch (Exception)
            {
                ;
                MessageBox.Show("Error Scanner");
            }
        }


  

        private async Task<bool> PingIpAsync(string ipAddress)
        {
            using (var ping = new Ping())
            {
                try
                {
                    IPAddress ipAddr = IPAddress.Parse(ipAddress);
                    var reply = await ping.SendPingAsync(ipAddr, 50);
                    return reply.Status == IPStatus.Success;
                }
                catch
                {
                    return false;
                }
            }
        }

        private string GetMacAddress(string ipAddress)
        {
            var macAddress = "N/A";
            var startInfo = new ProcessStartInfo("arp", $"-a {ipAddress}")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (var process = Process.Start(startInfo))
            {
                using (var reader = process.StandardOutput)
                {
                    string output = reader.ReadToEnd();
                    var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines)
                    {
                        if (line.Contains(ipAddress))
                        {
                            var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            macAddress = parts.Length > 1 ? parts[1] : macAddress;
                            break;
                        }
                    }
                }
            }
            return macAddress;
        }

        private string GetHostname(string ipAddress)
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(ipAddress);
                return hostEntry.HostName;
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Failed to resolve hostname for {ipAddress}. Error: {ex.Message}");
                return "Unknown";
            }
        }
    }
}

