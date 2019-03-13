using System;
using System.Collections.Generic;
using Base.Models;
namespace Base.Interfaces
{
    internal interface IShowCard
    {
        void ShowCard();
    }
    internal interface ISetTieCondition
    {
        void SetTieCondition(int[] hey);
    }
    internal interface IRecordFunctions
    {
        void IncreaseWin();
        void IncreaseGames();
        void Update(List<HandData> all, int i);
    }
}