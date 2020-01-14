using System;
using ExtensibleTennis.Base;

namespace ExtensibleTennis.Tennis
{
    public class TennisPlayer : Player, IPlayer
    {
        public TennisPlayer(string name = null)
            :base(name)
        {
        }

        /// <summary>
        /// Initializes a new instances of the <see cref="TennisPlayer"/>
        /// class. todo: Can make this internal as this is only used for
        /// unit testing.
        /// </summary>
        /// <param name="score">Player score.</param>
        /// <param name="name">Name of the player.</param>
        public TennisPlayer(int score, string name = null)
            : base(name)
        {
            Score = score;
            Score.CheckScore();
        }

        public TennisScore GetScore()
        {
            return Score.ConvertIntToTennisScore();
        }

        public new void IncrementScore()
        {
            Score = Score + 1;
            Score.CheckScore();
        }

        public new void DecreaseScore()
        {
            Score = Score - 1;
            Score.CheckScore();
        }
    }
}