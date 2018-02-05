using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        private Stack<Card> _mainDeck;

        public Deck()
        {
            CreateDeck();
        }

        private void CreateDeck()
        {
            List<Card> tempDeck = new List<Card>(Constant.DeckSize);
            for (int i = 1; i <= Constant.DeckSize; i++)
            {
                tempDeck.Add(new Card()
                {
                    Suit = (i % Constant.SuitSize) == 0 ? (CardSuit)Constant.SuitSize : (CardSuit)(i % Constant.SuitSize),
                    Value = (i % Constant.ValueSize) == 0 ? (CardValue)Constant.ValueSize : (CardValue)(i % Constant.ValueSize),
                    Point = (i % Constant.ValueSize) == 0
                    || (i % Constant.ValueSize)== Constant.JackVal
                    || (i % Constant.ValueSize) == Constant.QueenVal ? Constant.MaxValue : (i % Constant.ValueSize)
                });
            }

            tempDeck =  Shuffle(tempDeck);
            _mainDeck = new Stack<Card>(tempDeck);
        }

        private List<Card> Shuffle(List<Card> deck)
        {
            return deck.OrderBy(y => Guid.NewGuid()).ToList();
        }

        public Card GetCard()
        {
            return _mainDeck.Pop();
        }
    }
}
