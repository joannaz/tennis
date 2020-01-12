using System;
using System.Collections.Generic;

namespace Tennis
{
    /// <summary>
    /// Helper class for the tennis game.
    /// </summary>
    public static class Helpers
    {
        private static readonly List<string> FirstNames = new List<string> {"Jessica", "Mike", "Jordan", "James", "John", "David", "Daniel", "Sarah", "Ella", "Susanna", "Enya"};
        private static readonly List<string> LastNames = new List<string> { "Brown", "Andrews", "Doe", "Richards", "Williams" };
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Gets a random name.
        /// </summary>
        /// <returns>A random firstname lastname.</returns>
        public static string GetName()
        {
            var firstNameIndex = Rnd.Next(FirstNames.Count);
            var lastNameIndex = Rnd.Next(LastNames.Count);

            return $"{FirstNames[firstNameIndex]} {LastNames[lastNameIndex]}";
        }
    }
}