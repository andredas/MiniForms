using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniForms.Properties;

namespace MiniForms.Modules.NetworkIn
{
    public partial class DiaNetworkIn : Form
    {
        public DiaNetworkIn()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.DefaultPort = Convert.ToInt32(txtPort.Text);
            Settings.Default.Save();
            Close();
        }

        private void DiaNetworkIn_Load(object sender, EventArgs e)
        {
            txtPort.Text = Settings.Default.DefaultPort.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
