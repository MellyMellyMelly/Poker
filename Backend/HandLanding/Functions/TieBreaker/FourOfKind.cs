using System;
using System.Collections.Generic;
using HandLanding.Objects;
using HandLanding.Functions;
namespace HandLanding.BreakTie
{
    public static class FourOfKind
    {
        public static Object[] BreakTie(List<Player> winners, List<Player> losers)
        {
            foreach(var winner in winners)
            {
                Card[] result = (Card[])winner.result[1];
                winner.ISetTieCondition(new int[]{result[2].value});
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}