using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MiniForms.UnitTest
{
    [TestFixture]
    class ArduinoTest
    {
        [Test]
        public async void ReadSerialPort()
        {
            var data = await ReadLineFromPort();
            Console.WriteLine(data);
        }

        public Task<String> ReadLineFromPort()
        {
            return Task.Run(() =>
            {
                using(var serialPort = new SerialPort("COM3", 9600))
                {
                    serialPort.Open();
                    string read;
                    do
                    {
                        serialPort.Write("Read");
                        read = serialPort.ReadLine().Replace("\u0000", String.Empty);
                    } while (read != "Reading\r");

                    return read;
                }
            });
        }
    }
}
