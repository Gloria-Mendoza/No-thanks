using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Media;
using NoThanks.Properties;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<string> languages = new List<string>() { "es-MX", "en-US" };
        private string _CurrentLanguage;
        public string CurrentLanguage
        {
            get
            {
                return _CurrentLanguage;
            }
            private set
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(value);
                _CurrentLanguage = value;
            }
        }

        public static new App Current
        {
            get
            {
                return (App)Application.Current;
            }
        }

        App() {
            CurrentLanguage = languages[0];
        }

        public void SwitchLanguage(string newLanguage)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(newLanguage);
            CurrentLanguage = newLanguage;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Task.Run(() =>
            {
                System.IO.Stream str = NoThanks.Properties.ResourcesSounds.noThanksMusic;
                SoundPlayer musicPlayer = new SoundPlayer(str);
                while (true)
                {
                    musicPlayer.PlaySync();
                }
            });
        }
        
        
    }
}
