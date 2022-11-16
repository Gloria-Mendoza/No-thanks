using Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Logic
{
    public class Authentication
    {
        public List<Player> PlayersList { get; set; }
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

        public bool UpdatePlayerPassword(string password,string email)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                var playerToUpdate = context.Players.First(e => e.email.Equals(email));
                playerToUpdate.password = password;
                status = context.SaveChanges() > 0;
            }
            return status;
        }

        public string RecoverPlayerEmail(string username)
        {
            string email = "";
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                where players.nickname == username
                                select players);
                if (accounts.Any())
                {
                    email = accounts.First().email;
                }
            }
            return email;
        }
    }
}
