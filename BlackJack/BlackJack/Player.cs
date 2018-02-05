using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Hand Hand { get; set; }
        public string Name { get; set; }
        public bool Busted { get; set; } = false;
        public bool Draw { get; set; } = true;

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public void Turn(Deck deck)
        {
            Hand.TakeCard(deck);
        }

        public void Action(Deck deck)
        {
            Turn(deck);
            ShowCards();
            CheckJack();
        }

        public void CheckJack()
        {
            if (Hand.Result > Constant.Jack)
            {
                Draw = false;
                Busted = true;
            }
            if (Hand.Result == Constant.Jack)
            {
                Draw = false;
            }
        }

        public bool HitOrStand()
        {
            if (!Busted)
            {
                Draw = View.HitOrStand();
            }
            return Draw;
        }

        public void ShowCards()
        {
            Hand.ViewCards();
        }
    }
}
