using System.IO;
using System.Windows.Forms;
using MiniForms.Interfaces;
using MiniForms.Process;

namespace MiniForms.Modules.StringReplacer
{
    class StringReplacer : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Find { get; set; }
        public string Replace { get; set; }

        public StringReplacer()
        {
            Name = "String replace";
            Description = "Replace a word with another word";
        }

        public void EditModule()
        {
            DiaStringReplacer dia = new DiaStringReplacer
            {
                Find = Find,
                Replace = Replace
            };
            if (dia.ShowDialog() == DialogResult.OK)
            {
                Find = dia.Find;
                Replace = dia.Replace;
            }
        }

        public void Run(ProcessInstance instance)
        {
            foreach (FileInfo file in instance.GetFiles())
            {
                File.WriteAllText(file.FullName, File.ReadAllText(file.FullName).Replace(Find, Replace));
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
