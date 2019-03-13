using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using HandLanding.Objects;
using HandLanding.Functions;
namespace HandLanding
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null, 0, 37000);
            Console.ReadLine();
        }  
        private static void TimerCallback(Object h)
        {
            // System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            // System.Console.WriteLine($"{DateTime.Now.ToString()}");
            Deck deck = new Deck();
            int total = 2;
            while(total < 3)
            {
                int[] specificHand = new int[]{4,33};
                int[] specificBoard = new int[]{8,13,34};
                int[] target =  new int[]{4};
                Record recordKeeper = new Record(target);
                for(int count = 0; count < 250; count++)
                {
                    Object[] overall = GamePlay.PlayPoker(total, deck, specificHand, specificBoard);
                    recordKeeper = Database.Update(recordKeeper,overall);
                    // System.Console.WriteLine($"-----------------------------------------------------------------------------");
                }
                total++;
                recordKeeper.ScoreBoard();
            }
            System.Console.WriteLine($"{DateTime.Now.ToString()}");
            // System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            GC.Collect();
        }
    }
}