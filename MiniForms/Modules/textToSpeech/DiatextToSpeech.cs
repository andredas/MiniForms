using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniForms.Modules.textToSpeech;

namespace MiniForms.Modules.voiceToSpeech
{
    public partial class DiatextToSpeech : Form
    {
        
        private TextToSpeech _vtp;

        public DiatextToSpeech(TextToSpeech vtp)
        {
            InitializeComponent();
            _vtp = vtp;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _vtp.Input = txtInput.Text;
            Close();
        }
    }
}
