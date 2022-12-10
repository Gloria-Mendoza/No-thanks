using log4net;
using Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Friends.xaml
    /// </summary>
    public partial class Friends : Window
    {
        NoThanksService.UpdateProfileClient updateProfileClient = new NoThanksService.UpdateProfileClient();
        private static readonly ILog Log = Logger.GetLogger();

        public Friends()
        {
            InitializeComponent();
            CargeAllUsers();
        }

        public void CargeAllUsers()
        {
            try
            {
                ltbAllFriends.ItemsSource = updateProfileClient.GetGlobalPlayers().ToList();
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

        public void CargeAllFriends()
        {
            try
            {
                ltbAllFriends.ItemsSource = updateProfileClient.GetGlobalFriends(Domain.Player.PlayerClient.IdPlayer).ToList();
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

        private void BackClick(object sender, RoutedEventArgs e)
        {
            MenuPrincipal go = new MenuPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }
    }
}
