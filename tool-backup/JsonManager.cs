using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class AIConfig
{
    public string username { get; set; }
    public string key { get; set; }
    public string pathhome { get; set; }
    public string pathDB { get; set; }
    public string pathlog { get; set; }
}

public class Config
{
    [JsonProperty("MT7688")]
    public AIConfig AIV2 { get; set; }
}


namespace tool_backup
{
    public class JsonManager
    {
        private string filePath;

        public void ConfigReader(string jsonFilePath)
        {
            filePath = jsonFilePath;
        }

        public Config ReadConfig()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(filePath);
                    Config config = JsonConvert.DeserializeObject<Config>(jsonContent);
                    return config;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error read file JSON: {ex.Message}");
                }
            }
            else
            {
                throw new FileNotFoundException("File setting.json không tồn tại.");
            }
        }
    }
}

