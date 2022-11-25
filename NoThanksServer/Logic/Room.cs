using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        private string hostUsername;
        private RoomStatus matchStatus;
        private string winner;
        private const int MAX_PLAYERS = 7;
        private const int MIN_PLAYERS = 3;
        private int actualPlayersCount = 0;
        private List<int> scores;
        private List<Player> players;

        #region Properties
        [DataMember]
        public string Id { get { return id; } set { id = value; } }
        [DataMember]
        public int Round { get { return round; } set { round = value; } }
        [DataMember]
        public string HostUsername { get { return hostUsername; } set { hostUsername = value; } }
        [DataMember]
        public RoomStatus MatchStatus { get { return matchStatus; } set { matchStatus = value; } }
        [DataMember]
        public string Winner { get { return winner; } set { winner = value; } }
        [DataMember]
        public int MAX_PLAYERS1 => MAX_PLAYERS;
        [DataMember]
        public int MIN_PLAYERS1 => MIN_PLAYERS;
        [DataMember]
        public int ActualPlayersCount { get { return actualPlayersCount; } set { actualPlayersCount = value; } }
        [DataMember]
        public List<int> Scores { get { return scores; } set { scores = value; } }
        [DataMember]
        public List<Player> Players { get { return players; } set { players = value; } }
        #endregion

        public bool HasSpace()
        {
            return actualPlayersCount < MAX_PLAYERS;
        }

        public void NextRound()
        {
            if(Round <= actualPlayersCount)
            {
                Round += 1;
            }
            else
            {
                Round = 0;
            }
        }
    }
}
