using log4net;
using Logs;
using NoThanks.NoThanksService;
using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;

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
        private static readonly ILog Log = Logger.GetLogger();

        public SignIn()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
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
            NoThanksService.PlayerManagerClient client = new NoThanksService.PlayerManagerClient();

            if (!ExistsInvalidFields())
            {
                string passwordHashed = Security.PasswordEncryptor.ComputeSHA512Hash(password);
                Player player = new Player()
                {
                    Name = name,
                    LastName = lastName,
                    Nickname = username,
                    Email = email,
                    Password = passwordHashed,
                    ProfileImage = "",
                    TotalScore = 0,
                };

                Random randomNumber = new Random();
                var validationCode = randomNumber.Next(100000, 1000000);
                
                var result = false;

                if (!client.ExistsEmailOrNickname(username, email))
                {
                    result = client.SendValidationEmail(email, "Validation Code", validationCode);
                }
                
                if (result)
                {
                    VerifyEmail verifyEmail = new VerifyEmail()
                    {
                        WindowState = this.WindowState,
                        Left = this.Left
                    };
                    verifyEmail.ValidationCode = validationCode;
                    var resultCode = (bool)verifyEmail.ShowDialog();
                    var aux = client.Register(player);
                    if (aux && resultCode)
                    {
                        MessageBox.Show($"{Properties.Resources.SIGNIN_CONFIRMATION_MESSAGE}", $"{Properties.Resources.SIGNIN_CONFIRMATION_MESSAGEWINDOW}", MessageBoxButton.OK);
                        client.Abort();
                        MainWindow main = new MainWindow()
                        {
                            WindowState = this.WindowState,
                            Left = this.Left
                        };
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGE}", $"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGEWINDOW}", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show($"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGE}", $"{Properties.Resources.SIGNIN_SAVEERROR_MESSAGEWINDOW}", MessageBoxButton.OK);
                }
            }
        }

        #region Validations
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
        #endregion

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SignInAction();
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

    }
}
