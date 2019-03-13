using System;
using System.Collections.Generic;
namespace Base.Objects
{
    public class Deck
    {
        // private string[] rank;
        private char[] suit;
        public Card[] cards {get;}
        public Deck()
        {
            byte cardNum = 0;
            cards = new Card[52];
            // rank = new string[]{"Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace"};
            suit = new char[]{'d', 'h', 'c', 's'};
            for(byte i = 2; i < 15; i++)
            {
                for(byte j = 0; j < 4; j++)
                {
                    Card card = new Card(i, suit[j], cardNum);
                    cards[cardNum] = card;
                    cardNum++;
                }
            }
        }
    }
}