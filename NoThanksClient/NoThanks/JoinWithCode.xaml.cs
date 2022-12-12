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
            if (!String.IsNullOrWhiteSpace(txtCode.Text))
            {
                Room room = new Room()
                {
                    WindowState = this.WindowState,
                    Left = this.Left,
                    IsNewRoom = false,
                    RoomId = txtCode.Text
                };
                if (room.CheckQuota())
                {
                    if (room.CreateNewRoom(false))
                    {
                        room.Show();
                        this.Close();
                    }
                    else
                    {
                        room.Close();
                    }
                }
                else
                {
                    room.Close();
                    MessageBox.Show(Properties.Resources.JOINGAME_CANTJOIN_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCode.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.JOINGAME_NOCODE_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            PlaySelection playSelection = new PlaySelection()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            playSelection.Show();
            this.Close();
        }
        
    }
}
