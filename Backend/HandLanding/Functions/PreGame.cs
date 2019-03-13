using System;
using System.Collections.Generic;
using HandLanding.Objects;
namespace HandLanding.Functions
{
    public static class PreGame
    {
        public static int[] PreDeal(Deck deck, int total, int[] specificHand, int[] specificBoard)
        {
            int count = 0;
            int[] everything = new int[2*total+5];
            int deckLength = 52;
            List<int> numList = CreateNumbers();
            while(count < specificHand.Length)
            {
                everything[count] = specificHand[count];numList.Remove(specificHand[count]);count++;deckLength--;
            }
            count = total*2;
            int index = 0;
            // System.Console.WriteLine($"THESE ARE THE COMMUNITY CARDS");
            // System.Console.WriteLine("PRESELECTED CARDS FIRST:");
            while(count< (total*2)+specificBoard.Length)
            {
                System.Console.WriteLine($"This card is the {deck.cards[specificBoard[index]].rank} of {deck.cards[specificBoard[index]].suit}");
                everything[count] = specificBoard[index];numList.Remove(specificBoard[index]);index++;count++;deckLength--;
            }
            // System.Console.WriteLine("NOW THE OTHER CARDS");
            count = specificHand.Length;
            Random rand = new Random();
            while(count < total*2)
            {
                int num = rand.Next(deckLength);everything[count] = numList[num];numList.Remove(numList[num]);count++;deckLength--;
            }
            count = (total*2)+specificBoard.Length;
            while(count < (total*2)+5)
            {
                int num = rand.Next(deckLength);everything[count] = numList[num];numList.Remove(numList[num]);count++;deckLength--;
            }
            return everything;
        }
        public static int[] SortAllNumbers(int[] everything, int total)
        {
            for(int i = 0; i < total*2; i = i+2)
            {
                if(everything[i] > everything[i+1])
                {
                    int temp = everything[i+1];
                    everything[i+1] = everything[i];
                    everything[i] = temp;
                    // System.Console.WriteLine("Bobby");
                }
            }
            for(int i = total*2; i < everything.Length-1; i++)
            {
                for(int j = i + 1; j < everything.Length; j++)
                {
                    if(everything[i] > everything[j])
                    {
                        int temp = everything[j];
                        everything[j] = everything[i];
                        everything[i] = temp;
                    }
                }
            }
            return everything;
        }
        public static Player[] CreatePlayers(int[] everything, Deck deck, int[] specificBoard, int total)
        {
            Player[] players = new Player[total];
            Board community = new Board(everything,deck,specificBoard);
            int i = 0;
            // System.Console.WriteLine("Baby Driver");
            string[] names = {"one","two","three","four","five","six","seven","eight","nine","ten","eleven","twelve"};
            for(int a = 0; a < players.Length; a++)
            {
                Card[] handArray = new Card[2]{deck.cards[everything[i]],deck.cards[everything[i+1]]};
                // System.Console.WriteLine(handArray[0].cardNum);
                // System.Console.WriteLine(names[a]);
                players[a] = new Player(names[a],handArray,community.hand);
                // System.Console.WriteLine("Ozzy");
                i += 2;
            }
            return players;
        }
        public static Card[] DealCards(Card[] left, Card[] right)
        {
            Card[] handArray = new Card[7];
            int leftIndex = 0;
            int rightIndex = 0;
            int count = 0;
            while(leftIndex < left.Length && rightIndex < right.Length)
            {
                if(left[leftIndex].cardNum > right[rightIndex].cardNum)
                {
                    handArray[count] = right[rightIndex];
                    // System.Console.WriteLine(handArray[count].cardNum);
                    count++;
                    rightIndex++;
                }
                else
                {
                    handArray[count] = left[leftIndex];
                    // System.Console.WriteLine(handArray[count].cardNum);
                    count++;
                    leftIndex++;
                }
            }
            if(rightIndex == right.Length)
            {
                handArray = FinishOff(left, handArray, leftIndex, count);
            }
            else
            {
                handArray = FinishOff(right, handArray, rightIndex, count);
            }
            return handArray;
        }
        public static Card[] FinishOff(Card[] original, Card[] handArray, int num, int count)
        {
            while(num < original.Length)
            {
                handArray[count] = original[num];
                // System.Console.WriteLine(handArray[count].cardNum);
                count++;
                num++;
            }
            return handArray;
        }
        public static List<int> CreateNumbers(){
            List<int> CreateNumbers = new List<int>();
            for(int i = 0; i < 52; i++){
                CreateNumbers.Add(i);
            }
            return CreateNumbers;
        }
    }
}