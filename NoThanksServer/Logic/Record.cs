using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Record
    {
        public List<String> PlayersList { get; set; }
        public List<int?> ScoresList { get; set; }
        public Record()
            {

            }

        public List<String> GetRecord()
        {
            using (var context = new NoThanksEntities())
            {
                var accounts = (from player in context.Players 
                                join history in context.MatchsHistories on player.idPlayer equals history.idPlayer
                                orderby history.point descending
                                select player.nickname);
                PlayersList = accounts.ToList();
            }
            return PlayersList;
        }

        public List<int?> GetScore()
        {
            using (var context = new NoThanksEntities())
            {
                var account = (from  history in context.MatchsHistories
                                orderby history.point descending
                                select history.point).ToList();
                ScoresList = account;
            }
            return ScoresList;
        }
    }
}
