using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;

    namespace Services
    {
        public enum CardType
        {
            Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen, Eightteen,
            Nineteen, Twenty, TwentyOne, TwentyTwo, TwentyThree, TwentyFour, TwentyFive, TwentySix, TwentySeven, TwentyEight, TwentyNine,
            Thirty, ThirtyOne, ThirtyTwo, ThirtyThree, ThirtyFour, ThirtyFive
        }

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
}

