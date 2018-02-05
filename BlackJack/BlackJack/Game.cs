using System;

namespace BlackJack
{
    public class Game
    {
        private Player _player;
        private Player _dealer;

        Deck deck = new Deck();

        public void Playing()
        {
            bool isContinue = true;

            while (isContinue)
            {
                _player = new Player("Player");
                _dealer = new Player("Dealer");
                deck = new Deck();
                View.Welcome();
                StartPhase();

                MainPhase(_player, _dealer, deck);
                DecideWin();

                isContinue = View.IsPlayAgain() ? true : false;
                Console.Clear();
            }
        }

        private void MainPhase(Player player, Player dealer, Deck deck)
        {
            while (player.HitOrStand())
            {
                player.Action(deck);
            }

            while (dealer.GetResult() < Constant.MaxDealerResult && !player.Busted)
            {
                dealer.Action(deck);
                dealer.Draw = dealer.GetResult() < Constant.MaxDealerResult;
            }
        }

        private void StartPhase()
        {
            GetStart(_dealer, deck);
            GetStart(_player, deck);
            View.DisplayBoard(_player, _dealer);
        }

        private void GetStart(Player player, Deck deck)
        {
            for (int i = 0; i < Constant.StartCardCount; i++)
            {
                player.Turn(deck);
            }
        }

        private void DecideWin()
        {
            int playerResult = _player.GetResult();
            int dealerResult = _dealer.GetResult();

            View.DisplayBoard(_player, _dealer);

            if ((playerResult > dealerResult && !_player.Busted) 
                || _dealer.Busted
                || (playerResult == Constant.BlackJack))
            {
                View.PlayerWon();
            }

            if ((playerResult < dealerResult && !_dealer.Busted ) 
                || _player.Busted
                || (dealerResult == Constant.BlackJack))
            {
                View.PlayerLost();
            }

            if (playerResult == dealerResult)
            {
                View.Tie();
            }
        }
    }
}

