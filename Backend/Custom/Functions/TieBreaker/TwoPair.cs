using System;
using System.Collections.Generic;
using Backend.Objects;
using Backend.Functions;
namespace Backend.BreakTie
{
    public static class TwoPair
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
                int mover = 1;
                while(values.Count>1)
                {
                    if(values[index] == values[index+1])
                    {
                        hot[mover] = values[index];
                        values.Remove(values[index]);
                        values.Remove(values[index]);
                        mover++;
                    }
                    else
                    {
                        hot[0] = values[index];
                        index++;
                    }
                }
                winner.ISetTieCondition(hot);
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}