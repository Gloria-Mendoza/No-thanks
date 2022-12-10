using Domain;
using log4net;
using Logs;
using NoThanks.NoThanksService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
        private NoThanksService.Player player;
        private GameServiceClient gameServiceClient1;
        private string idRoom1;
        private static readonly ILog Log = Logger.GetLogger();

        public ExpelPlayer()
        {
            InitializeComponent();
        }

        #region Listeners
        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Expel();
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
        public void SendPlayer(NoThanksService.Player playerToExpel, NoThanksService.GameServiceClient gameServiceClient, string idRoom)
        {
            player = playerToExpel;
            gameServiceClient1 = gameServiceClient;
            idRoom1 = idRoom;
        }
        #endregion
    }
}
