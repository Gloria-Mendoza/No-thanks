using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]
    public class Room
    {
        private string id;
        private int round;
        private string winner;
        private List<int> scores;
        private List<Player> players;

        [DataMember]
        public string Id { get { return id; } set { id = value; } }
        [DataMember]
        public int Round { get { return round; } set { round = value; } }
        [DataMember]
        public string Winner { get { return winner; } set { winner = value; } }
        [DataMember]
        public List<int> Scores { get { return scores; } set { scores = value; } }
        [DataMember]
        public List<Player> Players { get => players; set => players = value; }
    }
}
