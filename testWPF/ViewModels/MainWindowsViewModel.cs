using System;
using System.Collections.Generic;
using System.Text;
using testWPF.ViewModel;

namespace testWPF.ViewModels
{
    public class MainWindowsViewModel : BaseViewModel
    {
        private string _syncText;
        public string SyncText
        {
            get => _syncText;
            set
            {
                _syncText = value;
                OnPropertyChanged(nameof(SyncText));
            }
        }

    }
}
