using System;
using System.Collections.Generic;
using System.Linq;
namespace HandLanding.Objects
{
    public class Record
    {
        public string name { get; }
        public int[] resultSeek { get; }
        public int Wins;
        public int Games;
        public int FavorableOne;
        public int FavorableOneWins;
        public int FavorableTwo;
        public int FavorableTwoWins;
        public Record(int[] target)
        {
            name = "one";
            resultSeek = target;
            Wins = 0;
            Games = 0;
            FavorableOne = 0;
            FavorableOneWins = 0;
            FavorableTwo = 0;
            FavorableTwoWins = 0;
            // System.Console.WriteLine(handID);
        }
        public void ScoreBoard()
        {
            System.Console.WriteLine("*****************************************************************************");
            // SeekingResult();
            System.Console.WriteLine($"PLAYER: {name}, GAMES: {Games}, WINS: {Wins}, FAVORABLE WINS: {FavorableOneWins+FavorableTwoWins}");
            ResultsPrint();
            System.Console.WriteLine("*****************************************************************************");
        }
        private void SeekingResult()
        {
            if(resultSeek.Length == 1)
            {
                System.Console.WriteLine($"THE SPECIFIC RESULT WE ARE LOOKING FOR IS A {SpecificResult(resultSeek[0])}");
            }
            else
            {
                System.Console.WriteLine($"THE SPECIFIC RESULTS WE ARE LOOKING FOR ARE A {SpecificResult(resultSeek[0])} OR A {SpecificResult(resultSeek[1])}");
            }
        }
        private void ResultsPrint()
        {
            System.Console.WriteLine($"FAVORABLE HANDS: {FavorableOne+FavorableTwo}");
            System.Console.WriteLine($"{SpecificResult(resultSeek[0]).ToUpper()}: {FavorableOne} WINS: {FavorableOneWins}");
            if(resultSeek.Length > 1)
            {
                System.Console.WriteLine($"{SpecificResult(resultSeek[1]).ToUpper()}: {FavorableTwo} WINS: {FavorableTwoWins}");
            }
        }
        private string SpecificResult(int result)
        {
            string hand = "";
            if(result == 0){
                hand = "high card";
            }
            else if(result == 4){
                hand = "pair";
            }
            else if(result == 8){
                hand = "two pair";
            }
            else if(result == 31){
                hand = "three of a kind";
            }
            else if(result == 32){
                hand = "straight";
            }
            else if(result == 33){
                hand = "flush";
            }
            else if(result == 35){
                hand = "full house";
            }
            else if(result == 287){
                hand = "four of a kind";
            }
            else{
                hand = "straight flush";
            }
            return hand;
        }
    }
}