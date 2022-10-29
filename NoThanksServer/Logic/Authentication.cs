using Data;
using System.Linq;

namespace Logic
{
    public class Authentication
    {
        public Authentication()
        {
        }

        public Logic.Player Login(string nickname, string password)
        {
            Logic.Player player = new Logic.Player();
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                where players.nickname == nickname && players.password == password
                                select players);
                if (accounts.Any())
                {
                    player.IdPlayer = accounts.First().idPlayer;
                    player.Nickname = accounts.First().nickname;
                    player.Email = accounts.First().email;
                    player.Name = accounts.First().name;
                    player.LastName = accounts.First().lastName;
                    player.TotalScore = accounts.First().totalScore;
                    player.Status = true;
                }
            }
            return player;
        }
    }
}
