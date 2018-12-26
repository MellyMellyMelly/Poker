using System;
using Base.Interfaces;
using Base.Functions;
namespace Base.Objects
{
    public class Board: IShowCard
    {
        public Card[] hand;
        public Board(int[] everything, Deck deck)
        {
            int index = 0;
            hand = new Card[5];
            for(int z = everything.Length - 5; z < everything.Length; z++)
            {
                hand[index] = deck.cards[everything[z]];
                // System.Console.WriteLine(communityArray[index].cardNum);
                index++;
            }
            // IShowCard();
        }
        public void IShowCard()
        {
            System.Console.WriteLine($"THESE ARE THE COMMUNITY CARDS");
            System.Console.WriteLine($"This card is the {hand[0].rank} of {hand[0].suit}");
            System.Console.WriteLine($"This card is the {hand[1].rank} of {hand[1].suit}");
            System.Console.WriteLine($"This card is the {hand[2].rank} of {hand[2].suit}");
            System.Console.WriteLine($"This card is the {hand[3].rank} of {hand[3].suit}");
            System.Console.WriteLine($"This card is the {hand[4].rank} of {hand[4].suit}");
        }
    }
}