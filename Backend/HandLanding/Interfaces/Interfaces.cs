using System;
namespace HandLanding.Interfaces
{
    public interface IShowCard
    {
        void IShowCard();
    }
    public interface IShowBoard
    {
        void IShowBoard(int[] specificBoard);
    }
    public interface ISetTieCondition
    {
        void ISetTieCondition(int[] hey);
    }
}