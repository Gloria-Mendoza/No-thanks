using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GameManager
    {
        public bool AddFinishedGame(Logic.Room logicRoom)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                context.Games.Add(new Game()
                {
                    result = logicRoom.Scores.Min()
                });
                context.SaveChanges();
                foreach (var logicPlayer in logicRoom.Players)
                {
                    context.MatchsHistories.Add(new MatchsHistory()
                    {
                        idGame = context.Games.Max(g => g.idGame),
                        idPlayer = logicPlayer.IdPlayer,
                        point = logicPlayer.TotalScore,
                        result = (logicPlayer.TotalScore == logicRoom.Scores.Min()) ? "Victory" : "Defeat"
                    });
                    status = context.SaveChanges() > 0;
                }
            }
            return status;
        }
        
    }
}
