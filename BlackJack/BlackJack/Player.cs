namespace BlackJack
{
    public class Player
    {
        private Hand _hand { get; set; }
        public string Name { get; set; }
        public bool Busted { get; set; }
        public bool Draw { get; set; } = true;

        public Player(string name)
        {
            Name = name;
            _hand = new Hand();
        }

        public void Turn(Deck deck)
        {
            _hand.TakeCard(deck);
        }

        public int GetResult()
        {
            return _hand.Result;
        }

        public void Action(Deck deck)
        {
            Turn(deck);
            ShowCards();
            CheckJack();
        }

        public void CheckJack()
        {
            if (_hand.Result > Constant.BlackJack)
            {
                Draw = false;
                Busted = true;
            }
            if (_hand.Result == Constant.BlackJack)
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
            _hand.ViewCards();
        }
    }
}
