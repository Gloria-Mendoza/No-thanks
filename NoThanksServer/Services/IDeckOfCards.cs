using System;
using System.Collections.Generic;
using System.Linq;
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
        void ShuffleDeck(CardType[] gameDeck);

        [OperationContract(IsOneWay = true)]
        void DiscardFirstNine(CardType[] gameDeck);
    }

    [ServiceContract]
    public interface IDeckOfCardsCallBack
    {
        [OperationContract(IsOneWay = true)]
        void CreateDeckCallBack(CardType[] gameDeck);

        [OperationContract(IsOneWay = true)]
        void ShuffleDeckCallBack(CardType[] shuffledDeck);

        [OperationContract(IsOneWay = true)]
        void DiscardFirstNineCallback(CardType[] gameDeck);
    }
}

