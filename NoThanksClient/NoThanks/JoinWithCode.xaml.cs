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
            Room goRoom = new Room()
            {
                WindowState = this.WindowState,
                Left = this.Left,
                IsNewRoom = false,
                RoomId = txtCode.Text
            };
            if (goRoom.CheckQuota())
            {
                goRoom.CreateNewRoom(false);
                goRoom.Show();
                this.Close();
            }
            else
            {
                goRoom.Close();
                MessageBox.Show(Properties.Resources.JOINGAME_CANTJOIN_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                txtCode.Text = string.Empty;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            PlaySelection goPlaySelection = new PlaySelection()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goPlaySelection.Show();
            this.Close();
        }
        
    }
}
