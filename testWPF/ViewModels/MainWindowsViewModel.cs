using System;
using System.Collections.Generic;
using System.Text;
using testWPF.ViewModel;

namespace testWPF.ViewModel
{
    class MainWindowsViewModel : BaseViewModel
    {
        private string _syncText = "123";
        public string SyncText
        {
            get => _syncText;
            set
            {
                if (_syncText == value) return;
                else
                {
                    _syncText = value;
                    OnPropertyChanged(nameof(SyncText));
                }
            }
        }

    }
}
