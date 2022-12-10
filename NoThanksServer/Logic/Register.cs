using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Register
    {
        public Register()
        {

        }

        public bool RegisterUser(Logic.Player player)
        {
            var status = false;
            if (!ExistsEmailOrNickname(player.Nickname, player.Email))
            {
                status = NewRecord(player);
            }
            return status;
        }

        public bool NewRecord(Logic.Player player)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                Data.Player player1 = new Data.Player()
                {
                    name = player.Name,
                    lastName = player.LastName,
                    nickname = player.Nickname,
                    email = player.Email,
                    password = player.Password
                };

                context.Players.Add(player1);
                status = context.SaveChanges() > 0;
            }
            return status;
        }

        public bool ExistsEmailOrNickname(string nickname, string email)
        {
            bool result = false;
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                where players.email == nickname || players.email == email
                                select players).Count();
                if (accounts > 0)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
