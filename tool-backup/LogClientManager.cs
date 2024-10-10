using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace tool_backup
{
    public class LogClientManager
    {
        private readonly string logFilePath;
        private long lastReadPosition;

        public LogClientManager(string logFilePath)
        {
            this.logFilePath = logFilePath;
            lastReadPosition = 0;
        }

        public void ReadLog(RichTextBox logApp)
        {
            try
            {
                using (FileStream fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fs.Seek(lastReadPosition, SeekOrigin.Begin);
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        string newLine;
                        while ((newLine = reader.ReadLine()) != null)
                        {
                            logApp.AppendText(newLine + Environment.NewLine);
                            logApp.SelectionStart = logApp.Text.Length;
                            logApp.ScrollToCaret();
                        }
                        lastReadPosition = fs.Position;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error reading log file: " + ex.Message);
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
                Log.Error("Error clearing log file: " + ex.Message);
            }
        }
    }
}
