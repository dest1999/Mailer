using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.IO;
namespace forTesting
{
    class Program
    {
        static string PingTrace(string toHost, int ttl) //это не покажет внешний адрес роутера((( Нужен внешнний сервер. Либо использовать Dns.GetHostEntry(Dns.GetHostName ())
        {
            byte[] arr = { 0x7B, 0x22, 0x62 };
            var pinger = new Ping();
            var pingReply = pinger.Send(toHost, 1000, arr, new PingOptions(ttl, true));
            return pingReply.Address.ToString();
        }

        static string GetIP()
        {
            var req = WebRequest.Create("http://checkip.dyndns.org");
            string reqstring;

            using (var reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                reqstring = reader.ReadToEnd();
            }
            string[] a = reqstring.Split(':');
            string a2 = a[1].Substring(1);
            a = a2.Split('<');
            return a[0].ToString();
        }

        static void SendMessage(string mailUserName, string mailPassword, string body)
        {
            var sender = new MailAddress(mailUserName);
            var recipient = new MailAddress(mailUserName);

            using var message = new MailMessage(sender, recipient)
            {
                Subject = "New address",
                Body = body
            };

            using (var client = new SmtpClient("smtp.mail.ru", 25))
            {
                client.Credentials = new NetworkCredential(mailUserName, mailPassword);
                client.EnableSsl = true;
                client.Send(message);
            };
        }

        static void Main(string[] args)//args: mailUserName, mailPassword
        {
            if (args.Length != 2)
            {
                Console.WriteLine("The arguments are: mailUserName, mailPassword");
            }
            else
            {
                string mailUserName = args[0],
                    mailPassword = args[1],
                    currentIP = "",
                    mbNewIP;
                while (true)
                {
                    mbNewIP = GetIP();
                    if (currentIP != mbNewIP)
                    {
                        currentIP = mbNewIP;
                        Console.WriteLine($"Your IP is {currentIP}, {DateTime.Now}");
                        SendMessage(mailUserName, mailPassword, currentIP);

                    }
                    Thread.Sleep(60000);
                }
            }
            
        }
    }
}
