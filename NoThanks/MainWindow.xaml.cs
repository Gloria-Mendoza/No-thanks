using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginAction()
        {
            var username = txtUsername.Text;
            var password = pfPassword.Password;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();
                var aux = client.Login(username, password);
                if (aux)
                {
                    //TODO
                    MessageBox.Show("Funciona", "Yeah",MessageBoxButton.OK);
                }
                else
                {
                    //TODO
                    MessageBox.Show("No Funciona", "Upss", MessageBoxButton.OK);
                }
            }
            else
            {
                //TODO
                MessageBox.Show("Debes ingresar tú usuario y contraseña");
            }
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginAction();
            }
            catch (EntityException entityException)
            {
                //TODO
                Console.WriteLine(entityException.Message);
            }

        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            //TODO
        }
    }
}
