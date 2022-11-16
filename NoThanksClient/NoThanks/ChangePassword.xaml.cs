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
                MessageBox.Show("No puedes dejar campos vacios", "Upss", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                MessageBox.Show("Token Incorrecto", "Upss", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                    MessageBox.Show("Código de validación enviado con exito");
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
                MessageBox.Show("No se pudo enviar el codigo", "Upss", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }

        public void UpdateNewPassword(string password, string email)
        {
            if (client.UpdatePassword(password, email))
            {
                //TODO
                MessageBox.Show("La contraseña ha sido cambiada con exito", "Yay", MessageBoxButton.OK, MessageBoxImage.Information);
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
