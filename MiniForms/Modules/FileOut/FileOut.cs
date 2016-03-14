using System.IO;
using MiniForms.Interfaces;
using MiniForms.Process;
using MiniForms.Properties;
using MiniForms.Utils;

namespace MiniForms.Modules.FileOut
{
    class FileOut : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public FileOut()
        {
            Name = "FileOut";
            Description = "The file that is the end product of the process";
        }

        public void EditModule()
        {
            new DiaFileOut().Show();
        }

        public void Run(ProcessInstance instance)
        {
            foreach (var file in instance.GetFiles())
            {
                var targetFile = new FileInfo(Path.Combine(Settings.Default.DefaultOutputFolder, file.Name));
                file.CopyTo(targetFile.Unique().FullName);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
