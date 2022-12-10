using log4net;
using Logs;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        private int validationCode;
        private NoThanksService.PlayerManagerClient client = new NoThanksService.PlayerManagerClient();
        private static readonly ILog Log = Logger.GetLogger();

        public ChangePassword()
        {
            InitializeComponent();
            txtToken.Visibility = Visibility.Hidden;
            lbToken.Visibility = Visibility.Hidden;
            btnConfirm.IsEnabled = false;
        }

        #region Listeners
        private void NextClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(pfActualPassword.Password) && !String.IsNullOrWhiteSpace(pfConfirmPassword.Password) && !String.IsNullOrWhiteSpace(pfNewPassword.Password))
            {
                try
                {
                    SendVerification();
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
            }
            else
            {
                MessageBox.Show(Properties.Resources.GENERAL_WHITESPACES_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtToken.Text).Equals(validationCode))
            {
                UpdateNewPassword(Security.PasswordEncryptor.ComputeSHA512Hash(pfNewPassword.Password), Domain.Player.PlayerClient.Email);
            }
            else
            {
                MessageBox.Show(Properties.Resources.CHANGEPASSWORD_INCORRECTTOKEN_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            client.Abort();
            Close();
        }
        #endregion

        public bool SendVerification()
        {
            var result = false;

            Random randomNumber = new Random();
            validationCode = randomNumber.Next(100000, 1000000);
            String affair = "Validation Code";

            if (IsValidPassword())
            {
                if (client.SendValidationEmail(Domain.Player.PlayerClient.Email, affair, validationCode))
                {
                    MessageBox.Show(Properties.Resources.CHANGEPASSWORD_VALIDATIONSEND_MESSAGE, Properties.Resources.GENERAL_SUCCSESSFUL_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                    txtToken.Visibility = Visibility.Visible;
                    lbToken.Visibility = Visibility.Visible;

                    pfActualPassword.IsEnabled = false;
                    pfConfirmPassword.IsEnabled = false;
                    pfNewPassword.IsEnabled = false;
                    btnNext.IsEnabled = false;
                    btnConfirm.IsEnabled = true;
                    result = true;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.GENERAL_CANTSEND_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }

        public void UpdateNewPassword(string password, string email)
        {
            var status = false;
            try
            {
                status = client.UpdatePassword(password, email);
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

            if (status)
            {
                MessageBox.Show(Properties.Resources.CHANGEPASSWORD_SUCCESSFUL_MESSAGE, Properties.Resources.GENERAL_SUCCSESSFUL_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        public bool IsValidPassword()
        {
            bool result = true;
            if (!pfNewPassword.Password.Equals(pfConfirmPassword.Password))
            {
                result = false;
            }

            if (HadValidFormat(pfNewPassword.Password))
            {
                result = false;
            }

            return result;
        }

        private bool HadValidFormat(string password)
        {
            bool invalidPassword = false;
            if (!Regex.IsMatch(password, "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$"))
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_INCORRECTPASSWORD_MESSAGE}", $"{Properties.Resources.GENERAL_ERROR_TITLE}", MessageBoxButton.OK);
                invalidPassword = true;
            }
            return invalidPassword;
        }
    }
}
