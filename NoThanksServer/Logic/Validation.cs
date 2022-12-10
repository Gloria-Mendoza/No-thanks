using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Validation
    {
        public bool ExistEmail(string text)
        {
            bool result = false;
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                where players.email == text
                                select players).Count();
                if (accounts > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool ExistNickname(string text)
        {
            bool result = false;
            using (var context = new NoThanksEntities())
            {
                var accounts = (from players in context.Players
                                where players.nickname == text
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
