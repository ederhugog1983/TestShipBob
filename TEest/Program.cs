using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<string> SpanCards = new List<string>() { "Swords", "Cups", "Coins", "Clubs", "Joker" };
            List<string> PokerCards = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades", "Joker" };

            // var spanDeck = new Deck(SpanCards,2);
            var pokerDeck = new Deck(PokerCards,1);
            // spanDeck.Suffle();
            pokerDeck.Suffle();

            // Console.WriteLine(spanDeck);
            // Step 3
            Console.WriteLine(pokerDeck);
            var players = new List<Player>()
            {
                new Player("Wolverine"),
                new Player("Rogue"),
                new Player("Storm"),
                new Player("Beast"),
            };

            foreach (var player in players)
            {
                player.TakeCardsToMaze(pokerDeck.Deal(5));
                Console.WriteLine(player);
            }
            // end step 3
            Console.WriteLine($"Cards in deck now: {pokerDeck.Cards.Count}");
            //step 4 
            players = pokerDeck.DealAgain(players); // return cards on deck 
            pokerDeck.Suffle(); // suffle again
            Console.WriteLine(pokerDeck);
            Console.WriteLine($"Cards in deck now after deal again: { pokerDeck.Cards.Count}");

            foreach (var player in players) // set again a deal for each player
            {
                player.TakeCardsToMaze(pokerDeck.Deal(5));
                Console.WriteLine(player);
            }
            Console.WriteLine($"Cards in deck now after deal again: {pokerDeck.Cards.Count}");
            // end step 4


            //step 5

            Player playerWinner = Player.GetWinnerMaze(players);
            Console.WriteLine($"The card winner is: {playerWinner}");
            Console.ReadLine();
        }
    }
}
