using System;
using System.IO;
using System.Net;
using System.Text;
using MiniForms.Interfaces;
using MiniForms.Process;

namespace MiniForms.Modules.NetworkIn
{
    class NetworkIn : IModule
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public NetworkIn()
        {
            Name = "NetworkIn";
            Description = "Sent a file to a http IPaddress";
        }

        public void EditModule()
        {
            new DiaNetworkIn().Show();
        }

        public void Run(ProcessInstance instance)
        {
            using (var web = new HttpListener())
            {
                web.Prefixes.Add("Http://+" + ":8080/");
                web.Start();
                foreach (var prefix in web.Prefixes)
                {
                    Console.WriteLine(prefix);
                }
                var context = web.GetContext();
                using (var requestStream = context.Request.InputStream)
                {
                    var filename = context.Request.Headers.Get("filename");
                    using (var fileStream = File.OpenWrite(Path.Combine(instance.Folder.FullName, filename)))
                    {
                        requestStream.CopyTo(fileStream);
                    }
                }
                // Response
                HttpRequestResponse(context);
                web.Stop();
            }
        }

        private static void HttpRequestResponse(HttpListenerContext context)
        {
            var response = context.Response;
            const string responseString = "<html><body>File Received!</body></html>";
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
