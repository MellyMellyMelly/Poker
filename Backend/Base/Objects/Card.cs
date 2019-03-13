using System;
namespace Base.Objects
{
    public class Card
    {
        public byte value  { get; }
        public char suit { get; }
        public byte cardNum { get; }
        public Card(byte _value, char _suit, byte _cardNum)
        {
            value = _value;
            suit = _suit;
            cardNum = _cardNum;
        }
    }
}