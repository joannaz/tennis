using System;
using ExtensibleTennis.Base;

namespace ExtensibleTennis.Tennis
{
    public class TennisGame : IGame
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private bool _gameCompleted;
        private readonly Random _rnd = new Random();

        public TennisGame(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

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

        public void Reset()
        {
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

        public void Score(IPlayer player1, IPlayer player2)
        {
            throw new NotImplementedException();
        }
    }
}
