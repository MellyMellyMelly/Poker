using System;
using System.Collections.Generic;
using System.Linq;
using Base.Objects;
namespace Base.Functions
{
    public static class WinOrLose
    {
        internal static void HandIncrement(Player player, Record record)
        {
            switch((int) player.result[0])
            {
                case 0:
                    record.highcard++;
                    break;
                case 4:
                    record.pair++;
                    break;
                case 8:
                    record.twopair++;
                    break;
                case 31:
                    record.threekind++;
                    break;
                case 32:
                    record.straight++;
                    break;
                case 33:
                    record.flush++;
                    break;
                case 35:
                    record.fullhouse++;
                    break;
                case 287:
                    record.fourkind++;
                    break;
                default:
                    record.straightflush++;
                    break;
            }
        }
        internal static void WinIncrement(Player winner, Record record)
        {
            switch((int) winner.result[0])
            {
                case 0:
                    record.highcard++;
                    record.highcardWins++;
                    break;
                case 4:
                    record.pair++;
                    record.pairWins++;
                    break;
                case 8:
                    record.twopair++;
                    record.twopairWins++;
                    break;
                case 31:
                    record.threekind++;
                    record.threekindWins++;
                    break;
                case 32:
                    record.straight++;
                    record.straightWins++;
                    break;
                case 33:
                    record.flush++;
                    record.flushWins++;
                    break;
                case 35:
                    record.fullhouse++;
                    record.fullhouseWins++;
                    break;
                case 287:
                    record.fourkind++;
                    record.fourkindWins++;
                    break;
                default:
                    record.straightflush++;
                    record.straightflushWins++;
                    break;
            }
        }
    }
}