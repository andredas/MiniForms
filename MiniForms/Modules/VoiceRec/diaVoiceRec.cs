using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace MiniForms.Modules.VoiceRec
{
    public partial class DiaVoiceRec : Form
    {
        readonly SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer _monica = new SpeechSynthesizer();
        public bool StartSpeaking;
        private readonly VoiceRecognition _vg;

        public DiaVoiceRec(VoiceRecognition vg)
        {
            InitializeComponent();
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(LoadCommands()))));
            _recognizer.SpeechRecognized += (_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            _vg = vg;
        }

        public string[] LoadCommands()
        {
            var lst = new List<string>();
            using (var fs = File.Open(@"Commands.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var bs = new BufferedStream(fs))
            using (var sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lst.Add(line);
                }
            }
            return lst.ToArray();
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (StartSpeaking)
            {
                _vg.Input += string.Format("{0} ", e.Result.Text);
                txtInput.Text += string.Format("{0} ", e.Result.Text);
            }
        }

        public void StopRec()
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            StartSpeaking = false;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                _monica.SpeakAsync("Sorry,  I can't read without text, Enter text first");
            }
            else
            {
                _monica.Dispose();
                _monica = new SpeechSynthesizer();
                _monica.SpeakAsync(txtInput.Text); 
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            StartSpeaking = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopRec();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
