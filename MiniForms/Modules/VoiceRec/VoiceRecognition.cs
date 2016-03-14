using System.IO;
using MiniForms.Interfaces;
using MiniForms.Process;

namespace MiniForms.Modules.VoiceRec
{
    public class VoiceRecognition : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }

        public VoiceRecognition()
        {
            Name = "Voice REC";
        }

        public void EditModule()
        {
            new DiaVoiceRec(this).Show();    
        }

        public void Run(ProcessInstance instance)
        {
            var input = Input;
            File.WriteAllText(Path.Combine(instance.Folder.FullName, "Input.txt"), input);   
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
