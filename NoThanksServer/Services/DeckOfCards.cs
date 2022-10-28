using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Services.Services;

namespace Services
{
    [ServiceBehavior]
    public class DeckOfCards : IDeckOfCards
    {
        public void CreateDeck()
        {
            var deck = new List<CardType>();
            for (int i = 0; i < Enum.GetValues(typeof(CardType)).Length; i++)
            {
                deck.Add((CardType)i);
            }
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.CreateDeckCallBack(deck.ToArray());
        }

        public void DiscardFirstNine(CardType[] gameDeck)
        {
            var newDeck = new List<CardType>(gameDeck);
            newDeck.RemoveRange(0, 9);
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.DiscardFirstNineCallback(newDeck.ToArray());
        }

        public void ShuffleDeck(CardType[] gameDeck)
        {
            var newDeck = new List<CardType>(gameDeck);
            var random = new Random();
            for (int i = 0; i < newDeck.Count; i++)
            {
                var temp = newDeck[i];
                var randomIndex = random.Next(0, newDeck.Count);
                newDeck[i] = newDeck[randomIndex];
                newDeck[randomIndex] = temp;
            }
            var callback = OperationContext.Current.GetCallbackChannel<IDeckOfCardsCallBack>();
            callback.ShuffleDeckCallBack(newDeck.ToArray());
        }
    }

}
