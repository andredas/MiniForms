using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniForms.Services
{
    public class ArduinoReader
    {
        private string _comPort;
        private int _baudRate;

        public ArduinoReader(string comPort, int baudRate)
        {
            _comPort = comPort;
            _baudRate = baudRate;
        }

        public IEnumerable<string> ReadLines(int number = 1)
        {
            using (var serialPort = new SerialPort(_comPort, _baudRate))
            {
                serialPort.Open();
                string read;
                do
                {
                    serialPort.Write("Read");
                    read = serialPort.ReadLine();
                } while (read != "Reading\r");

                for (int i = 0; i < number; i++)
                    yield return serialPort.ReadLine().Replace("\u0000", String.Empty).TrimEnd('\r');
            }
        }

        public void Write(string text)
        {
            using (var serialPort = new SerialPort(_comPort, _baudRate))
            {
                serialPort.Open();
                serialPort.Write(text);
            }
        }
    }
}
