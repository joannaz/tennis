namespace Tennis
{
    public class Player
    {
        /// <summary>
        /// The current score of the player.
        /// </summary>
        public Score Score { get; private set; }

        /// <summary>
        /// The name of the player.
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
            Score = Score + 1;
        }

        /// <summary>
        /// Decreases this player's score by 1.
        /// </summary>
        public void DecreaseScore()
        {
            Score = Score - 1;
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