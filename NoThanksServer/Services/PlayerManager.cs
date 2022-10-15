using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace Services
{
    public class PlayerManager : IPlayerManager
    {
        public bool Login(String nickname, String password)
        {
            var status = false;
            string passwordHashed = ComputeSHA512Hash(password);
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                where players.nickname == nickname && players.password == passwordHashed
                                select players).Count();
                if (accounts > 0)
                {
                    status = true;
                }
            }
            return status;
        }

        public bool Register(Player player)
        {
            return false;
        }

        private string ComputeSHA512Hash(string input)
        {
            var encryptedPassword = "";
            using (SHA512 sHA512Hash = SHA512.Create())
            {
                byte[] hash = sHA512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                encryptedPassword = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
            return encryptedPassword;
        }
    }
}
