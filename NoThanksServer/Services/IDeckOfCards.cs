using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static Logic.Player;
using Logic;

namespace Services
{
    
    [ServiceContract(CallbackContract = typeof(IDeckOfCardsCallBack))]
    public interface IDeckOfCards
    {
        [OperationContract(IsOneWay = true)]
        void CreateDeck(String roomId);
        [OperationContract(IsOneWay = true)]
        void TakeCard(String roomId);
    }

    [ServiceContract]
    public interface IDeckOfCardsCallBack
    {
        [OperationContract(IsOneWay = true)]
        void UpdateDeck(CardType[] gameDeck);
        [OperationContract(IsOneWay = true)]
        void UpdatePlayerDeck(CardType[] playerDeck);
    }
    
    public partial class MatchMember
    {
        [IgnoreDataMember]
        public IDeckOfCardsCallBack DeckOfCardsCallBack { get; set; }
        [DataMember]
        public List<CardType> deck;
    }
}

