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

        static string GetIP(out bool IPaddressOK)
        {
            try
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
                IPaddressOK = true;
                return a[0].ToString();

            }
            catch (Exception)
            {
                IPaddressOK = false;
                return "";
            }


        }

        static void SendMessage(string mailUserName, string mailPassword, string body, out bool sendingOK)
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

                try
                {
                    client.Send(message);
                    sendingOK = true;
                }
                catch (Exception)
                {
                    sendingOK = false;
                }

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
                Console.Clear();
                string mailUserName = args[0],
                    mailPassword = args[1],
                    currentIP = "",
                    mbNewIP;
                while (true)
                {
                    mbNewIP = GetIP(out bool IPaddressOK);
                    if (currentIP != mbNewIP && IPaddressOK)
                    {
                        currentIP = mbNewIP;
                        Console.WriteLine($"{DateTime.Now} your IP is {currentIP}");
                        SendMessage(mailUserName, mailPassword, currentIP, out bool sendingOK);
                        if (!sendingOK)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{DateTime.Now} error sending e-mail. Check username, password and connection");
                            Console.ResetColor();
                        }
                    }
                    Thread.Sleep(60000);
                }
            }
            
        }
    }
}
