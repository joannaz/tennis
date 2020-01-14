using System;
using System.ComponentModel;

namespace Tennis
{
    /// <summary>
    /// The main class of the game where all objects are manipulated. Call
    /// <see cref="Play"/> to start the game.
    /// </summary>
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private readonly Random _rnd = new Random();
        private bool _gameCompleted;

        /// <summary>
        /// Start the tennis game.
        /// </summary>
        public void Play()
        {
            Reset();
            Console.WriteLine();
            Console.WriteLine($"Game has started. Players are {_player1.Name} and {_player2.Name}.");
            while (!_gameCompleted)
            {
                UpdateRandomWinner();
                System.Threading.Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Reset the game.
        /// </summary>
        public void Reset()
        {
            _player1 = new Player(Helpers.GetName());
            _player2 = new Player(Helpers.GetName());
            _gameCompleted = false;
        }

        /// <summary>
        /// Selects a random player to win a game, and calls
        /// <see cref="Game.Score(Player,Player)"/> to
        /// calculate the score.
        /// </summary>
        /// <returns></returns>
        private void UpdateRandomWinner()
        {
            var player = _rnd.Next(2);

            if (player == 0)
            {
                Score(_player1, _player2);
                return;
            }

            Score(_player2, _player1);
        }

        /// <summary>
        /// Calculates the score of the players.
        /// </summary>
        /// <param name="winner">The winner of the point.</param>
        /// <param name="loser">The loser of the point.</param>
        private void Score(Player winner, Player loser)
        {
            switch (winner.Score)
            {
                case Tennis.Score.Love:
                case Tennis.Score.Fifteen:
                case Tennis.Score.Thirty:
                case Tennis.Score.Advantage:
                    winner.IncreaseScore();
                    PrintScore(winner, loser);
                    break;
                case Tennis.Score.Forty:
                    if (loser.Score <= Tennis.Score.Thirty)
                    {
                        // Other player has either 0, 15, 30 therefore, 2 point lead as we are adv. This player has won the game.
                        // Increase score twice as we're setting score to game, not advantage.
                        winner.SetScoreToGame();
                    }
                    else if (loser.Score.Equals(Tennis.Score.Forty))
                    {
                        // Increase point to advantage.
                        winner.IncreaseScore();
                    }
                    else if (loser.Score.Equals(Tennis.Score.Advantage))
                    {
                        // Back to deuce.
                        loser.DecreaseScore();
                    }
                    PrintScore(winner, loser);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Invalid enum arguement.");
            }
        }

        /// <summary>
        /// Prints out the score dependent on if both parties have the same score.
        /// </summary>
        /// <param name="winner">The winner of the point.</param>
        /// <param name="loser">The loser of the point.</param>
        /// <returns></returns>
        private void PrintScore(Player winner, Player loser)
        {
            if (winner.Score.Equals(Tennis.Score.Game))
            {
                Console.WriteLine($"{winner.Name} has won the game! Total score: {winner.Score}:{loser.Score}!");
                _gameCompleted = true;
                return;
            }

            if (winner.Score.Equals(loser.Score))
            {
                if (winner.Score.Equals(Tennis.Score.Forty))
                {
                    Console.WriteLine($"{winner.Name} has won the point! Score: Deuce");
                }
                else
                {
                    Console.WriteLine($"{winner.Name} has won the point! Score: {winner.Score}: all!");
                }

                return;
            }
            Console.WriteLine($"{winner.Name} has won the point! Score: {winner.Score}:{loser.Score}!");
            return;
        }
    }
}