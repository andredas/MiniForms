using System.IO;

namespace MiniForms.Utils
{
    public static class FileNameUtils
    {
        public static FileInfo Unique(this FileInfo file)
        {
            var path = file.FullName;
            int i = 0;

            while (File.Exists(path))
            {
                i++;
                path = Path.Combine(
                    file.DirectoryName,
                    Path.GetFileNameWithoutExtension(file.Name) + "_" + i + file.Extension);
            }

            return new FileInfo(path);
        }
    }
}
