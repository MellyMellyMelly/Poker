using System;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
namespace Base.Models
{
    public class HandTotal
    {
        public int roundSize { get; set; }
        public int splits { get; set; }
        public int games { get; set; }
        public int highcard { get; set;}
        public int highcardWins { get; set;}
        public int pair { get; set;}
        public int pairWins { get; set;}
        public int twopair { get; set;}
        public int twopairWins { get; set;}
        public int threekind { get; set;}
        public int threekindWins { get; set;}
        public int straight { get; set;}
        public int straightWins { get; set;}
        public int flush { get; set;}
        public int flushWins { get; set;}
        public int fullhouse { get; set;}
        public int fullhouseWins { get; set;}
        public int fourkind { get; set;}
        public int fourkindWins { get; set;}
        public int straightflush { get; set;}
        public int straightflushWins { get; set;}
        public HandTotal()
        {
            Type type = typeof(HandTotal);
            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                int temp = (int) field.GetValue(this);
                temp = 0;
            };
        }
        public void Increment(int result)
        {
            switch(result)
            {
                case 0:
                    highcard++;
                    break;
                case 4:
                    pair++;
                    break;
                case 8:
                    twopair++;
                    break;
                case 31:
                    threekind++;
                    break;
                case 32:
                    straight++;
                    break;
                case 33:
                    flush++;
                    break;
                case 35:
                    fullhouse++;
                    break;
                case 287:
                    fourkind++;
                    break;
                default:
                    straightflush++;
                    break;
            }
        }
        public void Winning(int result)
        {
            switch(result)
            {
                case 0:
                    highcard++;
                    highcardWins++;
                    break;
                case 4:
                    pair++;
                    pairWins++;
                    break;
                case 8:
                    twopair++;
                    twopairWins++;
                    break;
                case 31:
                    threekind++;
                    threekindWins++;
                    break;
                case 32:
                    straight++;
                    straightWins++;
                    break;
                case 33:
                    flush++;
                    flushWins++;
                    break;
                case 35:
                    fullhouse++;
                    fullhouseWins++;
                    break;
                case 287:
                    fourkind++;
                    fourkindWins++;
                    break;
                default:
                    straightflush++;
                    straightflushWins++;
                    break;
            }
        }
    }
}