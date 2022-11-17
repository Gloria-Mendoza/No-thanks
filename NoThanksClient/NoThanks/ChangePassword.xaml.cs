using System;
using System.Windows;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        private int validationCode;
        private PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();

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
                SendVerification();
            }
            else
            {
                //TODO
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
                //TODO
                MessageBox.Show(Properties.Resources.CHANGEPASSWORD_INCORRECTTOKEN_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            client.Close();
            Close();
        }
        #endregion

        public bool SendVerification()
        {
            var result = false;

            Random randomNumber = new Random();
            validationCode = randomNumber.Next(100000, 1000000);
            String affair = "Validation Code";

            if (ValidatePassword())
            {
                if (client.SendValidationEmail(Domain.Player.PlayerClient.Email, affair, validationCode))
                {
                    //TODO
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
                //TODO
                MessageBox.Show(Properties.Resources.GENERAL_CANTSEND_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }

        public void UpdateNewPassword(string password, string email)
        {
            if (client.UpdatePassword(password, email))
            {
                //TODO
                MessageBox.Show(Properties.Resources.CHANGEPASSWORD_SUCCESSFUL_MESSAGE, Properties.Resources.GENERAL_SUCCSESSFUL_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        public bool ValidatePassword()
        {
            bool result = true;
            if (!pfNewPassword.Password.Equals(pfConfirmPassword.Password))
            {
                result = false;
            }

            return result;
        }
    }
}
