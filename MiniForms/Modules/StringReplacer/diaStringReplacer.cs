using System;
using System.Windows.Forms;

namespace MiniForms.Modules.StringReplacer
{
    public partial class DiaStringReplacer : Form
    {
        public string Find { get; set; }
        public string Replace { get; set; }

        public DiaStringReplacer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (txtFind.Text != "")
            {
                Find = txtFind.Text;
                Replace = txtReplace.Text;

                DialogResult = DialogResult.OK;
            }
            else
                errorProvider.SetError(txtFind, "The \"text to replace\" field must be filled in");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void diaStringReplace_Load(object sender, EventArgs e)
        {
            txtFind.Text = Find;
            txtReplace.Text = Replace;
        }
    }
}
