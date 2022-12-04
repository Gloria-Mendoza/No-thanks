using Domain;
using NoThanks.PlayerManager;
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
using System.Windows.Shapes;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para ExpelPlayer.xaml
    /// </summary>
    public partial class ExpelPlayer : Window
    {
        private PlayerManager.Player player;
        private GameServiceClient gameServiceClient1;
        private string idRoom1;

        public ExpelPlayer()
        {
            InitializeComponent();
        }

        #region Listeners
        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            Expel();
            DialogResult = true;
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        #endregion

        #region Private Funcitons
        private void Expel()
        {
            string expelReason = $"{DateTime.Now} \n{txtReason.Content}: ";

            if (chAfk.IsChecked == true)
            {
                expelReason += $"\n{chAfk.Content} ";
            }

            if (chCheats.IsChecked == true)
            {
                expelReason += $"\n{chCheats.Content} ";
            }

            if (chToxic.IsChecked == true)
            {
                expelReason += $"\n{chToxic.Content} ";
            }
            expelReason += $"\n{txtMessage.Text} ";

            gameServiceClient1.ExpelPlayer(player.Nickname, idRoom1, expelReason);
        }
        #endregion

        #region Public Functions
        public void SendPlayer(PlayerManager.Player playerToExpel, PlayerManager.GameServiceClient gameServiceClient, string idRoom)
        {
            player = playerToExpel;
            gameServiceClient1 = gameServiceClient;
            idRoom1 = idRoom;
        }
        #endregion
    }
}
