using System;
namespace Base.Objects
{
    public class Card
    {
        public int value  { get; }
        public string rank { get; }
        public string suit { get; }
        public int cardNum { get; }
        public Card(int _value, string _rank, string _suit, int _cardNum)
        {
            value = _value;
            rank = _rank;
            suit = _suit;
            cardNum = _cardNum;
        }
    }
}