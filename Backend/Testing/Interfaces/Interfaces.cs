using System;
using System.Collections.Generic;
using Base.Models;
namespace Base.Interfaces
{
    public interface IShowCard
    {
        void ShowCard();
    }
    public interface ISetTieCondition
    {
        void SetTieCondition(int[] hey);
    }
    public interface IRecordFunctions
    {
        void IncreaseWin();
        void IncreaseGames();
        void Update(List<HandData> all, int i);
    }
}