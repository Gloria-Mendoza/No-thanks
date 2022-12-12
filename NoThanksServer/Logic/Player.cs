using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    //El OperationContext que se encuentra en esta clase cumple la función de devolver un objeto Player completo
    //Utilizamos el OperationContext sin serializar, y poder convertir los datos del EntitiyFramework a una clase
    //serializable que pueda ocupar el servicio en conjunto con los demás OperationContext 
    [DataContract]
    public class Player
    {


        private int idPlayer;
        private string nickname;
        private string password;
        private string email;
        private List<CardType> cards;
        private string cardsString;
        private int tokens;
        private Nullable<int> totalScore;
        private string name;
        private string lastName;
        private string profileImage;
        private bool status;

        #region Non-Serializable
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
        public string CardsString { get { return cardsString; } set { cardsString = value; } }
        [DataMember]
        public int Tokens { get { return tokens; } set { tokens = value; } }
        [DataMember]
        public Nullable<int> TotalScore { get { return totalScore; } set { totalScore = value; } }
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public string LastName { get { return lastName; } set { lastName = value; } }
        [DataMember]
        public string ProfileImage { get { return profileImage; } set { profileImage = value; } }
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"Id-{idPlayer}Nick-{nickname}Pass-{password}email-{email}cards-{cards}cardsstring-{cardsString}" +
                $"tokens-{tokens}total-{totalScore}Nombre-{name}apellido-{lastName}imagen-{profileImage}status-{status}";
        }
        #endregion
    }
}
