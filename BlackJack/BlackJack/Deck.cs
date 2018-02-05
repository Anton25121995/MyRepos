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
            for (int i = 1; i <= Constant.SuitSize; i++)
            {
                for (int j = 1; j <= Constant.ValueSize; j++)
                {
                    if (j < Constant.MaxValue)
                    {
                        tempDeck.Add(new Card() { Suit = (CardSuit)i, Value = (CardValue)j, Point = j });
                    }
                    if ((j >= Constant.MaxValue) && (j <= Constant.ValueSize))
                    {
                        tempDeck.Add(new Card() { Suit = (CardSuit)i, Value = (CardValue)j, Point = Constant.MaxValue });
                    }
                }
            }
            tempDeck = Shuffle(tempDeck);
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
