using log4net;
using Logs;
using NoThanks.NoThanksService;
using System;
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
        private NoThanksService.Player[] playerList;
        private bool isNewRoom;
        private string idRoom;
        private bool isConected = false;
        private bool isHost = false;
        private int globaltokens = 0;
        private int currentRound = 0;

        private static readonly ILog Log = Logger.GetLogger();

        public bool IsNewRoom { get { return isNewRoom; } set { isNewRoom = value; } }
        public string IdRoom { get { return idRoom; } set { idRoom = value; } }
        #endregion

        public Room()
        {
            InitializeComponent();
            txtCode.IsReadOnly = true;
        }

        #region Public Functions
        public bool CreateNewRoom(bool isNewRoom)
        {
            var status = true;

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
            catch (EndpointNotFoundException ex)
            {
                status = false;
                Log.Error($"{ex.Message}");
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                status = false;
                Log.Error($"{ex.Message}");
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeoutException ex)
            {
                status = false;
                Log.Error($"{ex.Message}");
                MessageBox.Show(Properties.Resources.GENERAL_NOCONNECTION_MESSAGE, Properties.Resources.GENERAL_ERROR_TITLE, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return status;
        }

        public bool CheckQuota()
        {
            gameServiceClient = new GameServiceClient(new InstanceContext(this));
            var aviable = false;

            try
            {
                aviable = gameServiceClient.CheckQuota(IdRoom);
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
            finally
            {
                gameServiceClient.Abort();
            }

            return aviable;
        }
        #endregion

        #region Callbacks
        public void MessageCallBack(string message)
        {
            lxtChatBox.Items.Add(message);
            lxtChatBox.ScrollIntoView(lxtChatBox.Items[lxtChatBox.Items.Count - 1]);
        }

        public void WhisperCallBack(string message)
        {
            lxtChatBox.Items.Add(message);
            lxtChatBox.ScrollIntoView(lxtChatBox.Items[lxtChatBox.Items.Count - 1]);
        }

        public void StartGameRoom(RoomStatus roomStatus, NoThanksService.Player[] players)
        {
            if (roomStatus == RoomStatus.Started)
            {
                playerList = players;
                lxtPlayersBox.ItemsSource = playerList;
                gridLobby.Visibility = Visibility.Collapsed;
                if (Domain.Player.PlayerClient.Nickname.Equals(playerList.ElementAt(currentRound).Nickname))
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
                MainMenu go = new MainMenu()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                go.Show();
                this.Close();
                MessageBox.Show($"{nickname} \n{message}", Properties.Resources.GENERAL_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public void UpdateDeck(NoThanksService.CardType[] gameDeck, int roomTokens)
        {
            globaltokens = roomTokens;            
            if(gameDeck.Count() > 0)
            {
                int i = (int)gameDeck[0];
                TopCard.Source = new BitmapImage(new Uri($"/Images/{i}.png", UriKind.Relative));
            }
            
        }

        public void SkipPlayersTurnCallback(int round, int roomTokens)
        {
            globaltokens = roomTokens;
        }

        public void NextTurn(int round, NoThanksService.Player[] roomPlayers)
        {
            lbtokens.Content = $"Round: {round} \nTokens: {globaltokens}";
            playerList = roomPlayers;
            lxtPlayersBox.ItemsSource = playerList;
            currentRound = round;
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
                RoomScores goRoomScores = new RoomScores()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                goRoomScores.ChargeWindow(this.gameServiceClient, this.isHost, this.idRoom);
                goRoomScores.GenerateScores(playerList.ToList());
                goRoomScores.ShowDialog();

                MainMenu goMainMenu = new MainMenu()
                {
                    WindowState = this.WindowState,
                    Left = this.Left
                };
                goMainMenu.Show();
                this.Close();
            }
        }
        #endregion

        #region Listeners
        private void SendMessageKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Messages();
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
                txtMesageContainer.Text = string.Empty;
            }

        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                End();
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
            MainMenu goMainMenu = new MainMenu()
            {
                WindowState = this.WindowState,
                Left = this.Left
            };
            goMainMenu.Show();
            this.Close();
        }

        private void TakeClick(object sender, RoutedEventArgs e)
        {
            btnTake.IsEnabled = false;
            btnPass.IsEnabled = false;
            try
            {
                gameServiceClient.TakeCard(idRoom, Domain.Player.PlayerClient.Nickname);
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

        private void PassClick(object sender, RoutedEventArgs e)
        {
            btnTake.IsEnabled = false;
            btnPass.IsEnabled = false;
            try
            {
                gameServiceClient.SkipPlayersTurn(idRoom, Domain.Player.PlayerClient.Nickname);
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

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            string[] messages = new string[2];
            messages[0] = Properties.Resources.ROOM_STARTEDGAME_MESSAGE;
            messages[1] = Properties.Resources.ROOM_CANTSTART_MESSAGE;

            try
            {
                gameServiceClient.StartGame(IdRoom, messages);
                gameServiceClient.CreateDeck(IdRoom);
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

        private void ExpelClick(object sender, MouseButtonEventArgs e)
        {
            Image expelImage = (Image)sender;
            Grid parent = (Grid)expelImage.Parent;
            NoThanksService.Player player = (NoThanksService.Player)parent.DataContext;
            if (isHost)
            {
                ExpelPlayer goExpelPlayer = new ExpelPlayer();
                goExpelPlayer.SendPlayer(player, gameServiceClient, IdRoom);
                goExpelPlayer.ShowDialog();
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
                gameServiceClient.Abort();
                gameServiceClient = null;
                isConected = false;
            }
        }

        private void Messages()
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
                        gameServiceClient.SendWhisper(args[1], message, idRoom);
                    }
                }
                else
                {
                    gameServiceClient.SendMessage(txtMesageContainer.Text, Domain.Player.PlayerClient.Nickname, idRoom);
                }
            }
        }
        #endregion

    }
}
