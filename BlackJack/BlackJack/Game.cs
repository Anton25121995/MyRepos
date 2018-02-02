using System;

namespace BlackJack
{
    class Game
    {
        Player player;
        Dealer dealer;

        Deck deck = new Deck();

        public bool MoreGames { get; set; } = true;

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

                isContinue = Check();
                Console.Clear();
            }
        }

        void Action(Player player)
        {
            player.Turn(deck);
            player.ShowCards();
            player.CheckJack();
        }

        void MainPhase(Player player, Dealer dealer, Deck deck)
        {
            while (player.HitOrStand())
            {
                Action(player);
            }

            while (dealer.hand.Result < Constant.border && !player.Busted)
            {
                Action(dealer);
                dealer.Draw = dealer.hand.Result < Constant.border;
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
            player.hand.TakeCard(deck);
            player.hand.TakeCard(deck);
        }

        void DecideWin()
        {
            View.DisplayBoard(player, dealer);
            
            if (((player.hand.Result > dealer.hand.Result) && !player.Busted)
                || (player.hand.Result == Constant.jack) 
                || (player.hand.Result < dealer.hand.Result && dealer.Busted))
            {
                View.PlayerWon();
            }

            if ((dealer.hand.Result == Constant.jack) || player.Busted)
            {
                View.PlayerLost();
            }

            if ((player.hand.Result == Constant.jack) && (dealer.hand.Result == Constant.jack))
            {
                View.Both();
            }

            if ((player.hand.Result == dealer.hand.Result) && (player.hand.Result != Constant.jack))
            {
                View.Tie();
            }
        }


        public bool Check()
        {
            MoreGames = (View.IsPlayAgain()) ? true : false;
            return MoreGames;
        }
    }
}

