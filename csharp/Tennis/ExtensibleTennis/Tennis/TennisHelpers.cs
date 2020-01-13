using System;
using System.Collections.Generic;
using ExtensibleTennis.Tennis;

namespace ExtensibleTennis
{
    /// <summary>
    /// Helper class for the tennis game.
    /// </summary>
    public static class TennisHelpers
    {
        public static TennisScore ConvertIntToTennisScore(this int score)
        {
            if(score >= 0 && score <= 5)
            {
                return (TennisScore)score;
            }

            throw new IndexOutOfRangeException("Tennis score is not between 0 and 5");
        }

        public static bool CheckScore(this int score)
        {
            if (score >= 0 && score <= 5)
            {
                return true;
            }

            throw new IndexOutOfRangeException("Tennis score is not between 0 and 5");
        }
    }
}