using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using enelex3.Windows;

namespace enelex3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var vCulture = new CultureInfo("sr-SR");

            Thread.CurrentThread.CurrentCulture = vCulture;
            Thread.CurrentThread.CurrentUICulture = vCulture;
            CultureInfo.DefaultThreadCurrentCulture = vCulture;
            CultureInfo.DefaultThreadCurrentUICulture = vCulture;

            FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(
            XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            LogInWindow logIn = new LogInWindow();
            if (logIn.ShowDialog() != true) return;
            else StartupUri = new Uri("/application:,,,/Windows/LogInWindow.xaml",
                    UriKind.Relative);

            base.OnStartup(e);
          
           

        }
        protected override void OnExit(ExitEventArgs e)
        {
            enelex3.Properties.Settings.Default.Save();
            base.OnExit(e);
        }

       
    }
}
