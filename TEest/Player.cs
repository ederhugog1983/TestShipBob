using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEest
{
    internal class Player
    {
        public string Name;
        public List<Card> Maze { get; set; }
        public Player(string name) { 
            Name = name;
            Maze = new List<Card>();
        }
        public override string ToString()
        {
            return $"\nPlayer: {Name}, gets this hand \n " + String.Join("\n", Maze);
        }
        public void TakeCardsToMaze(List<Card> cards) { 
            Maze.AddRange(cards);
        }
        /// <summary>
        /// step 5 for every maze for player get the sum of the total points
        /// </summary>
        /// <returns></returns>
        public int GetTotalPointsMaze() {
            return Maze.Sum(card => card.GetPoints());
        }
        /// <summary>
        /// step 5 order the player accoriding the points from max to min
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public static Player GetWinnerMaze(List<Player> players) { 
            return players.OrderByDescending(p => p.GetTotalPointsMaze()).FirstOrDefault();
        }
    }
}
