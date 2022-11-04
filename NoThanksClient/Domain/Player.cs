using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        private int idPlayer;
        private string nickname;
        private string password;
        private string email;
        private Nullable<int> totalScore;
        private string name;
        private string lastName;
        private string photo;

        #region Singletone

        private static Player playerClient;

        public static Player PlayerClient { get { return playerClient; } set { playerClient = value; } }

        #endregion

        public int IdPlayer { get { return idPlayer; } set { idPlayer = value; } }
        public string Nickname { get { return nickname; } set { nickname = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Nullable<int> TotalScore { get { return totalScore; } set { totalScore = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Photo { get { return photo; } set { photo = value; } }


    }
}
