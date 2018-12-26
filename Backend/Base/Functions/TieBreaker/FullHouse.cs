using System;
using System.Collections.Generic;
using Base.Objects;
using Base.Functions;
namespace Base.BreakTie
{
    public static class FullHouse
    {
        public static Object[] BreakTie(List<Player> winners, List<Player> losers)
        {
            foreach(var winner in winners)
            {
                int[] hot;
                Card[] result = (Card[])winner.result[1];
                int compare = result[2].value;
                if(compare == result[0].value)
                {
                    hot = new int[]{result[4].value,compare};
                }
                else
                {
                    hot = new int[]{result[0].value,compare};
                }
                winner.ISetTieCondition(hot);
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}