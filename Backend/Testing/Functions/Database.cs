using System;
using System.Collections.Generic;
using System.Linq;
using Base.Objects;
using Base.Models;
namespace Base.Functions
{
    public static class Database
    {
        internal static Record[] Create(Record[] record)
        {
            int count = 0;
            for(int i = 2; i < 14; i++)
            {
                for(int j = i+1; j < 15; j++)
                {
                    record[count] = new Suited(count+1,i,j);
                    count++;
                }
            }
            for(int i = 2; i < 15; i++)
            {
                for(int j = i; j < 15; j++)
                {
                    record[count] = new Offsuit(count+1,i,j);
                    count++;
                }
            }
            return record;
        }
        internal static Record[] Update(Record[] record, Object[] results, HandTotal survey)
        {
            List<Player> winners = (List<Player>)(results[0]);
            List<Player> losers = (List<Player>)(results[1]);
            List<int> hands = new List<int>();
            hands.Add((int)winners[0].result[0]);
            survey.games++;
            if(winners.Count > 1)
            {
                survey.splits++;
            }
            // System.Console.WriteLine("*****************************************************");
            foreach(Player winner in winners)
            {
                var handNum = Winning(winner, record);
                // System.Console.WriteLine($"{winner.name}  JAVY BAEZ {handNum.handID} GAMES WON {handNum.Wins} GAMES PLAYED {handNum.Games} SUITED {handNum.suited} card1 {handNum.Coordinates[0]} card2 {handNum.Coordinates[1]}");
            }
            // System.Console.WriteLine("*****************************************************");
            foreach(Player loser in losers)
            {
                int count = hands.Where(p => p == (int)loser.result[0]).ToList().Count;
                if(count == 0)
                {
                    hands.Add((int) loser.result[0]);
                }
                var handNum = Losing(loser, record);
                // System.Console.WriteLine($"{loser.name}  JOEY GALLO {handNum.handID} GAMES WON {handNum.Wins} GAMES PLAYED {handNum.Games} SUITED {handNum.suited} card1 {handNum.Coordinates[0]} card2 {handNum.Coordinates[1]}");
            }
            survey.Winning(hands[0]);
            for(int i=1; i < hands.Count; i++)
            {
                survey.Increment(hands[i]);
            }
            return record;
        }
        internal static Record Winning(Player winner, Record[] record)
        {
            Record handNum;
            if(winner.hand[0].suit != winner.hand[1].suit)
            {
                handNum = record.Where(i => i.Coordinates[0] == winner.hand[0].value).Where(o => o.Coordinates[1] == winner.hand[1].value).FirstOrDefault(p => p.suited == "false");
            }
            else
            {
                handNum = record.Where(i => i.Coordinates[0] == winner.hand[0].value).Where(o => o.Coordinates[1] == winner.hand[1].value).FirstOrDefault(p => p.suited == "true");
            }
            WinOrLose.WinIncrement(winner, handNum);
            handNum.IncreaseWin();
            return handNum;
        }
        internal static Record Losing(Player loser, Record[] record)
        {
            Record handNum;
            if(loser.hand[0].suit != loser.hand[1].suit)
            {
                handNum = record.Where(i => i.Coordinates[0] == loser.hand[0].value).Where(o => o.Coordinates[1] == loser.hand[1].value).FirstOrDefault(p => p.suited == "false");
            }
            else
            {
                handNum = record.Where(i => i.Coordinates[0] == loser.hand[0].value).Where(o => o.Coordinates[1] == loser.hand[1].value).FirstOrDefault(p => p.suited == "true");
            }
            WinOrLose.HandIncrement(loser, handNum);
            handNum.IncreaseGames();
            return handNum;
        }
    }
}