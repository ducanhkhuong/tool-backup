
using System;
using System.Windows.Forms;

namespace tool_backup
{
    public class datagridview
    {
        private DataGridView dataGridView;

        public datagridview(DataGridView dgv)
        {
            dataGridView = dgv;
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView.ColumnCount = 5;
            dataGridView.Columns[0].Name = "IP";
            dataGridView.Columns[1].Name = "MAC";
            dataGridView.Columns[2].Name = "MAC-eth0";
            dataGridView.Columns[3].Name = "NAME";
            dataGridView.Columns[4].Name = "";
            dataGridView.AllowUserToAddRows = false;
        }

        public void AddRow(string ip, string mac, string mac_eth0)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke((MethodInvoker)delegate
                {
                    dataGridView.Rows.Add(ip, mac , mac_eth0);
                });
            }
            else
            {
                dataGridView.Rows.Add(ip, mac, mac_eth0);
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


        public void SearchByMac(string searchText)
        {
            searchText = searchText.ToLower();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string macAddress = row.Cells[2].Value?.ToString().ToLower();
                if (!string.IsNullOrEmpty(macAddress) && macAddress.Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}

