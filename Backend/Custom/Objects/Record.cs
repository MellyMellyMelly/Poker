using System;
using System.Collections.Generic;
using System.Linq;
namespace Backend.Objects
{
    public class Record
    {
        public int handID { get; }
        public int[] Coordinates { get; }
        public int Wins;
        public int Games;
        public Record(int count, int left, int right)
        {
            Coordinates = new int[2]{left,right};
            handID = count;
            Wins = 0;
            Games = 0;
            // System.Console.WriteLine(handID);
        }
    }
}