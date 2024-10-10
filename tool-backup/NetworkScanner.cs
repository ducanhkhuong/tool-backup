using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace tool_backup
{
    public class NetworkScanner
    {
        public void ScanNetworks(Action<string> logAction, string ipRange, CancellationToken cancellationToken)
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus == OperationalStatus.Up)
                {
                    var ipProperties = network.GetIPProperties();
                    var ipv4Addresses = ipProperties.UnicastAddresses
                        .Where(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);

                    foreach (var ip in ipv4Addresses)
                    {
                        if (cancellationToken.IsCancellationRequested) 
                        {
                            return;
                        }

                        logAction($"Network: {network.Name}, IP: {ip.Address}");

                        ScanIpRange(ipRange, logAction, cancellationToken);
                    }
                }
            }
        }


        public void ScanIpRange(string ipRange, Action<string> logAction, CancellationToken cancellationToken)
        {
            var parts = ipRange.Split('.');
            if (parts.Length != 4)
            {
                logAction("Invalid IP range format. Use 'xxx.xxx.xxx.xxx'.");
                return;
            }

            var baseIp = $"{parts[0]}.{parts[1]}.{parts[2]}.";

            for (int i = 1; i <= 255; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                string currentIp = baseIp + i;

                if (PingIp(currentIp))
                {
                    string macAddress = GetMacAddress(currentIp);
                    logAction($"Ping success: {currentIp} ----- MAC Address: {macAddress}");
                }
                else
                {
                    logAction($"Ping failed: {currentIp}");
                }
            }
        }



        private bool PingIp(string ipAddress)
        {
            using (var ping = new Ping())
            {
                try
                {
                    var reply = ping.Send(ipAddress, 500);
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
            var startInfo = new System.Diagnostics.ProcessStartInfo("arp", $"-a {ipAddress}")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (var process = System.Diagnostics.Process.Start(startInfo))
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
    }
}
