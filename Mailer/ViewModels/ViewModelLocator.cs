using Mailer.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowsViewModel mainWindowsModel => App.Services.GetRequiredService<MainWindowsViewModel>();
    }
}
