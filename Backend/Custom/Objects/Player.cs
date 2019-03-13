using System;
using Backend;
using Backend.Interfaces;
using Backend.Functions;
namespace Backend.Objects
{
    public class Player: IShowCard, ISetTieCondition
    {
        public string name { get; }
        public Card[] hand { get; }
        public Object[] result { get; }
        private int[] tiebreaker;
        public Player(string _name, Card[] cards, Card[] board)
        {
            name = _name;
            hand = cards;
            result = PokerFunctions.Combinatorics(PreGame.DealCards(hand,board));
            // IShowCard();
        }
        public void IShowCard()
        {
            System.Console.WriteLine($"THESE ARE THE CARDS BELONG TO PLAYER {this.name}");
            System.Console.WriteLine($"This card is the {this.hand[0].rank} of {this.hand[0].suit}");
            System.Console.WriteLine($"This card is the {this.hand[1].rank} of {this.hand[1].suit}");
        }
        public void ISetTieCondition(int[] hey)
        {
            tiebreaker = hey;
        }
        public int[] GetTieBreaker()
        {
            int[] _tiebreaker = tiebreaker;
            return _tiebreaker;
        }
    }
}