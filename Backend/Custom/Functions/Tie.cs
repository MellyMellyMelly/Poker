using System;
using System.Collections.Generic;
using Backend.Objects;
using Backend.BreakTie;
namespace Backend.Functions
{
    public static class Tie {
        public static void PickBreaker(List<Player> winners, List<Player> losers, int result)
        {
            // Announcement(winners);
            Object[] overall = new Object[2];
            if(result == 0 || result == 33)
            {
                overall = HighCard.BreakTie(winners,losers);
            }
            else if(result == 4)
            {
                overall = Pair.BreakTie(winners,losers);
            }
            else if(result == 8)
            {
                overall = TwoPair.BreakTie(winners,losers);
            }
            else if(result == 31)
            {
                overall = ThreeOfKind.BreakTie(winners,losers);
            }
            else if(result == 32 || result == 288){
                overall = Straight.BreakTie(winners,losers);
            }
            else if(result == 35){
                overall = FullHouse.BreakTie(winners,losers);
            }
            else if(result == 287){
                overall = FourOfKind.BreakTie(winners,losers);
            }
        }
        public static Object[] ParseTies(List<Player> winners, List<Player> losers)
        {
            int[] max = winners[0].GetTieBreaker();
            Object[] WinLose = new Object[]{winners,losers};
            for(int j = 1; j < winners.Count; j++)
            {
                int[] compare = winners[j].GetTieBreaker();
                int last = compare.Length-1;
                if(compare[last] > max[last])
                {
                    j = RemoveWinners(winners,losers,j);
                    max = compare;
                }
                else if( compare[last] == max[last])
                {
                    j = Untangle(winners,losers,max,compare,j);
                }
                else {
                    losers.Add(winners[1]);
                    winners.Remove(winners[1]);
                    j = 0;
                }
            }
            return WinLose;
        }
        public static int Untangle(List<Player> winners, List<Player> losers, int[] max, int[] compare, int addPosition)
        {
            bool check = true;
            int position = compare.Length-2;
            while(position >= 0 && check)
            {
                if(compare[position] > max[position])
                {
                    addPosition = RemoveWinners(winners,losers,addPosition);
                    max = compare;
                    check = false;
                }
                else if(compare[position] == max[position])
                {
                    position--;
                }
                else
                {
                    losers.Add(winners[1]);
                    winners.Remove(winners[1]);
                    addPosition = 0;
                    check = false;
                }
            }
            return addPosition;
        }
        public static int RemoveWinners(List<Player> winners, List<Player> losers, int remove)
        {

            while(remove > 0)
            {
                losers.Add(winners[0]);
                winners.Remove(winners[0]);
                remove--;
            }
            return 0;
        }
        public static void Announcement(List<Player> winners, List<Player> losers)
        {
            System.Console.WriteLine("The Winners are");
            foreach(var player in winners)
            {
                System.Console.WriteLine(player.name);
            }
            System.Console.WriteLine("-----------------------------------------------------------------------------");
            System.Console.WriteLine("The Losers are");
            foreach(var player in losers)
            {
                System.Console.WriteLine(player.name);
            }
        }
        public static void Announcement(List<Player> winners)
        {
            System.Console.WriteLine("The Tiebreaker candidates are");
            foreach(var player in winners)
            {
                System.Console.WriteLine(player.name);
            }
            System.Console.WriteLine("-----------------------------------------------------------------------------");
        }
    }
}