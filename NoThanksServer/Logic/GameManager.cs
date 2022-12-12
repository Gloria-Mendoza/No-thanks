using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Security.Cryptography;
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

                var idGame = context.Games.Max(g => g.idGame);

                foreach (var logicPlayer in logicRoom.Players)
                {
                    var dataPlayer = context.Players.FirstOrDefault(p => p.nickname.Equals(logicPlayer.Nickname));
                    var idPlayer = 0;

                    if (dataPlayer != null)
                    {
                        idPlayer = dataPlayer.idPlayer;

                        context.MatchsHistories.Add(new MatchsHistory()
                        {
                            idGame = idGame,
                            idPlayer = idPlayer,
                            point = logicPlayer.TotalScore,
                            result = (logicPlayer.TotalScore == logicRoom.Scores.Min()) ? "Victory" : "Defeat"
                        });
                    }
                }
                status = context.SaveChanges() > 0;
            }
            return status;
        }

    }
}
