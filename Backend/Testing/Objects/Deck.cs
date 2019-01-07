using System;
using System.Collections.Generic;
namespace Base.Objects
{
    public class Deck
    {
        private string[] rank;
        private string[] suit;
        public Card[] cards {get;}
        public Deck()
        {
            int cardNum = 0;
            cards = new Card[52];
            rank = new string[]{"Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            suit = new string[]{"Diamonds", "Hearts", "Clubs", "Spades"};
            for(int i = 0; i < rank.Length; i++)
            {
                for(int j = 0; j < suit.Length; j++)
                {
                    Card card = new Card(i+2, rank[i], suit[j], cardNum);
                    cards[cardNum] = card;
                    cardNum++;
                }
            }
        }
    }
}