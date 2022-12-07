using Domain;
using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace NoThanks
{

    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class Room : Window, IGameServiceCallback
    {
        #region Atributtes & Properties
        private GameServiceClient gameServiceClient;
        private PlayerManager.Player[] playerList;
        private PlayerManager.CardType[] gameDeck;
        private bool isNewRoom;
        private string idRoom;
        private bool isConected = false;
        private bool isHost = false;
        private int globaltokens = 0;
        private int actualRound = 0;
        
        public bool IsNewRoom { get { return isNewRoom; } set { isNewRoom = value; } }
        public string IdRoom { get { return idRoom; } set { idRoom = value; } }
        #endregion

        public Room()
        {
            InitializeComponent();
            txtCode.IsReadOnly = true;
        }

        #region Public Functions
        public void CreateNewRoom(bool isNewRoom)
        {
            this.isNewRoom = isNewRoom;
            if (isNewRoom)
            {
                btnStartGame.Visibility = Visibility.Visible;
                gridLobby.Visibility = Visibility.Visible;
            }
            else
            {
                btnStartGame.Visibility = Visibility.Collapsed;
            }

            try
            {
                Start();

            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FaultException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool CheckQuota()
        {
            gameServiceClient = new GameServiceClient(new InstanceContext(this));
            var aviable = gameServiceClient.CheckQuota(IdRoom);
            gameServiceClient.Close();
            return aviable;
        }
        #endregion

        #region Callbacks
        public void MessageCallBack(string message)
        {
            lxtChatBox.Items.Add(message);
            lxtChatBox.ScrollIntoView(lxtChatBox.Items[lxtChatBox.Items.Count - 1]);
        }

        public void WhisperCallBack(string sender, string message)
        {
            lxtChatBox.Items.Add(message);
            lxtChatBox.ScrollIntoView(lxtChatBox.Items[lxtChatBox.Items.Count - 1]);
        }

        public void StartGameRoom(RoomStatus roomStatus, PlayerManager.Player[] players)
        {
            if (roomStatus == RoomStatus.Started)
            {
                playerList = players;
                lxtPlayersBox.ItemsSource = playerList;
                gridLobby.Visibility = Visibility.Collapsed;
                if (Domain.Player.PlayerClient.Nickname.Equals(playerList.ElementAt(actualRound).Nickname))
                {
                    btnTake.IsEnabled = true;
                    btnPass.IsEnabled = true;
                }
                else
                {
                    btnTake.IsEnabled = false;
                    btnPass.IsEnabled = false;
                }
            }
        }

        public void PlayerExpeled(string nickname, string message)
        {
            
            if (Domain.Player.PlayerClient.Nickname.Equals(nickname))
            {
                MenuPrincipal go = new MenuPrincipal()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                go.Show();
                this.Close();
                MessageBox.Show($"{nickname} \n{message}", Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public void UpdateDeck(PlayerManager.CardType[] gameDeck, int roomTokens)
        {
            globaltokens = roomTokens;            
            if(gameDeck.Count() > 0)
            {
                int i = (int)gameDeck[0];
                this.gameDeck = gameDeck;
                TopCard.Source = new BitmapImage(new Uri($"/Images/{i}.png", UriKind.Relative));
            }
            
        }

        public void SkipPlayersTurnCallback(int round, int roomTokens)
        {
            globaltokens = roomTokens;
        }

        public void NextTurn(int round, PlayerManager.Player[] roomPlayers)
        {
            lbtokens.Content = $"Round: {round} \nTokens: {globaltokens}";
            playerList = roomPlayers;
            lxtPlayersBox.ItemsSource = playerList;
            actualRound = round;
            if (round < playerList.Count())
            {
                if (Domain.Player.PlayerClient.Nickname.Equals(playerList.ElementAt(round).Nickname))
                {
                    btnTake.IsEnabled = true;
                    btnPass.IsEnabled = true;
                }
            }
        }

        public void EndGame(RoomStatus roomStatus)
        {
            if(roomStatus == RoomStatus.Finished)
            {
                RoomScores go = new RoomScores()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                go.ChargeWindow(this.gameServiceClient, this.isHost, this.idRoom);
                go.GenerateScores(playerList.ToList());
                go.ShowDialog();

                MenuPrincipal goBack = new MenuPrincipal()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                goBack.Show();
                this.Close();
            }
        }
        #endregion

        #region Listeners
        private void TxtMesageContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (gameServiceClient != null)
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
                            gameServiceClient.SendWhisper(Domain.Player.PlayerClient.Nickname, args[1], message, idRoom);
                        }
                    }
                    else
                    {
                        gameServiceClient.SendMessage(txtMesageContainer.Text, Domain.Player.PlayerClient.Nickname, idRoom);
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
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
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
            btnTake.IsEnabled = false;
            btnPass.IsEnabled = false;
            gameServiceClient.TakeCard(idRoom,Domain.Player.PlayerClient.Nickname);
        }

        private void PassClick(object sender, RoutedEventArgs e)
        {
            btnTake.IsEnabled = false;
            btnPass.IsEnabled = false;
            gameServiceClient.SkipPlayersTurn(idRoom, Domain.Player.PlayerClient.Nickname);
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] messages = new string[2];
                messages[0] = Properties.Resources.ROOM_STARTEDGAME_MESSAGE;
                messages[1] = Properties.Resources.ROOM_CANTSTART_MESSAGE;

                gameServiceClient.StartGame(IdRoom, messages);
                gameServiceClient.CreateDeck(IdRoom);

            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationObjectFaultedException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExpelClick(object sender, MouseButtonEventArgs e)
        {
            Image expelImage = (Image)sender;
            Grid parent = (Grid)expelImage.Parent;
            PlayerManager.Player player = (PlayerManager.Player)parent.DataContext;
            if (isHost)
            {
                ExpelPlayer go = new ExpelPlayer();
                go.SendPlayer(player, gameServiceClient, IdRoom);
                go.ShowDialog();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ROOM_CANTEXPEL_MESSAGE, Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region Private Functions
        private void Start()
        {
            if (!isConected)
            {
                gameServiceClient = new GameServiceClient(new InstanceContext(this));
                if (isNewRoom)
                {
                    idRoom = gameServiceClient.GenerateRoomCode();
                    txtCode.Text = idRoom;
                    gameServiceClient.NewRoom(Domain.Player.PlayerClient.Nickname, idRoom);
                    isHost = true;
                }
                txtCode.Text = idRoom;
                gameServiceClient.Connect(Domain.Player.PlayerClient.Nickname, idRoom, Properties.Resources.CHAT_JOINMESSAGE_MESSAGE);
                isConected = true;
            }
        }

        private void End()
        {
            if (isConected)
            {
                gameServiceClient.Disconnect(Domain.Player.PlayerClient.Nickname, idRoom, Properties.Resources.CHAT_LEAVEMESSAGE_MESSAGE);
                gameServiceClient.Close();
                gameServiceClient = null;
                isConected = false;
            }
        }
        #endregion

    }
}
