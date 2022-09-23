using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Authentication
    {
        public Authentication()
        {
        }

        public Boolean Login(string nickname, string password)
        {
            var status = false;
            string passwordHashed = ComputeSHA256Hash(password);
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                               where players.nickname == nickname && players.password == passwordHashed
                               select players).Count();
                if(accounts > 0)
                {
                    status = true;
                }
            }
                return status;
        }

        private string ComputeSHA256Hash(string input)
        {
            // using (ComputeSHA256Hash sHA256Hash = sHA256Hash.Create())
            throw new NotSupportedException();
        }
    }
}
