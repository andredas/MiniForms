using System;
using System.IO;
using MiniForms.Properties;

namespace MiniForms
{
    class SettingsLoader
    {
        public void CheckSettings()
        {
            if (Settings.Default.DefaultTempFolder == string.Empty)
            {
                Settings.Default.DefaultTempFolder = ReturnTempPath();
                Settings.Default.Save();
            }
            if (Settings.Default.DefaultOutputFolder == string.Empty)
            {
                Settings.Default.DefaultOutputFolder = ReturnOutputPath();
                Settings.Default.Save();
            }
            if (Settings.Default.DefaultInputFolder == string.Empty)
            {
                Settings.Default.DefaultInputFolder = ReturnInputPath();
                Settings.Default.Save();
            }
            if (Settings.Default.DefaultUserFileLocation == string.Empty)
            {
                Settings.Default.DefaultUserFileLocation = ReturnDesktopPath();
                Settings.Default.Save();
            }

        }

        private string ReturnInputPath()
        {
            return Path.Combine(ReturnDesktopPath(), "Input");
        }

        private string ReturnOutputPath()
        {
            return Path.Combine(ReturnDesktopPath(), "Output");
        }

        private string ReturnTempPath()
        {
            return Path.Combine(ReturnDesktopPath(), "ProcessRunner");
        }

        private string ReturnDesktopPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
    }
}
