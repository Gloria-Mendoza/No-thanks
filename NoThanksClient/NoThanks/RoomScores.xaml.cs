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

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para RoomScores.xaml
    /// </summary>
    public partial class RoomScores : Window
    {
        private List<PlayerManager.Player> playersList = new List<PlayerManager.Player>();
        //private List<PlayerManager.Player> listaDePrueba = new List<PlayerManager.Player>();

        public RoomScores()
        {
            InitializeComponent();
            //GenerateScores(listaDePrueba);
        }

        public void GenerateScores(List<PlayerManager.Player> players)
        {
            /* For Debug, delete later
            List<PlayerManager.CardType> test = new List<PlayerManager.CardType>
            {
                PlayerManager.CardType.Three,

                PlayerManager.CardType.Four,

                PlayerManager.CardType.Five,

                PlayerManager.CardType.Six,

                PlayerManager.CardType.Nine,

                PlayerManager.CardType.Sixteen,

                PlayerManager.CardType.Seventeen,

                PlayerManager.CardType.Eightteen,

                PlayerManager.CardType.TwentyOne,

                PlayerManager.CardType.TwentyTwo,

                PlayerManager.CardType.TwentyThree,

                PlayerManager.CardType.ThirtyFive,

                PlayerManager.CardType.TwentyFour,

                PlayerManager.CardType.Thirty,

                PlayerManager.CardType.TwentyFive
            };


            List<PlayerManager.CardType> test1 = new List<PlayerManager.CardType>
            {
                PlayerManager.CardType.Three,

                PlayerManager.CardType.Four,

                PlayerManager.CardType.Five,

                PlayerManager.CardType.Six,

                PlayerManager.CardType.Nine,

                PlayerManager.CardType.Sixteen,

                PlayerManager.CardType.Thirty,

                PlayerManager.CardType.TwentyFive
            };

            players.Add(new PlayerManager.Player
            {
                Nickname = "Panther"
            });
            players.First().Cards = test1.ToArray();
            
            players.Add(new PlayerManager.Player
            {
                Nickname = "Lucio"
            });
            players.First(p => p.Nickname.Equals("Lucio")).Cards = test.ToArray();*/
            
            players.ForEach(p => {
                CardsScore(p);
            });

            //MessageBox.Show($"{playersList.Min(p => p.TotalScore)}");

            playersList.Sort(( x, y) =>  x.TotalScore.Value.CompareTo(y.TotalScore));

            lxtScores.ItemsSource = playersList;

            lbWinner.Content = Properties.Resources.RESULT_WINNER_LABEL;

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
            List<PlayerManager.CardType> cards = new List<PlayerManager.CardType>();

            List<PlayerManager.CardType> cards1 = new List<PlayerManager.CardType>();

            List<PlayerManager.CardType> cards2 = new List<PlayerManager.CardType>();

            PlayerManager.CardType[] cardsArray = player.Cards;
            Array.Sort(cardsArray);

            try
            {
                for (int i = 0; i < cardsArray.Length + 1; i++)
                {
                    if ((player.Cards.ElementAt(i) - player.Cards.ElementAt(i + 1) == 1) ||
                        (player.Cards.ElementAt(i) - player.Cards.ElementAt(i + 1) == -1) ||
                        (player.Cards.ElementAt(i) - player.Cards.ElementAt(i - 1) == -1) ||
                        (player.Cards.ElementAt(i) - player.Cards.ElementAt(i - 1) == 1))
                    {
                        cards.Add(player.Cards[i]);
                    }
                }
            }
            catch
            {

            }
            cardsArray = cards.ToArray();

            cards2.Add(cardsArray.First());
            cards1.Add(cards.Last());

            try
            {
                for (int i = 1; i < cardsArray.Length + 1; i++)
                {
                    if ((cards.ElementAt(i) - cards.ElementAt(i + 1) == 1) ||
                        (cards.ElementAt(i) - cards.ElementAt(i - 1) == -1) ||
                        (cards.ElementAt(i) - cards.ElementAt(i - 1) == 1))
                    {
                        cards1.Add(cards.ElementAt(i));
                    }
                    else
                    {
                        cards2.Add(cards.ElementAt(i));
                    }
                }
            }
            catch
            {

            }

            List<PlayerManager.CardType> cardsAux = player.Cards.ToList();

            for (int i = 0; i < cards1.Count; i++)
            {
                cardsAux.Remove(cards1[i]);
            }

            player.Cards = cardsAux.ToArray();

            return player;
        }
    }
}
