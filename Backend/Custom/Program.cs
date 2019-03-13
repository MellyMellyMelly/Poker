using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Backend.Objects;
using Backend.Functions;
namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null, 0, 67000);
            Console.ReadLine();
        }
        private static void TimerCallback(Object h)
        {
            // System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            // System.Console.WriteLine($"{DateTime.Now.ToString()}");
            Deck deck = new Deck();
            int total = 5;
            while(total < 6)
            {
                Record[] recordKeeper = Database.Create(new Record[1326]);
                for(int i = 50; i < 51; i++)
                {
                    for(int j = i+1; j < 52; j++)
                    {
                        for(int count = 0; count < 100; count++)
                        {
                            int[] specificHand = new int[]{i,j};
                            int[] specificBoard = new int[]{};
                            Object[] overall = GamePlay.PlayPoker(total, deck, specificHand, specificBoard);
                            recordKeeper = Database.Update(recordKeeper,overall);
                            // System.Console.WriteLine($"----------------------------------------------------------------------------- {DateTime.Now.ToString()}");
                        }
                    }
                }
                total++;
            }
            System.Console.WriteLine($"{DateTime.Now.ToString()}");
            // System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            GC.Collect();
        }
    }
}