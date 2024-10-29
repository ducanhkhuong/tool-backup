using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tool_backup
{
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
}    
