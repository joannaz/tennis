using System;
namespace ExtensibleTennis.Base
{
    public interface IPlayer
    {
        int Score { get; }

        string Name { get; }

        void IncrementScore();

        void DecreaseScore();
    }
}
