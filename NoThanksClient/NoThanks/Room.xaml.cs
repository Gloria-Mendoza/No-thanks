using NoThanks.PlayerManager;
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
    /// Lógica de interacción para Room.xaml
    /// </summary>
    public partial class Room : Window, IChatServiceCallback
    {
        private bool isConected = false;
        private ChatServiceClient chatServiceClient;

        public Room()
        {
            InitializeComponent();
            Start();
        }

        public void MessageCallBack(string message)
        {
            txtChatBox.Items.Add(message);
            txtChatBox.ScrollIntoView(txtChatBox.Items[txtChatBox.Items.Count - 1]);
        }

        public void WhisperCallBack(string sender, string message)
        {
            txtChatBox.Items.Add(message);
            txtChatBox.ScrollIntoView(txtChatBox.Items[txtChatBox.Items.Count - 1]);
        }

        private void TxtMesageContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if(chatServiceClient != null)
                {
                    if (txtMesageContainer.Text.StartsWith("/whisper"))
                    {
                        string[] args = txtMesageContainer.Text.Split(' ');
                        if (args.Length > 2)
                        {
                            string message = "";
                            for (int i = 2; i < args.Length; i++)
                            {
                                message += args[i] + " ";
                            }
                            chatServiceClient.SendWhisper(Domain.Player.PlayerClient.Nickname, args[1], message);
                        }
                    } 
                    else
                    {
                        chatServiceClient.SendMessage(txtMesageContainer.Text, Domain.Player.PlayerClient.Nickname);
                    }
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
            MenuPrincipal go = new MenuPrincipal()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            go.Show();
            this.Close();
        }

        private void Start()
        {
            if (!isConected)
            {
                chatServiceClient = new ChatServiceClient(new System.ServiceModel.InstanceContext(this));
                try
                {
                    chatServiceClient.Connect(Domain.Player.PlayerClient.Nickname);
                    isConected = true;
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
                }


            }
        }

        private void End()
        {
            if (isConected)
            {
                chatServiceClient.Disconnect(Domain.Player.PlayerClient.Nickname);
                chatServiceClient = null;
                isConected = false;
            }
        }

    }
}
