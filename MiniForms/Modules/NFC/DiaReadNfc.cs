using System;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniForms.Modules.NFC
{
    public partial class DiaReadNfc : Form
    {
        public string User { get; set; }
        public string ComPort { get; set; }
        public int BaudRate { get; set; }
        public DiaReadNfc()
        {
            InitializeComponent();
        }

        private async void DiaNfc_Shown(object sender, EventArgs e)
        {
            User = await ReadLineFromPort();
            DialogResult = DialogResult.OK;
        }

        public Task<String> ReadLineFromPort()
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var serialPort = new SerialPort(ComPort, BaudRate))
                    {
                        serialPort.Open();
                        string read;
                        do
                        {
                            serialPort.Write("Read");
                            read = serialPort.ReadLine();
                        } while (read != "Reading\r");

                        read = serialPort.ReadLine().Replace("\u0000", String.Empty).TrimEnd('\r');
                        return read;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "Error";
                }
            });
        }
    }
}
