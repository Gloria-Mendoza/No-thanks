using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace NoThanks
{
    /// <summary>
    /// Lógica de interacción para RoomScores.xaml
    /// </summary>
    public partial class RoomScores : Window
    {
        private List<PlayerManager.Player> playersList = new List<PlayerManager.Player>();

        public RoomScores()
        {
            InitializeComponent();
            GenerateScores(playersList);
        }

        public void GenerateScores(List<PlayerManager.Player> players)
        {
            players.ForEach(p => CardsScore(p));
            lxtScores.ItemsSource = players;
        }

        public void CardsScore(PlayerManager.Player player)
        {
            var score = 0;
            for (int i = 0; i < playersList.Count; i++)
            {
                score += (int)player.Cards[i];
            }
            player.TotalScore = score;
            playersList.Add(player);
        }
    }
}
