using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tool_backup
{
    public class DataGridViewManager
    {
        private DataGridView dataGridView;

        public DataGridViewManager(DataGridView dgv)
        {
            dataGridView = dgv;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView.ColumnCount = 5;
            dataGridView.Columns[0].Name = "IP";
            dataGridView.Columns[1].Name = "MAC";
            dataGridView.Columns[2].Name = "NAME";
            dataGridView.Columns[3].Name = "";
            dataGridView.Columns[4].Name = "";
            dataGridView.AllowUserToAddRows = false;
        }

        public void AddRow(string ip, string mac, string hostname)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate
                {
                    dataGridView.Rows.Add(ip, mac, hostname);
                });
            }
            else
            {
                dataGridView.Rows.Add(ip, mac, hostname);
            }
        }

        public void Clear()
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate
                {
                    dataGridView.Rows.Clear();
                });
            }
            else
            {
                dataGridView.Rows.Clear();
            }
        }
    }
}
