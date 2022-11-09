using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para JoinWithCode.xaml
    /// </summary>
    public partial class JoinWithCode : Window
    {
        public JoinWithCode()
        {
            InitializeComponent();
        }

        private void JoinClick(object sender, RoutedEventArgs e)
        {
            Room go = new Room()
            {
                WindowState = this.WindowState,
                Left = this.Left,
                IsNewRoom = false,
                IdRoom = txtCode.Text
            };
            if (go.CheckQuota())
            {
                go.CreateNewRoom(false);
                go.Show();
                this.Close();
            }
            else
            {
                go.Close();
                MessageBox.Show("No se puede unir a la sala, está llena", "Upss", MessageBoxButton.OK);
                txtCode.Text = string.Empty;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            PlaySelection go = new PlaySelection()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }
        
    }
}
