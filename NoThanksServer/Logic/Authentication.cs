using Data;
using System;
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
                    player.Password = "";
                    player.ProfileImage = accounts.First().photo;
                }
            }
            return player;
        }

        public bool UpdatePlayerPassword(string password, string email)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                var playerToUpdate = context.Players.FirstOrDefault(e => e.email.Equals(email));
                if (playerToUpdate == null)
                {
                    return false;
                }
                playerToUpdate.password = password;
                status = context.SaveChanges() > 0;
            }
            return status;
        }
        public bool UpdatePlayerNickname(string nickname, string updatedNickname)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                var playerToUpdate = context.Players.FirstOrDefault(n => n.nickname.Equals(updatedNickname));
                if (playerToUpdate == null)
                {
                    return false;
                }
                playerToUpdate.nickname = nickname;
                status = context.SaveChanges() > 0;
            }
            return status;
        }

        public bool SaveImage(string imageManager, int idProfile)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                var playerToUpdate = context.Players.FirstOrDefault(c => c.idPlayer.Equals(idProfile));
                if (playerToUpdate == null)
                {
                    return false;
                }
                playerToUpdate.photo = imageManager;
                status = context.SaveChanges() > 0;
            }
            return status;
        }
    }
}
