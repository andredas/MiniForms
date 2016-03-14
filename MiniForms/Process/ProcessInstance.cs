using System.Collections.Generic;
using System.IO;

namespace MiniForms.Process
{
    public class ProcessInstance
    {
        public DirectoryInfo Folder { get; set; }
        public bool IsRunning { get; set; }

        public ProcessInstance(DirectoryInfo folder)
        {
            IsRunning = true;
            Folder = folder;
        }

        public void InsertFile(string path)
        {
            if(path != null)
                File.Move(path, Path.Combine(Folder.FullName, Path.GetFileName(path)));
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            return Folder.GetFiles();
        }

        public void CleanUp()
        {
            Folder.Delete(true);
        }
    }
}