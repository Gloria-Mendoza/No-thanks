using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Services
{
    
    [ServiceContract(CallbackContract = typeof(IDeckOfCardsCallBack))]
    public interface IDeckOfCards
    {
        [OperationContract(IsOneWay = true)]
        void CreateDeck();
        [OperationContract(IsOneWay = true)]
        void ShuffleDeck();
        [OperationContract(IsOneWay = true)]
        void DiscardFirstNine();
        [OperationContract(IsOneWay = true)]
        void TakeCard();
    }

    [ServiceContract]
    public interface IDeckOfCardsCallBack
    {
        [OperationContract(IsOneWay = true)]
        void UpdateDeck(CardType[] gameDeck);
        [OperationContract(IsOneWay = true)]
        void TakeCardCallBack(CardType card);
    }
    
    public partial class MatchMember
    {
        [IgnoreDataMember]
        public IDeckOfCardsCallBack DeckOfCardsCallBack { get; set; }
    }
}

