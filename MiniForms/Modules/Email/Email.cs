using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniForms.Interfaces;
using MiniForms.Process;

namespace MiniForms.Modules.Email
{
    class Email : IModule
    {
        public string Name { get; set; }
        private MailAddress _from;
        private MailAddress _to;
        private MailAddress _cc;
        private string _subject;
        private string _message;
        public string Description { get; set; }
        
        private readonly int _Port = 587;
        private readonly string _Host = "smtp.gmail.com";
        private readonly string _Username = "advancedformstest1@gmail.com";
        private readonly string _Password = "demoaccount";

        public Email()
        {
            Name = "Email";
        }

        public void EditModule()
        {
            diaEmail dia = new diaEmail
            {
                From = _from,
                To = _to,
                Cc = _cc,
                Subject = _subject,
                Message = _message
            };

            if (dia.ShowDialog() == DialogResult.OK)
            {
                _from = dia.From;
                _to = dia.To;
                _cc = dia.Cc;
                _subject = dia.Subject;
                _message = dia.Message;
            }
        }

        public void Run(ProcessInstance instance)
        {
            using (MailMessage message = new MailMessage
            {
                    From = _from,
                    Subject = _subject,
                    Body = _message
            })
            {

                message.To.Add(_to);
                if (_cc != null)
                    message.CC.Add(_cc);

                foreach (FileInfo file in instance.GetFiles())
                {
                    message.Attachments.Add(new Attachment(file.FullName));
                }

                SmtpClient client = new SmtpClient
                {
                    Port = _Port,
                    Host = _Host,
                    Credentials = new NetworkCredential
                    {
                        UserName = _Username,
                        Password = _Password
                    },
                    EnableSsl = true
                };

                client.Send(message);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
