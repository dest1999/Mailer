using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace Mailer.lib
{
    class MailSenderService
    {
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool SSL { get; set; }

        public void SendMethod(string SenderAdr, string RecipientAdr, string Subj, string Body)
        {
            var mailSender = new MailAddress(SenderAdr);
            var mailRecipient = new MailAddress(RecipientAdr);
            
            using var message = new MailMessage(mailSender, mailRecipient)
            {
                Subject = Subj,
                Body = (Body.Length == 0) ? $"Письмо отправлено {DateTime.Now}" : $"{Body}\r\n\nПисьмо отправлено {DateTime.Now}"
            };

            using (var client = new SmtpClient(ServerAddress, ServerPort))
            {
                string login = mailSender.Address.ToString();

                client.Credentials = new NetworkCredential(login, Password);
                client.EnableSsl = SSL;

                try
                {
                    client.Send(message);

                }
                catch (SmtpException e)
                {
                    Trace.TraceError(e.ToString());
                    throw;
                    
                }
                //finally
                //{
                //    if (!isSendError)
                //        MessageBox.Show("sended");
                //}

            };

        }
    }
}
