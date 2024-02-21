using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
            dgUsers.Rows.Add(new string[] { "Sysop", "192.168.1.142", "false" });
        }

        private void btnUpdateUsers_Click(object sender, EventArgs e)
        {

        }
    }
}
