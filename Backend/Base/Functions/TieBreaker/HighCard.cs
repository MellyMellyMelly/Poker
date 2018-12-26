using System;
using System.Collections.Generic;
using Base.Objects;
using Base.Functions;
namespace Base.BreakTie
{
    public static class HighCard
    {
        public static Object[] BreakTie(List<Player> winners, List<Player> losers)
        {
            foreach(var winner in winners)
            {
                int[] values = new int[5];
                Card[] result = (Card[])winner.result[1];
                for(int i = 0; i < result.Length; i++)
                {
                    values[i] = result[i].value;
                }
                winner.ISetTieCondition(values);
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}