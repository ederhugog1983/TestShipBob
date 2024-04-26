using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEest
{
    class test { 
        string name { get; set; }
        int value { get; set; }
    }
    internal class Deck
    {
        private List<string> spanCards;

        public List<Card> Cards { get; set; }
        public Deck() { 
            Cards = new List<Card>();
            foreach(Suit suite in Enum.GetValues(typeof(Suit)))
            {
                if(suite == Suit.Joker) {
                    for (int i = 0; i < 2; i++)
                    {  // jokers
                        //Cards.Add(new Card(suite, 0));
                    }
                }
                else
                {
                    for (int i = 1; i <= 13; i++)
                    {  
                        //Cards.Add(new Card(suite, i));
                    }
                }
                
            }
        }
       
        public Deck(List<string> cards, int type)
        {
            Cards = new List<Card>();
            Parallel.ForEach(cards, suite =>
            {
                if (suite == "Joker")
                {
                    for (int i = 0; i < 2; i++)
                    {  // jokers
                        Cards.Add(new Card(suite, 0, type));
                    }
                }
                else
                {
                    for (int i = 1; i <= (type == 1 ? 13 : 12); i++)
                    {
                        Cards.Add(new Card(suite, i, type));
                    }
                }
            });
            //foreach (string suite in cards)
            //{
            //    if (suite == "Joker")
            //    {
            //        for (int i = 0; i < 2; i++)
            //        {  // jokers
            //            Cards.Add(new Card(suite, 0, type));
            //        }
            //    }
            //    else
            //    {
            //            for (int i = 1; i <= (type == 1 ? 13 : 12); i++)
            //            {
            //                Cards.Add(new Card(suite, i, type));
            //            }
            //    }
            //}
        }
        public void Suffle()
        {
            Random random = new Random();
            Cards = Cards.OrderBy(x => random.Next()).ToList();
        }
        /// <summary>
        /// step 3
        /// </summary>
        /// <param name="sizeMaze"></param>
        /// <returns></returns>
        public List<Card> Deal(int sizeMaze) {
            List<Card> dealCards = Cards.Take(sizeMaze).ToList();
            Cards = Cards.Skip(sizeMaze).ToList();
            return dealCards;
        }
        /// <summary>
        /// step 4
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public List<Player> DealAgain(List<Player> players) {
            // return each maze to the main deck
            foreach (Player p in players) {
                Cards.AddRange(p.Maze);
                // skip the cards from each player
                p.Maze = p.Maze.Skip(players.Count).ToList();
            }
            return players;
            //suffle again
        }
        public override string ToString()
        {
            return String.Join("\n", Cards);
        }
    }
}
