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
    /// Lógica de interacción para Room.xaml
    /// </summary>
    public partial class Room : Window, IChatServiceCallback
    {
        private bool isConected = false;
        private ChatServiceClient chatServiceClient;
        private Player player;

        public Room()
        {
            InitializeComponent();
        }

        public void MessageCallBack(string message)
        {
            txtChatBox.Items.Add(message);
            txtChatBox.ScrollIntoView(txtChatBox.Items[txtChatBox.Items.Count - 1]);
        }

        public void SettingData(Player player)
        {
            this.player = player;
            Start();
        }

        private void Start()
        {
            if (!isConected)
            {
                chatServiceClient = new ChatServiceClient(new System.ServiceModel.InstanceContext(this));
                chatServiceClient.Connect(player.Nickname);
                isConected = true;

            }
        }

        private void End()
        {
            if(isConected)
            {
                chatServiceClient.Disconnect(player.Nickname);
                chatServiceClient = null;
            }
        }

        private void TxtMesageContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(chatServiceClient != null)
                {
                    chatServiceClient.SendMessage(txtMesageContainer.Text, player.Nickname);
                }
                txtMesageContainer.Text = string.Empty;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            End();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow go = new MainWindow();
            go.Show();
            this.Close();
        }
    }
}
