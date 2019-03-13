using System;
using System.Collections.Generic;
using Backend.Objects;
using Backend.Functions;
namespace Backend.BreakTie
{
    public static class Pair
    {
        public static Object[] BreakTie(List<Player> winners, List<Player> losers)
        {
            foreach(var winner in winners)
            {
                int[] values = new int[4];
                int index = 0;
                int i = 0;
                bool run = true;
                while(run){
                    Card[] result = (Card[])winner.result[1];
                    int compare = result[i].value;
                    if(compare == result[i+1].value )
                    {
                        values[3] = result[i].value;
                        i += 2;
                        while(i < result.Length){
                            values[index] = compare;
                            index++;
                            i++;
                        }
                        run = false;
                    }
                    else{
                        values[index] = compare;
                        index++;
                    }
                    i++;
                }
                winner.ISetTieCondition(values);
            }
            return Tie.ParseTies(winners,losers);
        }
    }
}