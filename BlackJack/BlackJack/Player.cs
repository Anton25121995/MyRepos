using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Hand hand;
        public string Name { get; set; }
        public bool Busted { get; set; } = false;
        public bool Draw { get; set; } = true;

        public Player(string name)
        {
            Name = name;
            hand = new Hand();
        }

        public void Turn(Deck deck)
        {
            hand.TakeCard(deck);
            
            CheckJack();
        }

        public void CheckJack()
        {
            if (hand.Result > Constant.jack)
            {
                Draw = false;
                Busted = true;
            }
            if (hand.Result == Constant.jack)
            {
                Draw = false; 
            }
        }

        public bool HitOrStand()
        {
            Draw = View.HitOrStand();
            return Draw;
        }

        public void ShowCards()
        {
            hand.ViewCards();
        }
    }
}
