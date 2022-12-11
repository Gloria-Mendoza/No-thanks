using Data;
using System.Linq;

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
            status = NewRecord(player);
            return status;
        }

        public bool NewRecord(Logic.Player player)
        {
            var status = false;
            using (var context = new NoThanksEntities())
            {
                Data.Player newPlayer = new Data.Player()
                {
                    name = player.Name,
                    lastName = player.LastName,
                    nickname = player.Nickname,
                    email = player.Email,
                    password = player.Password,
                    photo = player.ProfileImage,
                    totalScore = player.TotalScore,
                };

                context.Players.Add(newPlayer);
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
