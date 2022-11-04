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
            var exitsEmail = client.ExitsEmail(email);
            var exitsNickname = client.ExitsNickname(username);
            if (exitsEmail == true)
            {
                MessageBox.Show("El correo ingresado ya se encuentra registrado. \n" +
                                "Por favor ingrese uno nuevo", "Correo registrado", MessageBoxButton.OK);
            }
            if (exitsNickname == true)
            {
                MessageBox.Show("El nombre de usuario ingresado ya se encuentra registrado. \n" +
                                "Por favor ingrese uno nuevo", "Nombre de usuario registrado", MessageBoxButton.OK);
            }

            if (!existsInvalidFields() && !exitsEmail && !exitsNickname)
            {
                string passwordHashed = ComputeSHA512Hash(password);
                Player player = new Player()
                {
                    Name = name,
                    LastName = lastName,
                    Nickname = username,
                    Email = email,
                    Password = passwordHashed
                };
                //client.SendCode(email, client.GenerateCode());
                //VerifyEmail verifyEmail = new VerifyEmail();
               // verifyEmail.ShowDialog();
               // var result = verifyEmail.GetVerifyEmail();
                var aux = client.Register(player);

                if (aux) // && result)
                {

                    //TODO
                    MessageBox.Show("Registro exitoso", "Confirmación de registro", MessageBoxButton.OK);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
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
            }
        }

        private Boolean existsInvalidFields()
        {
            Boolean invalidFields = false;
            if (existsEmptyFields() || existsInvalidStrings() || existsExcessLength() || existIncorrectPassword()
                || existsInvalidPassword(password))
            {
                invalidFields = true;
            }
            return invalidFields;
        }

        private Boolean existsEmptyFields()
        {
            Boolean emptyFields = false;
            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(lastName) || String.IsNullOrWhiteSpace(username)
               || String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(repeatPassword))
            {
                emptyFields = true;
                MessageBox.Show("Existen campos vacíos. Verifica los datos", "Campos vacíos", MessageBoxButton.OK);
            }
            return emptyFields;
        }

        private Boolean existsExcessLength()
        {
            Boolean emptyFields = false;
            if (name.Length > 50 || lastName.Length > 75 || username.Length > 45 || email.Length > 100)
            {
                emptyFields = true;
                MessageBox.Show("Existen campos que exceden la longitud permitida. Verifica los datos", "Longitud excedida", MessageBoxButton.OK);
            }
            return emptyFields;
        }

        private Boolean existsInvalidStrings()
        {
            Boolean invalidStrings = false;
            if (existsInvalidCharactersForName(txtName.Text))
            {
                MessageBox.Show("Existen caracteres invalidos. Verifica los datos de nombre", "Campos inválidos", MessageBoxButton.OK);
                invalidStrings = true;
            }

            if (existsInvalidCharactersForLastName(txtLastName.Text))
            {
                MessageBox.Show("Existen caracteres invalidos. Verifica los datos de apellidos", "Campos inválidos", MessageBoxButton.OK);
                invalidStrings = true;
            }
            if (existsInvalidCharactersForEmail(txtEmail.Text))
            {
                MessageBox.Show("Existen caracteres invalidos. Verifica los datos del correo electrónico", "Campos inválidos", MessageBoxButton.OK);
                invalidStrings = true;
            }
            return invalidStrings;
        }

        private Boolean existsInvalidPassword(String password)
        {
            Boolean invalidPassword = false;
            if (Regex.IsMatch(password, "^(?=\\w*\\d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$") == false)
            {
                MessageBox.Show("La contraseña debe tener entre 8 y 16 caracteres \n"
                                 + "La contraseña debe tener por lo menos un número \n"
                                 + "La contraseña debe tener por lo menos una letra mayúscula \n"
                                 + "La contraseña debe tener por lo menos una letra minúscula", "Contraseña inválida", MessageBoxButton.OK);
                invalidPassword = true;
            }
            return invalidPassword;
        }

        private Boolean existsInvalidCharactersForEmail(String textValid)
        {
            Boolean invalidCharacter = false;
            if (Regex.IsMatch(textValid, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") == false)
            {
                invalidCharacter = true;
            }
            return invalidCharacter;
        }

        private Boolean existsInvalidCharactersForName(String textValid)
        {
            Boolean invalidCharacter = false;
            if (Regex.IsMatch(textValid, "^[A-Za-zÁÉÍÓÚáéíóúñÑ\\s]+$") == false)
            {
                invalidCharacter = true;
            }
            return invalidCharacter;
        }

        private Boolean existsInvalidCharactersForLastName(String textValid)
        {
            Boolean invalidCharacter = false;
            if (Regex.IsMatch(textValid, "^[A-Za-zÁÉÍÓÚáéíóúñÑ\\s]+$") == false)
            {
                invalidCharacter = true;
            }
            return invalidCharacter;
        }

        private Boolean existIncorrectPassword()
        {
            Boolean invalidPassword;
            if (password == repeatPassword)
            {
                invalidPassword = false;
            }
            else
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden. Verifica los datos", "Campos inválidos", MessageBoxButton.OK);
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

        private string ComputeSHA512Hash(string input)
        {
            var encryptedPassword = "";
            using (SHA512 sHA512Hash = SHA512.Create())
            {
                byte[] hash = sHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                encryptedPassword = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
            return encryptedPassword;
        }

    }
}
