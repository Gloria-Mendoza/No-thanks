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
        protected override void OnStartup(StartupEventArgs e)
        {
            var langCode = NoThanks.Properties.Settings.Default.LanguageCode;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(langCode);   
            base.OnStartup(e);

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
