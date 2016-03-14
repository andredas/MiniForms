using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace MiniForms.UnitTest
{
    [TestFixture]
    public class HttpTest
    {
        [Test]
        public void ListenForIncoming()
        {
            var web = new HttpListener();
            web.Prefixes.Add("http://+:8080/");
            web.Start();
            while (true)
            {
                var context = web.GetContext();
                using (var requestStream = context.Request.InputStream)
                {
                    //var filename = context.Request.Headers.Get("filename");
                    var filename = context.Request.Headers.Keys;

                    //using (var fileStream = File.OpenWrite(@"C:\Users\Napok\Desktop\download\" + Guid.NewGuid() + Path.GetExtension(filename)))
                    //{

                    //    requestStream.CopyTo(fileStream);
                    //}    
                }
                

                var response = context.Response;
                const string responseString = "<html><body>File Received!</body></html>";
                var buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                Console.WriteLine(output);
                output.Close();
            }
        }
    }
}
