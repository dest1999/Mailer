using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
namespace Mailer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendMethod() { 
            var mailSender = new MailAddress(tbSenderName.Text);
            var mailRecipient = new MailAddress(tbRecipientName.Text);
            bool isSendError = false;
            using var message = new MailMessage(mailSender, mailRecipient)
            {
                Subject = tbSubject.Text,
                Body = (tbMessage.Text == "") ? $"Письмо отправлено {DateTime.Now}" : $"{tbMessage.Text}\r\n\nПисьмо отправлено {DateTime.Now}"
            };

            using (var client = new SmtpClient("smtp.mail.ru", 25))
            {
                string login = mailSender.Address.ToString();

                client.Credentials = new NetworkCredential(login, passwordBox.SecurePassword );
                client.EnableSsl = (bool)chbUseSSL.IsChecked;

                try
                {
                    client.Send(message);

                }
                catch (Exception)
                {
                    MessageBox.Show("oops, something wrong");
                    isSendError = true;
                }
                finally
                {
                    if (!isSendError)
                        MessageBox.Show("sended");
                }

            };

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMethod();
        }


    }
}
