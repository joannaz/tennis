using System;
using System.Resources;

namespace Tennis
{
    class Program
    {
        private static readonly Game TennisGame = new Game();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of tennis.");
            Console.WriteLine("Play? Y / N");
            var letter = Char.ToLower(Console.ReadKey().KeyChar);
            if (letter == 'y')
            {
                Play();
            }
        }

        private static void Play()
        {
            TennisGame.Play();
            Console.WriteLine("Play again? Y/N");
            var letter = Char.ToLower(Console.ReadKey().KeyChar);
            if (letter == 'y')
            {
                TennisGame.Reset();
                Play();
            }
        }
    }
}
