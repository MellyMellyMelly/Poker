using System;
using System.Collections.Generic;
using System.Reflection;
using Base.Models;
using Base.Interfaces;
namespace Base.Objects
{
    internal abstract class Record : IRecordFunctions
    {
        public int handID { get; }
        public int[] Coordinates { get; }
        protected string _suited;
        public string suited { 
            get {return _suited;}
        }
        private int _wins;
        public int wins { 
            get {return _wins;} 
            }
        private int _games;
        public int games {
            get {return _games;}
        }
        public int highcard { get; set; }
        public int highcardWins { get; set; }
        public int pair { get; set; }
        public int pairWins { get; set; }
        public int twopair { get; set; }
        public int twopairWins { get; set; }
        public int threekind { get; set; }
        public int threekindWins { get; set; }
        public int straight { get; set; }
        public int straightWins { get; set; }
        public int flush { get; set; }
        public int flushWins { get; set; }
        public int fullhouse { get; set; }
        public int fullhouseWins { get; set; }
        public int fourkind { get; set; }
        public int fourkindWins { get; set; }
        public int straightflush { get; set; }
        public int straightflushWins { get; set; }
        public Record(int count, int left, int right)
        {
            Type type = typeof(Record);
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                object temp = field.GetValue(this);
                if (temp is int)
                {
                    temp = 0;
                }
            }
            handID = count;
            Coordinates = new int[2]{left,right};
        }
        public void Update(List<HandData> all, int i)
        {
            PropertyCopier<HandData, Record>.UpdateRecord(all[i], this);
            UpdateWinsGames(all[i].wins, all[i].games);
        }
        public void IncreaseWin()
        {
            _wins++;
            IncreaseGames();
        }
        private void UpdateWinsGames(int moreWins, int moreGames)
        {
            _wins += moreWins;
            _games += moreGames;
        }
        public void IncreaseGames()
        {
            _games++;
        }
    }
}