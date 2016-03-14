using System.IO;
using System.Linq;
using MiniForms.Interfaces;
using MiniForms.Process;
using MiniForms.Properties;

namespace MiniForms.Modules.FileIn
{
    class FileIn : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public FileIn()
        {
            Name = "FileIn";
            Description = "Select a file and use it for the process";
        }

        public void EditModule()
        {
            new DiaFileIn().Show();
        }

        public void Run(ProcessInstance instance)
        {
            string file = 
                Directory.GetFiles(Settings.Default.DefaultInputFolder).FirstOrDefault();
            instance.InsertFile(file);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
