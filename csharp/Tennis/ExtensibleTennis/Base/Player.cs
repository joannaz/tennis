using System;
namespace ExtensibleTennis.Base
{
    public abstract class Player : IPlayer
    {
        public Player(int pointsToWin)
        {
            Name = Helpers.GetName();
            Score = 0;
            PointsAheadToWin = pointsToWin;
        }

        public int Score { internal get; set; }

        public string Name { get; private set; }

        public int PointsAheadToWin { get; private set; }

        public void IncrementScore()
        {
            Score = Score + 1;
        }

        public void DecreaseScore()
        {
            Score = Score - 1;
        }
    }
}
