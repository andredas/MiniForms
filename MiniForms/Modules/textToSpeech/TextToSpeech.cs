using System.IO;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using MiniForms.Interfaces;
using MiniForms.Modules.voiceToSpeech;
using MiniForms.Process;

namespace MiniForms.Modules.textToSpeech
{
    public class TextToSpeech : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public static SpeechSynthesizer synth;

        public TextToSpeech()
        {
            Name = "Text to Speech";
            Description = "Convert speech input to wav file";
        }

        public void EditModule()
        {
            DiatextToSpeech vts = new DiatextToSpeech(this);
            vts.Show();
        }

        public void Run(ProcessInstance instance)
        {
           
                // Initialize a new instance of the SpeechSynthesizer.
            using (synth = new SpeechSynthesizer())
            {
                // Configure the audio output. 
                synth.SetOutputToWaveFile(Path.Combine(instance.Folder.FullName, "MyWavFile.wav"),
                        new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Eight, AudioChannel.Mono));

                var input = Input;

                // Create a PromptBuilder object and append a text string.
                PromptBuilder song = new PromptBuilder();
                song.AppendText(input);

                // Speak the contents of the prompt asynchronously.
                synth.Speak(song);
            }                                 
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
