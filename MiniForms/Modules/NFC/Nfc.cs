using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using MiniForms.Interfaces;
using MiniForms.Process;

namespace MiniForms.Modules.NFC
{
    class Nfc : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private IEnumerable<string> _users = new List<string>();
 
        private string _comPort;
        private int _baudRate;


        public Nfc()
        {
            Name = "NFC";
            Description = "Module for User verification";
            _comPort = "COM3";
            _baudRate = 9600;
        }

        public void EditModule()
        {
            var dia = new DiaNfc();

            dia.SetSelectedUsers(_users);
            dia.ComPort = _comPort;
            dia.Baudrate = _baudRate;
            if (dia.ShowDialog() == DialogResult.OK)
            {
                _comPort = dia.ComPort;
                _baudRate = dia.Baudrate;
                _users = dia.GetSelectedUsers();
            }
        }

        public void Run(ProcessInstance instance)
        {
            var dia = new DiaReadNfc();
            dia.ComPort = _comPort;
            dia.BaudRate = _baudRate;
            if (dia.ShowDialog() == DialogResult.OK)
            {
                if (_users.Any(user => user == dia.User) || dia.User == "Error")
                {

                    return;
                }
                else
                {
                    using (var serialPort = new SerialPort(_comPort, _baudRate))
                    {
                        serialPort.Open();
                        serialPort.Write("Denied");
                        serialPort.Close();
                    }
                    if (
                        MessageBox.Show("Access denied!\rDo you want to try again?", "Access Denied",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Run(instance);
                    }
                    else
                    {
                        instance.IsRunning = false;
                    }

                }
            }
            else
            {
                instance.IsRunning = false;
            }

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
