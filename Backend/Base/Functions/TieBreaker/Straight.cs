using System;
using System.Collections.Generic;
using Base.Objects;
using Base.Functions;
namespace Base.BreakTie
{
    public static class Straight
    {
        public static Object[] BreakTie(List<Player> winners, List<Player> losers)
        {
            foreach(var winner in winners)
            {
                int[] hot;
                Card[] result = (Card[])winner.result[1];
                if(result[4].value%13 == result[0].value-1)
                {
                    hot = new int[]{result[3].value};
                }
                else
                {
                    hot = new int[]{result[4].value};
                }
                winner.SetTieCondition(hot);
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}