using System;
using System.Collections.Generic;
using HandLanding.Objects;
using HandLanding.Functions;
namespace HandLanding.BreakTie
{
    public static class ThreeOfKind
    {
        public static Object[] BreakTie(List<Player> winners, List<Player> losers)
        {
            foreach(var winner in winners)
            {
                List<int> values = new List<int>();
                Card[] result = (Card[])winner.result[1];
                foreach(var card in result)
                {
                    values.Add(card.value);
                }
                int[] hot = new int[3];
                int index = 0;
                while(values.Count>2)
                {
                    if(values[index] == values[index+2])
                    {
                        hot[2] = values[index];
                        values.Remove(values[index]);values.Remove(values[index]);values.Remove(values[index]);
                        hot[0] = values[0];
                        hot[1] = values[1];
                    }
                    else
                    {
                        index++;
                    }
                }
                winner.ISetTieCondition(hot);
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}