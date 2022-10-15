using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IPlayerManager
    {
        [OperationContract]
        bool Login(String nickname, String password);
        [OperationContract]
        bool Register(Player player);
    }

    public partial class Player
    {
        private int idPlayer;
        private string nickname;
        private string password;
        private string email;
        private Nullable<int> totalScore;
        private string name;
        private string lastName;

        public Player()
        {
            
        }

        public int IdPlayer { get { return idPlayer; } set { idPlayer = value; } }
        public string Nickname { get { return nickname; } set { nickname = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Nullable<int> TotalScore { get { return totalScore; } set { totalScore = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }

    }
}
