

using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace tool_backup
{
    public class log
    {
        private readonly string logFilePath;

        public log()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataFolder, "LUMI_OS_LOG");
            Directory.CreateDirectory(appFolder);
            logFilePath = Path.Combine(appFolder, "LUMI_OS.log");
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Infinite)
                .CreateLogger();
        }


        public void WriteLog(RichTextBox logApp, string message)
        {
            try
            {
                logApp.AppendText($"[{DateTime.Now}] : {message}\n");
                Log.Information(message);
            }
            catch (Exception ex)
            {
                Log.Error("Error writing log: " + ex.Message);
            }
        }

        public void ClearLog(RichTextBox logApp)
        {
            try
            {
                logApp.Clear();
            }
            catch (Exception ex)
            {
                Log.Error("Error clearing log: " + ex.Message);
            }
        }


        public void CloseLog()
        {
            Log.CloseAndFlush();
        }
    }
}
