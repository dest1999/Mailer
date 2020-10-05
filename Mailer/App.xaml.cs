using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Mailer.ViewModel;

namespace Mailer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost _hosting;

        public static IHost hosting => _hosting ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs()).ConfigureServices(ConfigureServices).Build();

        public static IServiceProvider Services => hosting.Services;
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowsViewModel>();
        }
    }
}
