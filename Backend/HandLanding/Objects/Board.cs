using System;
using HandLanding;
using HandLanding.Interfaces;
using HandLanding.Functions;
namespace HandLanding.Objects
{
    public class Board: IShowBoard
    {
        public Card[] hand;
        public Board(int[] everything, Deck deck, int[] specificBoard)
        {
            int index = 0;
            hand = new Card[5];
            for(int z = everything.Length - 5; z < everything.Length; z++)
            {
                hand[index] = deck.cards[everything[z]];
                // System.Console.WriteLine(communityArray[index].cardNum);
                index++;
            }
            IShowBoard(specificBoard);
        }
        public void IShowBoard(int[] specificBoard)
        {
            int hide = 0;
            if(specificBoard.Length>0)
            {
                foreach(Card card in hand)
                {
                    if(card.cardNum == specificBoard[hide])
                    {
                        hide++;
                        if(hide == specificBoard.Length)
                        {
                            hide--;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine($"This card is the {card.rank} of {card.suit}");
                    }
                }
            }
            else
            {
                foreach(Card card in hand)
                {
                    System.Console.WriteLine($"This card is the {card.rank} of {card.suit}");
                }
            }
            System.Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
        }
    }
}