using System;
using System.ComponentModel;
using ExtensibleTennis.Base;

namespace ExtensibleTennis.Tennis
{
    public class TennisGame : IGame
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private bool _gameCompleted;
        private readonly Random _rnd = new Random();

        public TennisGame()
        {
            _player1 = new TennisPlayer();
            _player2 = new TennisPlayer();
        }

        public TennisGame(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
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
            _gameCompleted = false;
            _player1 = new TennisPlayer();
            _player2 = new TennisPlayer();
        }

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

        public void Score(IPlayer winner, IPlayer loser)
        {
            var winnerCurrentScore = winner.Score.ConvertIntToTennisScore();
            var loserCurrentScore = loser.Score.ConvertIntToTennisScore();

            switch (winnerCurrentScore)
            {
                case TennisScore.Love:
                case TennisScore.Fifteen:
                case TennisScore.Thirty:
                case TennisScore.Advantage:
                    winner.IncrementScore();
                    PrintScore(winner, loser);
                    break;
                case TennisScore.Forty:
                    if (loserCurrentScore <= TennisScore.Thirty)
                    {
                        // Other player has either 0, 15, 30 therefore, 2 point lead as we are adv. This player has won the game.
                        // Increase score twice as we're setting score to game, not advantage.
                        winner.SetScoreToGame();
                    }
                    else if (loserCurrentScore.Equals(TennisScore.Forty))
                    {
                        // Increase point to advantage.
                        winner.IncrementScore();
                    }
                    else if (loserCurrentScore.Equals(TennisScore.Advantage))
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

        private void PrintScore(IPlayer winner, IPlayer loser)
        {
            var winnerScore = winner.Score.ConvertIntToTennisScore();
            var loserScore = loser.Score.ConvertIntToTennisScore();

            if (winnerScore.Equals(TennisScore.Game))
            {
                Console.WriteLine($"{winner.Name} has won the game! Total score: {winnerScore}:{loserScore}!");
                _gameCompleted = true;
                return;
            }

            if (winnerScore.Equals(loser.Score))
            {
                if (winnerScore.Equals(TennisScore.Forty))
                {
                    Console.WriteLine($"{winner.Name} has won the point! Score: Deuce");
                }
                else
                {
                    Console.WriteLine($"{winner.Name} has won the point! Score: {winnerScore}: all!");
                }

                return;
            }
            Console.WriteLine($"{winner.Name} has won the point! Score: {winnerScore}:{loserScore}!");
            return;
        }
    }
}
