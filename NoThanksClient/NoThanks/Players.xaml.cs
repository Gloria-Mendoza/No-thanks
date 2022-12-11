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
    public partial class Players : Window
    {
        NoThanksService.UpdateProfileClient updateProfileClient = new NoThanksService.UpdateProfileClient();
        private static readonly ILog Log = Logger.GetLogger();
        private List<String> strings = new List<String>();

        public Players()
        {
            InitializeComponent();
            CargeAllUsers();
        }

        public void CargeAllUsers()
        {
            try
            {
                strings = updateProfileClient.GetGlobalPlayers().ToList();
                lxtAllUsers.ItemsSource = strings;
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
            MainMenu mainMenu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            mainMenu.Show();
            this.Close();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtConsult.Text))
            {
                lxtAllUsers.ItemsSource = strings;
            }
            else
            {
                List<String> resultSearch = new List<string>();

                string nickFriend = txtConsult.Text;
                resultSearch.Add(strings.Find(i => i.Contains(nickFriend)));
                lxtAllUsers.ItemsSource = resultSearch;
            }
        }
    }
}
