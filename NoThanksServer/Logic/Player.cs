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
        public enum CardType
        {
            Three = 3, Four, Five,
            Six, Seven, Eight,
            Nine, Ten, Eleven,
            Twelve, Thirteen, Fourteen,
            Fifteen, Sixteen, Seventeen,
            Eightteen, Nineteen, Twenty,
            TwentyOne, TwentyTwo, TwentyThree,
            TwentyFour, TwentyFive, TwentySix,
            TwentySeven, TwentyEight, TwentyNine,
            Thirty, ThirtyOne, ThirtyTwo,
            ThirtyThree, ThirtyFour, ThirtyFive
        }

        private int idPlayer;
        private string nickname;
        private string password;
        private string email;
        private List<CardType> cards;
        private int tokens;
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
        public List<CardType> Cards { get { return cards; } set { cards = value; } }
        [DataMember]
        public int Tokens { get { return tokens; } set { tokens = value; } }
        [DataMember]
        public Nullable<int> TotalScore { get { return totalScore; } set { totalScore = value; } }
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public string LastName { get { return lastName; } set { lastName = value; } }
        #endregion

        #region Methods
        /*public override bool Equals(object obj)
        {
            bool isEquals = false;
            if (obj == this)
            {
                isEquals = true;
            }
            if (obj != null && obj is Player)
            {
                Player other = (Player)obj;
                isEquals = this.IdPlayer == other.IdPlayer &&
                    this.Nickname.Equals(other.Nickname) &&
                    this.Password.Equals(other.Password) &&
                    this.Email.Equals(other.Email) &&
                    this.TotalScore.Equals(other.TotalScore) &&
                    this.Name.Equals(other.Name) &&
                    this.LastName.Equals(other.LastName) &&
                    this.Status.Equals(other.Status);
            }
            return isEquals;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }*/
        #endregion
    }
}
