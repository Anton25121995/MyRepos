using System;

namespace BlackJack
{
    class Game
    {
        Player player;
        Dealer dealer;

        Deck deck = new Deck();

        public void Playing()
        {
            bool isContinue = true;

            while (isContinue)
            {
                player = new Player("Player");
                dealer = new Dealer("Dealer");
                deck = new Deck();
                View.Welcome();
                StartPhase();

                MainPhase(player, dealer, deck);
                DecideWin();

                isContinue = View.IsPlayAgain() ? true : false;
                Console.Clear();
            }
        }

        void MainPhase(Player player, Dealer dealer, Deck deck)
        {
            while (player.HitOrStand())
            {
                player.Action(deck);
            }

            while (dealer.Hand.Result < Constant.Border && !player.Busted)
            {
                dealer.Action(deck);
                dealer.Draw = dealer.Hand.Result < Constant.Border;
            }
        }

        void StartPhase()
        {
            GetStart(dealer, deck);
            GetStart(player, deck);
            View.DisplayBoard(player, dealer);
        }

        void GetStart(Player player, Deck deck)
        {
            player.Hand.TakeCard(deck);
            player.Hand.TakeCard(deck);
        }

        void DecideWin()
        {
            View.DisplayBoard(player, dealer);

            if (((player.Hand.Result > dealer.Hand.Result) && !player.Busted)
                || (player.Hand.Result == Constant.Jack)
                || (player.Hand.Result < dealer.Hand.Result && dealer.Busted))
            {
                View.PlayerWon();
            }

            if ((dealer.Hand.Result == Constant.Jack) 
                || player.Busted
                || (dealer.Hand.Result > player.Hand.Result && !player.Busted && !dealer.Busted))
            {
                View.PlayerLost();
            }

            if (player.Hand.Result == dealer.Hand.Result)
            {
                View.Tie();
            }
        }
    }
}

