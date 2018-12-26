using System;
using Base.Interfaces;
using Base.Functions;
namespace Base.Objects
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
            System.Console.WriteLine($"THESE ARE THE CARDS BELONG TO PLAYER {name}");
            System.Console.WriteLine($"This card is the {hand[0].rank} of {hand[0].suit}");
            System.Console.WriteLine($"This card is the {hand[1].rank} of {hand[1].suit}");
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