using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net;
using System.Net.Mail;
namespace forTesting
{
    class Program
    {
        static string PingTrace(string toHost, int ttl)
        {
            byte[] arr = { 0x7B, 0x22, 0x62 };
            var pinger = new Ping();
            var pingReply = pinger.Send(toHost, 1000, arr, new PingOptions(ttl, true));
            return pingReply.Address.ToString();
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

        static void Main(string[] args)//args: mailUserName, mailPassword, hostToPing, ttl
        {
            string mailUserName = args[0],
                mailPassword = args[1],
                hostToPing = args[2],
                currentIP = "",
                mbNewIP;
            int ttl = Convert.ToInt32(args[3]);

            while (true)
            {
                mbNewIP = PingTrace(hostToPing, ttl);
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
