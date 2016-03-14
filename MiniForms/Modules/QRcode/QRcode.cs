using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniForms.Interfaces;
using MiniForms.Process;
using MiniForms.Properties;

namespace MiniForms.Modules.QRcode
{
    class QRcode : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private Image QrImage { get; set; }

        public QRcode()
        {
            Name = "QRcode";
            Description = "Convert URL or text to QR code image";
        }

        public void EditModule()
        {
            var qr = new DiaQRcode();

            if (qr.ShowDialog() == DialogResult.OK)
            {
                QrImage = qr.QrImage;
            }
        }

        public void Run(ProcessInstance instance)
        {
            using (var b = new Bitmap(QrImage))
            {
                b.Save(Path.Combine(instance.Folder.FullName, "QRimage.jpg"));
            }
            
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
