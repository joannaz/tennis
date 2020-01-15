namespace Tennis
{
    public class Player
    {
        /// <summary>
        /// Gets the current score of the player.
        /// </summary>
        public Score Score { get; private set; }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public Player(string name)
        {
            Name = name;
            Score = Score.Love;
        }

        /// <summary>
        /// Increases this player's score by 1.
        /// </summary>
        public void IncreaseScore()
        {
            Score++;
        }

        /// <summary>
        /// Set this player's score to game. They have won.
        /// </summary>
        public void SetScoreToGame()
        {
            Score = Score.Game;
        }

        /// <summary>
        /// Decreases this player's score by 1.
        /// </summary>
        public void DecreaseScore()
        {
            Score--;
        }

        /// <summary>
        /// Reset this player's score to 0.
        /// </summary>
        public void ResetScore()
        {
            Score = Score.Love;
        }
    }
}