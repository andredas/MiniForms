using System;
using System.Drawing;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace MiniForms.Modules.QRcode
{

    public partial class DiaQRcode : Form
    {
        public string URL { get; set; }
        public Image QrImage { get; set; }

        public DiaQRcode()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            URL = txtURL.Text;
            var encoder = new QRCodeEncoder();
            var qrcode = encoder.Encode(URL);
            pbQRcode.Image = qrcode;
            QrImage = pbQRcode.Image;
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
