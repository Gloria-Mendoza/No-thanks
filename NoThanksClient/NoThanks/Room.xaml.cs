using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Room.xaml
    /// </summary>
    public partial class Room : Window, IChatServiceCallback
    {
        private bool isConected = false;
        private ChatServiceClient chatServiceClient;
        private bool isNewRoom;
        private string idRoom;

        public bool IsNewRoom { get { return isNewRoom; } set { isNewRoom = value; } }

        public string IdRoom { get { return idRoom; } set { idRoom = value; } }

        public Room()
        {
            InitializeComponent();
            txtCode.IsReadOnly = true;
        }

        public void CreateNewRoom(bool isNewRoom)
        {
            this.isNewRoom = isNewRoom;
            try
            {
                Start();
            }
            catch (EndpointNotFoundException)
            {
                //TODO
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
            catch (CommunicationObjectFaultedException)
            {
                //TODO
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
            catch (NullReferenceException)
            {
                //TODO
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
            catch (FaultException<ServiceBehaviorAttribute> ex)
            {
                //TODO
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
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

        public bool CheckQuota()
        {
            chatServiceClient = new ChatServiceClient(new InstanceContext(this));
            var aviable = chatServiceClient.CheckQuota(IdRoom);
            chatServiceClient.Close();
            return aviable;
        }

        private void Start()
        {
            if (!isConected)
            {
                chatServiceClient = new ChatServiceClient(new InstanceContext(this));
                if (isNewRoom)
                {
                    idRoom = chatServiceClient.GenerateRoomCode();
                    txtCode.Text = idRoom;
                    chatServiceClient.NewRoom(idRoom);
                }
                txtCode.Text = idRoom;
                chatServiceClient.Connect(Domain.Player.PlayerClient.Nickname, idRoom);
                isConected = true;
            }
        }

        private void End()
        {
            if (isConected)
            {
                chatServiceClient.Disconnect(Domain.Player.PlayerClient.Nickname, idRoom);
                chatServiceClient.Close();
                chatServiceClient = null;
                isConected = false;
            }
        }

        private void TxtMesageContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (chatServiceClient != null)
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
                            chatServiceClient.SendWhisper(Domain.Player.PlayerClient.Nickname, args[1], message, idRoom);
                        }
                    }
                    else
                    {
                        chatServiceClient.SendMessage(txtMesageContainer.Text, Domain.Player.PlayerClient.Nickname, idRoom);
                    }
                }
                txtMesageContainer.Text = string.Empty;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                End();
            }
            catch (EndpointNotFoundException)
            {
                //TODO
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
            catch (CommunicationObjectFaultedException)
            {
                //TODO
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
            catch (NullReferenceException)
            {
                //TODO
                MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
            }
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

        private void TakeClick(object sender, RoutedEventArgs e)
        {

        }

        private void PassClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
