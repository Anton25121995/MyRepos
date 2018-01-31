using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        private List<Card> _deck; // для перемешивания
        private Stack<Card> _mainDeck; // основная рабочая колода
        private Random rand = new Random();

        public Deck()
        {
            Random rand = new Random();
            _deck = new List<Card>(52);
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
            if ((int)card.Value >= 10 && (int)card.Value <= 13)
            {
                card.Point = 10;
            }
            return card;
        }

        private void CreateDeck()
        {
            for (int i = 1; i <= Constant.deckSize; i++)
            {
                _deck.Add(Replace(new Card()
                {
                    Suit = (i % 4) == 0 ? (CardSuit)4 : (CardSuit)(i % 4),
                    Value = (i % 13) == 0 ? (CardValue)13 : (CardValue)(i % 13),
                    Point = (i % 13) == 0 ? 13 : (i % 13)
                }));
            }
        }

        private void Shuffle()
        {
            Random rand = new Random();
            _deck = _deck.OrderBy(x => rand.Next()).ToList();
        }

        private void FillDeck() // перемешанную колоду закидываем в стек
        {
            _mainDeck = new Stack<Card>(52);
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
