
namespace BlackJack
{
    class Dealer : Player
    {
        public Dealer(string name) : base(name)
        {
            Name = name;
            hand = new Hand();
        }
    }
}
