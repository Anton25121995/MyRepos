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
            player = new Player("Player");
            dealer = new Dealer("Dealer");

            View.Welcome();
            StartPhase();
            MainPhase(player, dealer, deck);
            CheckJack(player, dealer);

            Propose();
            deck = new Deck();
        }

        void MainPhase(Player player, Dealer dealer, Deck deck)
        {
            dealer.Draw = dealer.hand.Result < Constant.jack;
            while (player.Draw)
            {
                player.HitOrStand(); // предложить взять еще карту или отказаться
                if (player.Draw)
                {
                    player.Turn(deck);
                    CheckJack(player, dealer);
                }
            }
            if (!(player.Busted)) //если у игрока не перебор, то диллер играет до Constant.border
            {
                while (dealer.Draw)
                {
                    dealer.Turn(deck);
                }
            }
            if ((dealer.Draw) && (!dealer.Busted))
            {
                DecideWin();
                Propose();
            }
        }

        public void CheckJack(Player player, Dealer dealer)
        {
            player.CheckJack();
            dealer.CheckJack();
            if (player.Busted || dealer.Busted)
            {
                DecideWin();
            }
            if ((player.hand.Result == Constant.jack) || (dealer.hand.Result == Constant.jack))
            {
                DecideWin();
            }
        }

        void StartPhase()
        {
            GetStart(dealer, deck);
            GetStart(player, deck);
            View.DisplayBoard(player, dealer);
            CheckJack(player, dealer);
        }

        void GetStart(Player player, Deck deck)
        {
            player.hand.TakeCard(deck);
            player.hand.TakeCard(deck);
            //CheckJack(player, dealer);
        }

        void DecideWin()
        {
            if ((player.hand.Result < dealer.hand.Result) && (dealer.Busted))
            {
                View.PlayerWon();
            }

            if ((player.hand.Result > dealer.hand.Result) && (player.hand.Result == Constant.jack))
            {
                View.PlayerWon();
            }

            if ((player.hand.Result > dealer.hand.Result) && (dealer.hand.Result < Constant.jack))
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

        void Propose()
        {
            Check();
            Console.Clear();
        }

        public bool Check()
        {
            MoreGames = (View.IsPlayAgain()) ? true : false;
            return MoreGames;
        }
    }
}

