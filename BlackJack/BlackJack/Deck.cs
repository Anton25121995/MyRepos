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

        private void CreateDeck()
        {
            //foreach (var suit in Enum.GetValues(typeof(CardSuit)))
            //{
            //    foreach (var value in Enum.GetValues(typeof(CardValue)))
            //    {
            //        if ((int)value <= Constant.maxValue)
            //        {
            //            _deck.Add(new Card() { Suit = (CardSuit)suit, Value = (CardValue)value, Point = (int)value });
            //        }
            //        if (((int)value > Constant.maxValue) && ((int)value <= Constant.valueSize))
            //        {
            //            _deck.Add(new Card() { Suit = (CardSuit)suit, Value = (CardValue)value, Point = Constant.maxValue });
            //        }
            //    }
            //}

            for (int i = 0; i < Constant.deckSize; i++)
            {
                _deck.Add(new Card() { Suit = (CardSuit)(i % 4), Value = (CardValue)(i % 13), Point = (i % 13) });
            }

            //for (int i = 1; i <= Constant.suitSize; i++)
            //{
            //    for (int j = 1; j <= Constant.valueSize - 1; j++)
            //    {
            //        if (j <= Constant.maxValue)
            //        {
            //            _deck.Add(new Card() { Suit = (CardSuit)i, Value = (CardValue)j, Point = j });
            //        }
            //        if ((j >= Constant.maxValue) && (j <= Constant.valueSize))
            //        {
            //            _deck.Add(new Card() { Suit = (CardSuit)i, Value = (CardValue)j, Point = Constant.maxValue });
            //        }
            //    }
            //}
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
