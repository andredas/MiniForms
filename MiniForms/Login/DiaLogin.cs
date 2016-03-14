using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniForms.Services;

namespace MiniForms.Login
{
    public partial class DiaLogin : Form
    {
        private AuthericationService _AuthericationService = new AuthericationService();
        private string _comPort = "COM3";
        private int _baudRate = 9600;

        public DiaLogin()
        {
            InitializeComponent();
        }

        private void DiaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(DialogResult != DialogResult.OK)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_AuthericationService.IsValid(txtUsername.Text, txtPassword.Text))
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Username and/or password is incorrect!");
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnLogin_Click(sender, e);
            }
        }

        private async void btnNfc_Click(object sender, EventArgs e)
        {
            btnNfc.Enabled = false;
            if (await LoginWithSerialPort())
                DialogResult = DialogResult.OK;
            btnNfc.Enabled = true;

        }

        public Task<bool> LoginWithSerialPort()
        {
            return Task.Run(() =>
            {
                try
                {
                    var arduino = new ArduinoReader(_comPort, _baudRate);

                    var lines = arduino.ReadLines(2).ToList();
                    if (_AuthericationService.IsValid(lines[0], lines[1]))
                        return true;

                    arduino.Write("Denied");

                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            });
        }
    }
}
