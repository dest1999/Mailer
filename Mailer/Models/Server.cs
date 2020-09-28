using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.Models
{
    class Server
    {
        public string Address { get; set; }
        private int port;
        public int Port
        {
            get => port;
            set
            {
                if (value < 0 || value > 65535)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Проверьте номер порта");
                port = value;
            }
        }

        public string UseSSL { get; set; }
        public string Login { get; set; }
        public string Pssword { get; set; }
        public string Description { get; set; }
    }
}
