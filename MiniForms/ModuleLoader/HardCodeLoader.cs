using System.Collections.Generic;
using MiniForms.Interfaces;
using MiniForms.Modules;
using MiniForms.Modules.Email;
using MiniForms.Modules.FileIn;
using MiniForms.Modules.FileOut;
using MiniForms.Modules.NetworkIn;
using MiniForms.Modules.QRcode;
using MiniForms.Modules.NFC;
using MiniForms.Modules.StringReplacer;
using MiniForms.Modules.textToSpeech;
using MiniForms.Modules.VoiceRec;

namespace MiniForms.ModuleLoader
{
    class HardCodeLoader : IModuleLoader
    {
        public IEnumerable<IModuleDetail> GetModuleDetails()
        {
            yield return new ModuleDetail("File In", typeof(FileIn));
            yield return new ModuleDetail("File Out", typeof(FileOut));
            yield return new ModuleDetail("String Replacer", typeof(StringReplacer));
            yield return new ModuleDetail("Email", typeof(Email));
            yield return new ModuleDetail("QRcode Converter", typeof(QRcode));
            yield return new ModuleDetail("Network In", typeof (NetworkIn));
            yield return new ModuleDetail("NFC",typeof(Nfc));
            yield return new ModuleDetail("Voice REC", typeof(VoiceRecognition));
            yield return new ModuleDetail("Text to Speech", typeof(TextToSpeech));
        }
    }
}
