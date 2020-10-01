using Mailer.lib.Service;
using Mailer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mailer.Data
{
    static class TestData
    {
        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10).Select(i => new Sender
        {
            Name = $"Отправитель {i}",
            Address = $"sender-{i}@server"
        }).ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10).Select(i => new Recipient
        {
            Name = $"Получатель {i}",
            Address = $"recipient-{i}@server"
        }).ToList();

        public static List<Server> Servers { get; } = Enumerable.Range(1, 10).Select(i => new Server
        {
            Address = $"{i}srvAdr",
            Login = $"{i} login",
            Password = TextEncoder.Encode($"pass {i}"),
            UseSSL = i % 2 == 1
            
        }).ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 20).Select(
            i => new Message
            {
                Subject = $"сообщение {i}",
                Body = $"текст {i}"
            }).ToList();
    }
}
