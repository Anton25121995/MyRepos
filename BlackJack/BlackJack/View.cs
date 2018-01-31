using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    static public class View
    {
        public static void Welcome()
        {
            Console.WriteLine("Welcome to game BlackJack");
            Console.WriteLine();
        }

        public static void PlayerWon()
        {
            Console.WriteLine("Player won, dealer lost!");
            Console.WriteLine();
        }

        public static void PlayerLost()
        {
            Console.WriteLine("Player lost, dealer won...");
            Console.WriteLine();
        }

        public static void Tie()
        {
            Console.WriteLine("Player & Dealer have the same points :) It is tie");
        }

        public static void Both()
        {
            Console.WriteLine("Player & Dealer have 21 :) It is tie");
        }

        public static void ShowCard(List<Card> myCards, int point)
        {
            foreach (Card card in myCards)
            {
                Console.WriteLine(String.Format("Card {0}: {1}, {2} - {3} ", myCards.IndexOf(card) + 1, card.Suit, card.Value, card.Point));
            }
            Console.WriteLine($"Points at now : {point}");
            Console.WriteLine();
        }

        public static void DisplayBoard(Player player, Player dealer)
        {
            Console.WriteLine("_________________TOTAL_________________");
            Console.WriteLine("Dealer's cards:");
            dealer.hand.ViewCards();
            Console.WriteLine();
            Console.WriteLine("Player's cards:");
            player.hand.ViewCards();
            Console.WriteLine("_______________________________________");
        }
        

        public static string Input()
        {
            string answer = Console.ReadLine().ToUpper();
            return answer;
        }

        public static bool HitOrStand()
        {
            Console.WriteLine("\nWould you like to (H)it or (S)tand: ");
            string answer = Input();
            return answer == "H";
        }

        public static bool IsPlayAgain()
        {
            Console.WriteLine("Would you like more games? Y (Yes) / N (No)");
            string answer = Input();
            return answer == "Y";
        }
    }
}
