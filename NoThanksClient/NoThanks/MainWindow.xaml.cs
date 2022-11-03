using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Windows;


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
            try
            {           
                LoginAction();
            }
            catch (EndpointNotFoundException)
            {
                //TODO
                MessageBox.Show("No se pudo establecer conexión con el servidor", "Upss", MessageBoxButton.OK);
            }

        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            //TODO
            SignIn register = new SignIn();
            register.Show();
            this.Close();
        }

        private void GuestClick(object sender, RoutedEventArgs e)
        {
            Domain.Player.PlayerClient = new Domain.Player()
            {
                Nickname = $"Guest{new Random().Next()}"
            };
            MenuPrincipal go = new MenuPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };

            go.Show();
            this.Close();
        }

        private void LoginAction()
        {
            var username = txtUsername.Text;
            var password = pfPassword.Password;

            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();
                var playerLogin = client.Login(username, ComputeSHA512Hash(password));
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

        private string ComputeSHA512Hash(string input)
        {
            var encryptedPassword = "";
            using (SHA512 sHA512Hash = SHA512.Create())
            {
                byte[] hash = sHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                encryptedPassword = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToLowerInvariant();
            }
            return encryptedPassword;
        }
    }
}
