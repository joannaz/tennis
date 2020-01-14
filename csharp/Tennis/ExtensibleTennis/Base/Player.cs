using System;
namespace ExtensibleTennis.Base
{
    public abstract class Player : IPlayer
    {
        protected Player(string name = null)
        {
            Score = 0;
            if (string.IsNullOrEmpty(name))
            {
                Name = Helpers.GetName();
            }
            else
            {
                Name = name;
            }
        }

        public int Score { get; internal set; }

        public string Name { get; private set; }

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
