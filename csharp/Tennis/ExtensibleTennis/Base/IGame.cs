using System;
namespace ExtensibleTennis.Base
{
    public interface IGame
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        void Play();

        /// <summary>
        /// Resets the game.
        /// </summary>
        void Reset();

        /// <summary>
        /// Calculates the score.
        /// </summary>
        /// <param name="winner">The winner of the point.</param>
        /// <param name="loser">The loser of the point.</param>
        void Score(IPlayer winner, IPlayer loser);
    }
}
