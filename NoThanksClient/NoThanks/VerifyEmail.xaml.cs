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
            var code = txtNumber.Text;
            var codeCorrect = "HTY025RG#789/4DX";
            if (!String.IsNullOrWhiteSpace(code))
            {
                if (code.Equals(codeCorrect))
                {
                    MessageBox.Show($"{Properties.Resources.VERIFYEMAIL_CONFIRMATION_MESSAGE}", $"{Properties.Resources.VERIFYEMAIL_CONFIRMATION_MESSAGEWINDOW}", MessageBoxButton.OK);
                    result = true;
                    this.Close();
                    MainWindow main = new MainWindow();
                    main.Show();
                }
                else
                {
                    MessageBox.Show($"{Properties.Resources.VERIFYEMAIL_CONFIRMATIONERROR_MESSAGE}", $"{Properties.Resources.VERIFYEMAIL_CONFIRMATIONERROR_MESSAGEWINDOW}", MessageBoxButton.OK);
                }
            }
        }
    }
}
