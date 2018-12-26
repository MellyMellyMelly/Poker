using System;
using System.Collections.Generic;
using Base.Objects;
namespace Base.Functions
{
    public static class HandAnalyzer
    {
        public static bool Straight(Card[] hand)
        {
            int breaker = 0;
            int count = 0;
            while(breaker < 9 && count < 4)
            {
                for(int i = 1; i < hand.Length; i++){
                    // if(breaker == 9)
                    // {
                    //     return false;
                    // }
                    breaker++;
                    if(hand[i-1].value == hand[i].value-1)
                    {
                        count++;
                    }
                    else
                    {
                        if(count != 4)
                        {
                            count = 0;
                        }
                    }
                }
                if(hand[hand.Length-1].value%13 != hand[0].value-1)
                {
                    breaker = 9;
                }
                else
                {
                    if(count != 4)
                    {
                        count = 1;
                    }
                }
            }
            if(count == 4){
                return true;
            }
            return false;
        }
        public static bool Flush(Card[] hand)
        {
            for(int i = 1; i < hand.Length; i++)
            {
                if(hand[i-1].suit != hand[i].suit)
                {
                    return false;
                }
            }
            return true;
        }
        public static Object[] CommonRank(Card[] hand)
        {
            int streak = 1;
            double result = 0;
            for(int i = 1; i < hand.Length; i++){
                if(hand[i-1].value == hand[i].value)
                {
                    streak++;
                    result += (int)Math.Pow(streak,streak);
                }
                else
                {
                    streak = 1;
                }
            }
            Object[] info = new Object[2]{(int)result,hand};
            return info;
        }
    }
}