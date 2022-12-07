using NoThanks.PlayerManager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static NoThanks.PlayerManager.Player;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para RoomScores.xaml
    /// </summary>
    public partial class RoomScores : Window
    {
        private List<PlayerManager.Player> playersList = new List<PlayerManager.Player>();
        private bool isHost = false;
        private GameServiceClient gameServiceClient;
        private string idRoom;

        public RoomScores()
        {
            InitializeComponent();
        }
        
        public void ChargeWindow(GameServiceClient gameServiceClient, bool isHost, string idRoom)
        {
            this.gameServiceClient = gameServiceClient;
            this.isHost = isHost;
            this.idRoom = idRoom;
        }
        public void GenerateScores(List<PlayerManager.Player> players)
        {

            players.ForEach(p => {
                CardsScore(p);
            });

            playersList.Sort(( x, y) =>  x.TotalScore.Value.CompareTo(y.TotalScore));

            lxtScores.ItemsSource = playersList;

            lbWinner.Content = Properties.Resources.RESULT_WINNER_LABEL;

            if (isHost)
            {
                gameServiceClient.FinishGame(this.idRoom, playersList.ToArray());
            }
        }

        public void CardsScore(PlayerManager.Player player)
        {
            player = DiscardConsecutiveNumbers(player);

            var score = 0;
            for (int i = 0; i < player.Cards.Length; i++)
            {
                score += (int)player.Cards[i];
            }
            player.TotalScore = score - player.Tokens;
            playersList.Add(player);
        }

        public PlayerManager.Player DiscardConsecutiveNumbers(PlayerManager.Player player)
        {
            List<CardType> cardsFromPlayer = new List<CardType>();

            List<CardType> cardsToRemove = new List<CardType>();

            List<CardType> cardsToPreserve = new List<CardType>();

            CardType[] cardsOrdered = player.Cards;
            Array.Sort(cardsOrdered);

            try
            {
                for (int i = 0; i < cardsOrdered.Length + 1; i++)
                {
                    if ((player.Cards.ElementAt(i) - player.Cards.ElementAt(i + 1) == 1) ||
                        (player.Cards.ElementAt(i) - player.Cards.ElementAt(i + 1) == -1) ||
                        (player.Cards.ElementAt(i) - player.Cards.ElementAt(i - 1) == -1) ||
                        (player.Cards.ElementAt(i) - player.Cards.ElementAt(i - 1) == 1))
                    {
                        cardsFromPlayer.Add(player.Cards[i]);
                    }
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                _ = e.Message;
            }

            if (cardsFromPlayer.Count != 0)
            {
                cardsOrdered = cardsFromPlayer.ToArray();
                cardsToPreserve.Add(cardsOrdered.First());
                cardsToRemove.Add(cardsFromPlayer.Last());
            }
            else
            {
                cardsOrdered = player.Cards;
            }

            try
            {
                for (int i = 1; i < cardsOrdered.Length + 1; i++)
                {
                    if ((cardsFromPlayer.ElementAt(i) - cardsFromPlayer.ElementAt(i + 1) == 1) ||
                        (cardsFromPlayer.ElementAt(i) - cardsFromPlayer.ElementAt(i - 1) == -1) ||
                        (cardsFromPlayer.ElementAt(i) - cardsFromPlayer.ElementAt(i - 1) == 1))
                    {
                        cardsToRemove.Add(cardsFromPlayer.ElementAt(i));
                    }
                    else
                    {
                        cardsToPreserve.Add(cardsFromPlayer.ElementAt(i));
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                _ = e.Message;
            }

            List<CardType> cardsToPlayer = player.Cards.ToList();

            for (int i = 0; i < cardsToRemove.Count; i++)
            {
                cardsToPlayer.Remove(cardsToRemove[i]);
            }

            player.Cards = cardsToPlayer.ToArray();

            return player;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = true;
        }
    }
}
