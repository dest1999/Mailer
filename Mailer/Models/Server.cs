using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.Models
{
    class Server
    {
        string Address { get; set; }
        int Port { get; set; }
        string UseSSL { get; set; }
        string Login { get; set; }
        string Pssword { get; set; }
        string Description { get; set; }
    }
}
