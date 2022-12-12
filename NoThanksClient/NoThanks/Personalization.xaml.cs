using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Personalization.xaml
    /// </summary>
    public partial class Personalization : Window
    {
        string language = "es-MX";
        
        public Personalization()
        {
            InitializeComponent();
        }

        private void BackBotton(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            mainMenu.Show();
            this.Close();
        }


        private void SelectionLanguage(object sender, SelectionChangedEventArgs e)
        {
            if (cmb.SelectedIndex == 0)
                language = "en-US";
            else
                language = "es-MX";
        }

        private void ConfirmBottom(object sender, RoutedEventArgs e)
        {
            App.Current.SwitchLanguage(language);

            Personalization goPersonalization = new Personalization();
            goPersonalization.Activate();
            goPersonalization.Show();
            this.Close();
        }

    }
}
