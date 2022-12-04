using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        String name = "";
        String lastName = "";
        String username = "";
        String email = "";
        String password = "";
        String repeatPassword = "";

        public SignIn()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SignInAction()
        {
            name = txtName.Text;
            lastName = txtLastName.Text;
            username = txtUsername.Text;
            email = txtEmail.Text;
            password = pfPassword.Password;
            repeatPassword = pfRepeatPassword.Password;
            PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();
            /*var exitsEmail = client.ExitsEmail(email);
            var exitsNickname = client.ExitsNickname(username);
            if (exitsEmail == true)
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_REPEATEDEMAIL_MESSAGE}", $"{Properties.Resources.SIGNIN_REPEATEDEMAIL_MESSAGEWINDOW}", MessageBoxButton.OK);
            }
            if (exitsNickname == true)
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_REPEATEDUSERNAME_MESSAGE}", $"{Properties.Resources.SIGNIN_REPEATEDUSERNAME_MESSAGEWINDOW}", MessageBoxButton.OK);
            }*/

            if (!ExistsInvalidFields()) //&& !exitsEmail && !exitsNickname)
            {
                string passwordHashed = Security.PasswordEncryptor.ComputeSHA512Hash(password);
                Player player = new Player()
                {
                    Name = name,
                    LastName = lastName,
                    Nickname = username,
                    Email = email,
                    Password = passwordHashed
                };
                var result = client.SendCode(email);

                if (result)
                {
                    VerifyEmail verifyEmail = new VerifyEmail();
                    verifyEmail.ShowDialog();
                    var resultCode = verifyEmail.GetVerifyEmail();
                    var aux = client.Register(player);
                    if (aux && resultCode)
                    {
                        //TODO
                        MessageBox.Show($"{Properties.Resources.SIGNIN_CONFIRMATION_MESSAGE}", $"{Properties.Resources.SIGNIN_CONFIRMATION_MESSAGEWINDOW}", MessageBoxButton.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGE}", $"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGEWINDOW}", MessageBoxButton.OK);
                    }
                }
                else
                {
                    //TODO
                    MessageBox.Show($"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGE}", $"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGEWINDOW}", MessageBoxButton.OK);
                }
            }
        }

        private Boolean ExistsInvalidFields()
        {
            Boolean invalidFields = false;
            if (ExistsEmptyFields() || ExistsInvalidStrings() || ExistsExcessLength() || ExistIncorrectPassword()
                || ExistsInvalidPassword(password))
            {
                invalidFields = true;
            }
            return invalidFields;
        }

        private Boolean ExistsEmptyFields()
        {
            Boolean emptyFields = false;
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(lastName) || String.IsNullOrWhiteSpace(username)
               || String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(repeatPassword))
            {
                emptyFields = true;
                MessageBox.Show($"{Properties.Resources.SIGNIN_EMPTYFIELDS_MESSAGE}", $"{Properties.Resources.SIGNIN_EMPTYFIELDS_MESSAGEWINDOW}", MessageBoxButton.OK);
            }
            return emptyFields;
        }

        private Boolean ExistsExcessLength()
        {
            Boolean emptyFields = false;
            if (name.Length > 50 || lastName.Length > 75 || username.Length > 45 || email.Length > 100)
            {
                emptyFields = true;
                MessageBox.Show($"{Properties.Resources.SIGNIN_EXCESSLENGTH_MESSAGE}", $"{Properties.Resources.SIGNIN_EXCESSLENGTH_MESSAGEWINDOW}", MessageBoxButton.OK);
            }
            return emptyFields;
        }

        private Boolean ExistsInvalidStrings()
        {
            Boolean invalidStrings = false;
            if (ExistsInvalidCharacters(txtName.Text))
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_INVALIDSTRINGS_MESSAGE}", $"{Properties.Resources.SIGNIN_INVALIDSTRINGS_MESSAGEWINDOW}", MessageBoxButton.OK);
                invalidStrings = true;
            }

            if (ExistsInvalidCharacters(txtLastName.Text))
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_INVALIDSTRINGSFORLASTNAME_MESSAGE}", $"{Properties.Resources.SIGNIN_INVALIDSTRINGSFORLASTNAME_MESSAGEWINDOW}", MessageBoxButton.OK);
                invalidStrings = true;
            }
            if (ExistsInvalidCharactersForEmail(txtEmail.Text))
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_INVALIDSTRINGSFOREMAIL_MESSAGE}", $"{Properties.Resources.SIGNIN_INVALIDSTRINGSFOREMAIL_MESSAGEWINDOW}", MessageBoxButton.OK);
                invalidStrings = true;
            }
            return invalidStrings;
        }

        private Boolean ExistsInvalidPassword(String password)
        {
            Boolean invalidPassword = false;
            if (Regex.IsMatch(password, "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$") == false)
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_INVALIDPASSWORD_MESSAGE}", $"{Properties.Resources.SIGNIN_INVALIDPASSWORD_MESSAGEWINDOW}", MessageBoxButton.OK);
                invalidPassword = true;
            }
            return invalidPassword;
        }

        private Boolean ExistsInvalidCharactersForEmail(String textValid)
        {
            Boolean invalidCharacter = false;
            if (Regex.IsMatch(textValid, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") == false)
            {
                invalidCharacter = true;
            }
            return invalidCharacter;
        }

        private Boolean ExistsInvalidCharacters(String textValid)
        {
            Boolean invalidCharacter = false;
            if (Regex.IsMatch(textValid, "^[A-Za-zÁÉÍÓÚáéíóúñÑ\\s]+$") == false)
            {
                invalidCharacter = true;
            }
            return invalidCharacter;
        }

        private Boolean ExistIncorrectPassword()
        {
            Boolean invalidPassword;
            if (password == repeatPassword)
            {
                invalidPassword = false;
            }
            else
            {
                MessageBox.Show($"{Properties.Resources.SIGNIN_INCORRECTPASSWORD_MESSAGE}", $"{Properties.Resources.SIGNIN_INCORRECTPASSWORD_MESSAGEWINDOW}", MessageBoxButton.OK);
                invalidPassword = true;
            }
            return invalidPassword;

        }


        private void SignInClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //MenuPrincipal nameprofile = new MenuPrincipal();
                SignInAction();
            }
            catch (Exception exception)
            {
                //TODO
                Console.WriteLine(exception.Message);
            }
        }

    }
}
