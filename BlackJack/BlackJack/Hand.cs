using System.Collections.Generic;

namespace BlackJack
{
    public class Hand
    {
        private List<Card> _myCards;
        public int Result { get; set; }

        public Hand()
        {
            _myCards = new List<Card>();
        }

        public Card TakeCard(Deck deck)
        {
            var card = deck.GetCard();
            Result += card.Point;
            _myCards.Add(card);
            return card;
        }

        public void ViewCards()
        {
            View.ShowCard(_myCards, Result);
        }
    }
}
