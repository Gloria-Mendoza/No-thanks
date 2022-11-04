using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Lógica de interacción para VerifyEmail.xaml
    /// </summary>
    public partial class VerifyEmail : Window
    {
        bool result = false;
        public VerifyEmail()
        {
            InitializeComponent();
        }

        public Boolean GetVerifyEmail()
        {
            return result;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SendCodeClick(object sender, RoutedEventArgs e)
        {
            PlayerManager.PlayerManagerClient client = new PlayerManager.PlayerManagerClient();
            var number = txtNumber.Text;
            var numberCode = client.GetGenerateCode();
            if (!String.IsNullOrWhiteSpace(number) && existsInvalidField(number))
            {
                if (number.Equals(numberCode))
                {
                    MessageBox.Show("El correo electróncio se ha verificado correctamente", "Confirmación de correo", MessageBoxButton.OK);
                    result = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El código ingresado es incorrecto. Verifique la información", "Error de corfirmación de correo", MessageBoxButton.OK);
                }
            }
        }

        private Boolean existsInvalidField(String textValid)
        {
            Boolean invalidNumber = false;
            if (Regex.IsMatch(textValid, "^\\d+$") == false)
            {
                MessageBox.Show("El código ingresado es inválido. Verifique la información", "Campo inválido", MessageBoxButton.OK);
                invalidNumber = true;
            }
            return invalidNumber;
        }
    }
}
