using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;

namespace MiniForms.Modules.Email
{
    public partial class diaEmail : Form
    {
        private ErrorProvider _errorProvider = new ErrorProvider();
        public MailAddress From { get; set; }
        public MailAddress To { get; set; }
        public MailAddress Cc { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }


        public diaEmail()
        {
            InitializeComponent();

        }

        private void diaEmail_Load(object sender, EventArgs e)
        {
            if (From != null)
            {
                txtFromName.Text = From.DisplayName;
                txtFromMail.Text = From.Address;
            }
            if (To != null)
            {
                txtToName.Text = To.DisplayName;
                txtToMail.Text = To.Address;
            }
            if (Cc != null)
            {
                txtCCName.Text = Cc.DisplayName;
                txtCCMail.Text = Cc.Address;
            }
            txtSubject.Text = Subject;
            rtbMessage.Text = Message;
        }

        protected bool IsTextValid(TextBox textbox)
        {
            var isEmpty = string.IsNullOrEmpty(textbox.Text);

            if (isEmpty)
            {
                _errorProvider.SetError(textbox, "Cannot be empty");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var requiredFields = new List<TextBox>
                {
                    txtFromMail,
                    txtToMail
                };

                _errorProvider.Clear();

                if (requiredFields.Select(IsTextValid).ToList().Any(x => !x))
                {
                    throw new Exception("Not all fields are filled in");
                }

                From = new MailAddress(txtFromMail.Text, txtFromName.Text);
                To = new MailAddress(txtToMail.Text, txtToName.Text);

                if (!String.IsNullOrEmpty(txtCCMail.Text))
                    Cc = new MailAddress(txtCCMail.Text, txtCCName.Text);

                Subject = txtSubject.Text;
                Message = rtbMessage.Text;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (FormatException exc)
            {
                // Email niet geldig
                MessageBox.Show(@"Ongeldig email: " + exc.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
