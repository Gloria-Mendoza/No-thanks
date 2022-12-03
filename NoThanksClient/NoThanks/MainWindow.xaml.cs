using Microsoft.Win32;
using System;
using System.Media;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;


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
        

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = pfPassword.Password;
            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                try
                {
                    LoginAction(username, password);
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.LOGIN_NOUSERORPASSWORD_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            SignIn register = new SignIn();
            register.Show();
            this.Close();
        }

        private void GuestClick(object sender, RoutedEventArgs e)
        {
            Domain.Player.PlayerClient = new Domain.Player()
            {
                Nickname = $"Guest{new Random().Next()}",
                IsGuest = true
            };
            MenuPrincipal go = new MenuPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };

            go.Show();
            this.Close();
        }

        private void LoginAction(string username, string password)
        {
            PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();
            var playerLogin = client.Login(username, Security.PasswordEncryptor.ComputeSHA512Hash(password));

            if (playerLogin.Status)
            {
                Domain.Player.PlayerClient = new Domain.Player()
                {
                    IdPlayer = playerLogin.IdPlayer,
                    Nickname = playerLogin.Nickname,
                    Name = playerLogin.Name,
                    LastName = playerLogin.LastName,
                    Email = playerLogin.Email,
                    TotalScore = playerLogin.TotalScore,
                    IsGuest = false
                };

                MenuPrincipal go = new MenuPrincipal()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                go.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(Properties.Resources.LOGIN_CANTLOGIN_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            client.Close();
            
        }
    }
}
