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
        public bool AddFinishedGame(Logic.Room game)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                context.Games.Add(new Game()
                {
                    result = game.Scores.Max()
                });
                foreach (var player in game.Players)
                {
                    int idPlayer = player.IdPlayer;
                    context.MatchsHistories.Add(new MatchsHistory()
                    {
                        idGame = context.Games.Max(g => g.idGame),
                        idPlayer = idPlayer,
                        Game = context.Games.Last(),
                        Player = new Data.Player()
                        {
                            idPlayer = idPlayer,
                            totalScore = player.TotalScore
                        },
                        point = player.TotalScore,
                        result = player.TotalScore == game.Scores.Max() ? "Victory" : "Defeat"
                    });
                    status = context.SaveChanges() > 0;
                }
            }
            return status;
        }

        

        /*public void AddCurrentGame(Logic.Room room)
        {
            if (room != null)
            {
                Logic.Room game = new Logic.Room()
                {
                    Id = room.Id,
                    Players = room.Players,
                    Scores = room.Scores,
                    Winner = room.Winner,
                    Round = room.Round
                };
                Logic.Room.Rooms.Add(game);
            }
        }

        public void JoinGame(int idRoom, Logic.Player player)
        {
            Logic.Room.Rooms.Find(r => r.Id == idRoom).Players.Add(player);
        }*/
        
    }
}
