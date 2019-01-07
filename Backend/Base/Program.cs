using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Base.Models;
using Base.Factory;
using Base.Objects;
using Base.Functions;
namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null, 0, 600000);
            Console.ReadLine();
        }
        private static void TimerCallback(Object h)
        {
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine($"{DateTime.Now.ToString()}");
            Deck deck = new Deck();
            int total = 2;
            while(total < 3)
            {
                Record[] recordKeeper = Database.Create(new Record[169]);
                HandTotal survey = new HandTotal();
                for(int i = 0; i < 51; i++)
                {
                    for(int j = i+1; j < 52; j++)
                    {
                        for(int count = 0; count < 100; count++)
                        {
                            int[] specificHand = new int[]{i,j};
                            Object[] overall = GamePlay.PlayPoker(total, deck, specificHand);
                            recordKeeper = Database.Update(recordKeeper,overall, survey);
                        }
                    }
                }
                HandFactory blog = new HandFactory(recordKeeper, total-2);
                TotalFactory goals = new TotalFactory(survey, total);
                total++;
            }
            System.Console.WriteLine($"{DateTime.Now.ToString()}");
            System.Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            GC.Collect();
        }
    }
}