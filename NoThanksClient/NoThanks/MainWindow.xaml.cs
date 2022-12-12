using log4net;
using Logs;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NoThanksService.PlayerManagerClient client = new NoThanksService.PlayerManagerClient();
        private static readonly ILog Log = Logger.GetLogger();

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
                if (AreValidStrings(username, password) && AreTooLongStrings(username, password))
                {
                    try
                    {
                        LoginAction(username, password);
                    }
                    catch (EndpointNotFoundException ex)
                    {
                        Log.Error($"{ex.Message}");
                        MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (CommunicationObjectFaultedException ex)
                    {
                        Log.Error($"{ex.Message}");
                        MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (TimeoutException ex)
                    {
                        Log.Error($"{ex.Message}");
                        MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        client.Abort();
                    }
                }
                else
                {
                    MessageBox.Show(Properties.Resources.LOGIN_INVALIDFORMAT_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.LOGIN_NOUSERORPASSWORD_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            SignIn register = new SignIn()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
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
            MainMenu mainMenu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };

            mainMenu.Show();
            this.Close();
        }

        private void LoginAction(string username, string password)
        {
            var playerLogin = client.Login(username, Security.PasswordEncryptor.ComputeSHA512Hash(password));

            if (playerLogin != null)
            {
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
                        ProfileImage = playerLogin.ProfileImage,
                        IsGuest = false
                    };

                    MainMenu mainmenu = new MainMenu()
                    {
                        WindowState = this.WindowState,
                        Left = this.Left
                    };
                    mainmenu.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.LOGIN_CANTLOGIN_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool AreValidStrings(string username, string password)
        {
            var isValid = false;
            if(Regex.IsMatch(username, "^[a-zA-Z0-9]*$") && Regex.IsMatch(password, "^[a-zA-Z0-9]*$"))
            {
                isValid = true;
            }
            return isValid;
        }

        private bool AreTooLongStrings(string username, string password)
        {
            var isntTooLong = false;
            if(username.Length <= 45 || password.Length <= 16)
            {
                isntTooLong = true;
            }
            return isntTooLong;
        }
    }
}
