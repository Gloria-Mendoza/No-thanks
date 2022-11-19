using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [DataContract]
    public class Player
    {
        private int idPlayer;
        private string nickname;
        private string password;
        private string email;
        private List<string> cards;
        private Nullable<int> totalScore;
        private string name;
        private string lastName;
        private bool status;

        #region ChatCallbacks
        private OperationContext aOperationContext;

        public OperationContext AOperationContext { get { return aOperationContext; } set { aOperationContext = value; } }
        #endregion

        #region Properties
        [DataMember]
        public bool Status { get { return status; } set { status = value; } }
        [DataMember]
        public int IdPlayer { get { return idPlayer; } set { idPlayer = value; } }
        [DataMember]
        public string Nickname { get { return nickname; } set { nickname = value; } }
        [DataMember]
        public string Password { get { return password; } set { password = value; } }
        [DataMember]
        public string Email { get { return email; } set { email = value; } }
        [DataMember]
        public List<string> Cards { get { return cards; } set { cards = value; } }
        [DataMember]
        public Nullable<int> TotalScore { get { return totalScore; } set { totalScore = value; } }
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public string LastName { get { return lastName; } set { lastName = value; } }
        #endregion

    }
}
