using System;
using System.Collections.Generic;
using Base.Objects;
namespace Base.Functions
{
    public static class GamePlay
    {
        public static Object[] PlayPoker(int total, Deck deck, int[] specificHand)
        {
            // total represents the number of players in the game
            int[] everything = PreGame.PreDeal(deck, total, specificHand);
            everything = PreGame.SortAllNumbers(everything, total);
            return DetermineWinner(PreGame.CreatePlayers(everything, deck, total));
            // System.Console.WriteLine(everything.Length);
            // System.Console.WriteLine(deck.numbers.Count);
        }
        public static Object[] DetermineWinner(Player[] players)
        {
            List<Player> winners = new List<Player>();
            List<Player> losers = new List<Player>();
            int max = 0;
            for(int i = 0; i < players.Length; i++)
            {
                int result = (int)players[i].result[0];
                if (result > max)
                {
                    while(winners.Count>0)
                    {
                        losers.Add(winners[0]);
                        winners.Remove(winners[0]);
                    }
                    winners.Add(players[i]);
                    max = (int)players[i].result[0];
                }
                else if((int)players[i].result[0] == max)
                {
                    winners.Add(players[i]);
                }
                else{
                    losers.Add(players[i]);
                }
            }
            // System.Console.WriteLine("-----------------------------------------------------------------------------");
            if(winners.Count > 1)
            {
                Object[] overall = new Object[2];
                // System.Console.WriteLine("There was a TIEBREAKER");
                Tie.PickBreaker(winners, losers, max);
                // Tie.Announcement(winners,losers);
            }
            else {
                // Tie.Announcement(winners,losers);
            }
            return new Object[]{winners,losers};
        }
    }
}