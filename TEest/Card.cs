using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEest
{
    enum Suit { Clubs, Diamonds, Hearts, Spades, Joker }
    internal class Card
    {
        public int TypeCard { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public Card(string suit, int value, int typeCard) {
           Suit = suit;
           Value = value;
           TypeCard = typeCard;
        }

        public string getMaxCard(int value, int TypeCard) {
            if (TypeCard == 1) {
                return value == 11 ? "Jack" : (value == 12 ? "Queen" : (value == 13 ? "King" : value.ToString()));
            }
            return  value.ToString();

        }
        public override string ToString() {
            return $"{Suit} {getMaxCard(Value, TypeCard)}";
        }
        /// <summary>
        /// Step 5 Get the points of every card, cause later we are going to use to sum all the cars by player maze
        /// </summary>
        /// <returns></returns>
        internal int GetPoints()
        {
            return Suit == "Joker" ? 0 : Value;
        }

        //public int GetPoints() { 
        //}
    }
}
