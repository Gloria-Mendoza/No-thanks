using NoThanks.PlayerManager;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows;
using System.Windows.Input;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para Room.xaml
    /// </summary>
    public partial class Room : Window , IChatServiceCallback
    {
        private bool isConected = false;
        private ChatServiceClient chatServiceClient;
        private bool isNewRoom = false;
        private string idRoom = "";

        public bool IsNewRoom { get { return isNewRoom; } set { isNewRoom = value; } }

        public string IdRoom { get => idRoom; set => idRoom = value; }

        public Room()
        {
            InitializeComponent();
            txtCode.IsReadOnly = true;
            txtCode.Text = idRoom;
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
                            chatServiceClient.SendWhisper(Domain.Player.PlayerClient.Nickname, args[1], message, idRoom);
                        }
                    } 
                    else
                    {
                        chatServiceClient.SendMessage(txtMesageContainer.Text, Domain.Player.PlayerClient.Nickname,idRoom);
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
                    //TODO
                    if (isNewRoom)
                    {
                        idRoom = chatServiceClient.GenerateRoomCode();
                        chatServiceClient.CreateRoom(new PlayerManager.Room()
                        {
                            Id = idRoom,
                            Round = 0,
                            Scores = new List<int>().ToArray(),
                            Winner = "",
                            Players = new List<PlayerManager.Player>().ToArray(),
                        });
                    }
                    //ENDTODO
                    chatServiceClient.Connect(Domain.Player.PlayerClient.Nickname,idRoom);
                    //chatServiceClient.SendMessage($": {Domain.Player.PlayerClient.Nickname} se ha conectado!", null,idRoom);
                    isConected = true;
                }
                catch (EndpointNotFoundException)
                {
                    //TODO
                    MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
                }
                catch (CommunicationObjectFaultedException)
                {
                    MessageBox.Show("No se pudo conectar con el servidor", "Upss", MessageBoxButton.OK);
                }


            }
        }

        private void End()
        {
            if (isConected)
            {
                chatServiceClient.Disconnect(Domain.Player.PlayerClient.Nickname, idRoom);
                //TODO
                //chatServiceClient.SendMessage($": {Domain.Player.PlayerClient.Nickname} se ha desconectado!", null, idRoom);
                chatServiceClient = null;
                isConected = false;
            }
        }

    }
}
