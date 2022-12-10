using NoThanks.NoThanksService;
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
        private int validationCode;

        public int ValidationCode { get { return validationCode; } set { validationCode = value; } }

        public VerifyEmail()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SendCodeClick(object sender, RoutedEventArgs e)
        {
            var code = txtNumber.Text;
            if (!String.IsNullOrWhiteSpace(code))
            {
                if (code.Equals(validationCode))
                {
                    MessageBox.Show($"{Properties.Resources.VERIFYEMAIL_CONFIRMATION_MESSAGE}", $"{Properties.Resources.VERIFYEMAIL_CONFIRMATION_MESSAGEWINDOW}", MessageBoxButton.OK);
                    DialogResult = true;
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
                    MessageBox.Show($"{Properties.Resources.VERIFYEMAIL_CONFIRMATIONERROR_MESSAGE}", $"{Properties.Resources.VERIFYEMAIL_CONFIRMATIONERROR_MESSAGEWINDOW}", MessageBoxButton.OK);
                }
            }
        }
    }
}
