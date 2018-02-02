using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        private List<Card> _deck;
        private Stack<Card> _mainDeck;
        private Random rand = new Random();

        public Deck()
        {
            Random rand = new Random();
            _deck = new List<Card>(Constant.deckSize);
            GenDeck();
        }

        private void GenDeck()
        {
            CreateDeck();
            Shuffle();
            FillDeck();
        }

        private Card Replace(Card card)
        {
            if ((int)card.Value >= Constant.maxValue && (int)card.Value <= Constant.valueSize)
            {
                card.Point = Constant.maxValue;
            }
            return card;
        }

        private void CreateDeck()
        {
            for (int i = 1; i <= Constant.deckSize; i++)
            {
                _deck.Add(Replace(new Card()
                {
                    Suit = (i % Constant.suitSize) == 0 ? (CardSuit)Constant.suitSize : (CardSuit)(i % Constant.suitSize),
                    Value = (i % Constant.valueSize) == 0 ? (CardValue)Constant.valueSize : (CardValue)(i % Constant.valueSize),
                    Point = (i % Constant.valueSize) == 0 ? Constant.valueSize : (i % Constant.valueSize)
                }));
            }
        }

        private void Shuffle()
        {
            _deck = _deck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private void FillDeck()
        {
            _mainDeck = new Stack<Card>(_deck);
            foreach (Card x in _deck)
            {
                _mainDeck.Push(x);
            }
        }

        public Card GetCard()
        {
            return _mainDeck.Pop();
        }
    }
}
