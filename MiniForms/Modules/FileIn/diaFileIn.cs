using System;
using System.IO;
using System.Windows.Forms;
using MiniForms.Properties;

namespace MiniForms.Modules.FileIn
{
    public partial class DiaFileIn : Form
    {
        public DiaFileIn()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (Directory.Exists(txtPath.Text))
            {
                Settings.Default.DefaultInputFolder = txtPath.Text;
                Settings.Default.Save();
                Close();
            }
            else
                errorProvider.SetError(txtPath, "The selected folder doesn't exitst");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void diaFileIn_Load(object sender, EventArgs e)
        {
            txtPath.Text = Settings.Default.DefaultInputFolder;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            new FolderBrowserDialog().ShowDialog();
        }
    }
}
