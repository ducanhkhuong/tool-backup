
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace tool_backup
{
    // Class ComboBoxItem
    public class ComboBoxItem
    {
        public string DisplayText { get; }
        public string Value { get; }

        public ComboBoxItem(string displayText, string value)
        {
            DisplayText = displayText;
            Value = value;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }

    // Class OptionManager
    public class OptionManager
    {
        private List<ComboBoxItem> items;

        public OptionManager()
        {
            items = new List<ComboBoxItem>();
        }

        public void AddItem(string displayText, string value)
        {
            items.Add(new ComboBoxItem(displayText, value));
        }

        public List<ComboBoxItem> GetItems()
        {
            return items;
        }

        public string GetSelectedValue(ComboBoxItem selectedItem)
        {
            return selectedItem?.Value;
        }
    }

    // Class AIConfig
    public class AIConfig
    {
        public string username { get; set; }
        public string key { get; set; }
        public string pathhome { get; set; }
        public string pathDB { get; set; }
        public string pathlog { get; set; }
        public string stop { get; set; }
        public string start { get; set; }
    }

    // Class Config
    public class Config
    {
        [JsonProperty("MT7688")]
        public AIConfig MT { get; set; }

        [JsonProperty("AI-V2")]
        public AIConfig AI_V2 { get; set; }

        [JsonProperty("AI-V3")]
        public AIConfig AI_V3 { get; set; }
    }

    // Class JsonManager
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
                    throw new Exception($"Error reading JSON file: {ex.Message}");
                }
            }
            else
            {
                throw new FileNotFoundException("File setting.json does not exist.");
            }
        }
    }
}