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
            // if((int)max[0] == 0){
            //     System.Console.WriteLine("High Card");
            // }
            // else if((int)max[0] == 4){
            //     System.Console.WriteLine("Pair");
            // }
            // else if((int)max[0] == 8){
            //     System.Console.WriteLine("Two Pair");
            // }
            // else if((int)max[0] == 31){
            //     System.Console.WriteLine("Three of a Kind");
            // }
            // else if((int)max[0] == 32){
            //     System.Console.WriteLine("Straight");
            // }
            // else if((int)max[0] == 33){
            //     System.Console.WriteLine("Flush");
            // }
            // else if((int)max[0] == 35){
            //     System.Console.WriteLine("Full House");
            // }
            // else if((int)max[0] == 287){
            //     System.Console.WriteLine("Four of a Kind");
            // }
            // else{
            //     System.Console.WriteLine("Straight Flush");
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