using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using MiniForms.Properties;
using NUnit.Framework;

namespace MiniForms.UnitTest
{
    [TestFixture]
    class SettingsTest
    {
        [Test]
        public string ReturnRoamingLocation()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        // http://stackoverflow.com/a/49289/3209230
        // Used this as reference
        [Test]
        public void ChangeSettings()
        {
            // Set default
            Settings.Default.Properties["DefaultTempFolder"].DefaultValue = ReturnRoamingLocation();
            Console.WriteLine(Settings.Default.DefaultTempFolder);

            // Change default
            Settings.Default.DefaultTempFolder = "Temp";
            Console.WriteLine(Settings.Default.DefaultTempFolder);

            // Reset back to default
            Settings.Default.DefaultTempFolder = (string) Settings.Default.Properties["DefaultTempFolder"].DefaultValue; 
            Console.WriteLine(Settings.Default.DefaultTempFolder);
        }
    }
}
