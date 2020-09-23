using System;

using System.Net;
using System.Net.Mail;
namespace forTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new MailAddress("serv_all@mail.ru", "send");
            var recipient = new MailAddress("serv_all@bk.ru");

            using var message = new MailMessage(sender, recipient)
            {
                Subject = "Тема письма",
                Body = $"Письмо отправлено {DateTime.Now}"
            };

            using (var client = new SmtpClient("smtp.mail.ru", 25))
            {
                string login = "serv_all@mail.ru";
                string password = "gggggggggggg"; //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                client.Credentials = new NetworkCredential(login, password);
                client.EnableSsl = true;
                
                client.Send(message);


            };



            Console.WriteLine("Sending complete");
            Console.ReadKey();
        }
    }
}
