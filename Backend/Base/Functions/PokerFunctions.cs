using System;
using Base.Objects;
namespace Base.Functions
{
    public static class PokerFunctions
    {
        public static Object[] Combinatorics(Card[] player)
        {
            Object[] max = new Object[2]{0,null};
            for(int i = 0; i < player.Length-1; i++)
            {
                for(int j = i+1; j < player.Length; j++){
                    Card[] hot = new Card[5];
                    int k = 0;
                    int count = 0;
                    while(k < 7)
                    {
                        if(k == j || k == i){}
                        else{
                            hot[count] = player[k];
                            count++;
                        }
                        k++;
                    }
                    Object[] result = DetermineHand(hot);
                    if((int)result[0] > (int)max[0]){
                        max = result;
                    }
                    else if((int)result[0] == (int)max[0]){
                        if(max[1] == null)
                        {
                            max[1] = result[1];
                        }
                        else if(((Card[])result[1])[4].value > ((Card[])max[1])[4].value)
                        {
                            max = result;
                        }
                        else if(((Card[])result[1])[4].value == ((Card[])max[1])[4].value)
                        {
                            if(((Card[])result[1])[0].value > ((Card[])max[1])[0].value)
                            {
                                max = result;
                            }
                        }
                    }
                }
            }
            // switch((int)max[0])
            // {
            //     case 0:
            //         System.Console.WriteLine("High Card");
            //         break;
            //     case 4:
            //         System.Console.WriteLine("Pair");
            //         break;
            //     case 8:
            //         System.Console.WriteLine("Two Pair");
            //         break;
            //     case 31:
            //         System.Console.WriteLine("Three of a Kind");
            //         break;
            //     case 32:
            //         System.Console.WriteLine("Straight");
            //         break;
            //     case 33:
            //         System.Console.WriteLine("Flush");
            //         break;
            //     case 35:
            //         System.Console.WriteLine("Full House");
            //         break;
            //     case 287:
            //         System.Console.WriteLine("Four of a Kind");
            //         break;
            //     default:
            //         System.Console.WriteLine("Straight Flush");
            //         break;
            // }
            return max;
        }
        public static Object[] DetermineHand(Card[] five)
        {
            Object[] result = HandAnalyzer.CommonRank(five);
            if(HandAnalyzer.Straight(five))
            {
                result[0] = 32;
            }
            if(HandAnalyzer.Flush(five))
            {
                if((int)result[0] == 32){
                    result[0] = 288;
                }
                else {
                    result[0] = 33;
                }
            }
            return result;
        }
    }
}