using System;
using System.Collections.Generic;
using System.Linq;
using Base.Objects;
namespace Base.Functions
{
    public static class Database
    {
        public static Record[] Create(Record[] record)
        {
            int count = 0;
            for(var i = 0; i < 51; i++)
            {
                for(var j = i+1; j < 52; j++)
                {
                    record[count] = new Record(count+1,i,j);
                    count++;
                }
            }
            return record;
        }
        public static Record[] Update(Record[] record, Object[] results)
        {
            List<Player> winners = (List<Player>)(results[0]);
            List<Player> losers = (List<Player>)(results[1]);
            // System.Console.WriteLine("*****************************************************");
            foreach(var winner in winners)
            {
                var handNum = record.Where(i => i.Coordinates[0] == winner.hand[0].cardNum).FirstOrDefault(o => o.Coordinates[1] == winner.hand[1].cardNum);
                handNum.Games++;
                handNum.Wins++;
                // System.Console.WriteLine($"{winner.name}  JAVY BAEZ {handNum.handID} GAMES WON {handNum.Wins} GAMES PLAYED {handNum.Games}");
            }
            // System.Console.WriteLine("*****************************************************");
            foreach(var loser in losers)
            {
                var handNum = record.Where(i => i.Coordinates[0] == loser.hand[0].cardNum).FirstOrDefault(o => o.Coordinates[1] == loser.hand[1].cardNum);
                handNum.Games++;
                // System.Console.WriteLine($"{loser.name}  JOEY GALLO {handNum.handID} GAMES WON {handNum.Wins} GAMES PLAYED {handNum.Games}");
            }
            return record;
        }
    }
}