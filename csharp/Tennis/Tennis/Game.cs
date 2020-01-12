using System;
using System.ComponentModel;

namespace Tennis
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private readonly Random _rnd = new Random();
        private bool _gameCompleted;

        public Game()
        {
            Reset();
        }

        public void Play()
        {
            Console.WriteLine();
            Console.WriteLine($"Game has started. Players are {_player1.Name} and {_player2.Name}.");
            while (!_gameCompleted)
            {
                UpdateRandomWinner();
                System.Threading.Thread.Sleep(500);
            }
        }

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
            //todo: player who wins serves. do I need this?
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
            _gameCompleted = true;
        }

        private bool SameScoreCheck(Player winner, Player loser)
        {
            if (winner.Score.Equals(loser.Score))
            {
                Console.WriteLine($"{winner.Name} has won the point! Score: {winner.Score}: all!");
                return true;
            }
            Console.WriteLine($"{winner.Name} has won the point! Score: {winner.Score}:{loser.Score}!");
            return false;
        }
    }
}