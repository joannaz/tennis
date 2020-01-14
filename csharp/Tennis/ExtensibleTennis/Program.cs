using System;
using ExtensibleTennis.Base;
using ExtensibleTennis.Tennis;

namespace ExtensibleTennis
{
    class Program
    {
        private static readonly IGame TennisGame = new TennisGame();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game of tennis.");
            Console.WriteLine("Type in 'y' to play.");
            var letter = Char.ToLower(Console.ReadKey().KeyChar);
            if (letter == 'y')
            {
                Play();
            }
        }

        private static void Play()
        {
            TennisGame.Play();
            Console.WriteLine("Type in 'y' to play again.");
            var letter = Char.ToLower(Console.ReadKey().KeyChar);
            if (letter == 'y')
            {
                TennisGame.Reset();
                Play();
            }
        }
    }
}
