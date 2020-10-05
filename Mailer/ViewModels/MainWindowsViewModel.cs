using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Mailer.Data;
using Mailer.Models;
using Mailer.ViewModel;

namespace Mailer.ViewModel
{
    class MainWindowsViewModel : BaseViewModel
    {
        private string _syncText = "Binding OK";
        public string SyncText
        {
            get => _syncText;
            set => Set(ref _syncText, value);
        }

        private ObservableCollection<Server> _servers;
        private ObservableCollection<Sender> _senders;
        private ObservableCollection<Recipient> _recipients;
        private ObservableCollection<Message> _messages;

        public ObservableCollection<Server> Servers
        {
            get => Servers;
            set => Set(ref _servers, value);
        }
        public ObservableCollection<Sender> Senders
        {
            get => Senders;
            set => Set(ref _senders, value);
        }
        public ObservableCollection<Recipient> Recipients
        {
            get => Recipients;
            set => Set(ref _recipients, value);
        }
        public ObservableCollection<Message> Messages
        {
            get => Messages;
            set => Set(ref _messages, value);
        }

        public MainWindowsViewModel()
        {
            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messages);
        }

    }
}
