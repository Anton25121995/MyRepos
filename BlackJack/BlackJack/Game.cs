using System;

namespace BlackJack
{
    class Game
    {
        Player player;
        Player dealer;

        Deck deck = new Deck();

        public void Playing()
        {
            bool isContinue = true;

            while (isContinue)
            {
                player = new Player("Player");
                dealer = new Player("Dealer");
                deck = new Deck();
                View.Welcome();
                StartPhase();

                MainPhase(player, dealer, deck);
                DecideWin();

                isContinue = View.IsPlayAgain() ? true : false;
                Console.Clear();
            }
        }

        void MainPhase(Player player, Player dealer, Deck deck)
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

            if (((player.Hand.Result > dealer.Hand.Result) && !player.Busted || dealer.Busted)
                || (player.Hand.Result == Constant.BlackJack))
            {
                View.PlayerWon();
            }

            if (((player.Hand.Result < dealer.Hand.Result)  && !dealer.Busted || player.Busted)
                || (dealer.Hand.Result == Constant.BlackJack))
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

