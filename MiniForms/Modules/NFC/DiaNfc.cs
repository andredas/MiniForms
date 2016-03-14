using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniForms.Modules.NFC
{
    public partial class DiaNfc : Form
    {
        public string ComPort { get; set; }
        public int Baudrate { get; set; }

        private ErrorProvider _errorProvider = new ErrorProvider();

        public DiaNfc()
        {
            InitializeComponent();
        }

        protected void SwapAllItems(ListBox currentList, ListBox targetList)
        {
            foreach (var item in currentList.Items)
            {
                targetList.Items.Add(item);
            }
            currentList.Items.Clear();
        }

        protected void SwapItem(ListBox currentList, ListBox targetList)
        {
            if (currentList.SelectedItem != null)
            {
                targetList.Items.Add(currentList.SelectedItem);
                currentList.Items.Remove(currentList.SelectedItem);
            }
        }


        private void btnRight_Click(object sender, EventArgs e)
        {
            SwapItem(lbLeft,lbRight);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            SwapItem(lbRight, lbLeft);
        }

        private void btnAllRight_Click(object sender, EventArgs e)
        {
            SwapAllItems(lbLeft, lbRight);
        }

        private void btnAllLeft_Click(object sender, EventArgs e)
        {
            SwapAllItems(lbRight, lbLeft);
        }

        public IEnumerable<string> GetSelectedUsers()
        {
            return from object item in lbRight.Items select item.ToString();
        }

        public void SetSelectedUsers(IEnumerable<string> users)
        {
            foreach (var user in users)
            {
                lbRight.Items.Add(user);
                lbLeft.Items.Remove(user);
            }
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
                    txtComPort,
                    txtBaudrate
                };

                _errorProvider.Clear();

                if (requiredFields.Select(IsTextValid).ToList().Any(x => !x))
                {
                    throw new Exception("Not all required fields are filled in");
                }

                ComPort = txtComPort.Text;
                Baudrate = Convert.ToInt32(txtBaudrate.Text);

                DialogResult = DialogResult.OK;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DiaNfc_Load(object sender, EventArgs e)
        {
            txtComPort.Text = ComPort;
            txtBaudrate.Text = Baudrate.ToString();
        }
    }
}
