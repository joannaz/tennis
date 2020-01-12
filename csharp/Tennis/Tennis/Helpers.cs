using System;
using System.Collections.Generic;

namespace Tennis
{
    public static class Helpers
    {
        private static readonly List<string> FirstNames = new List<string> {"Jessica", "Mike", "Jordan", "James", "John"};
        private static readonly List<string> LastNames = new List<string> { "Brown", "Andrews", "Doe", "Richards" };
        private static readonly Random Rnd = new Random();

        public static string GetName()
        {
            var firstNameIndex = Rnd.Next(FirstNames.Count);
            var lastNameIndex = Rnd.Next(LastNames.Count);

            return $"{FirstNames[firstNameIndex]} {LastNames[lastNameIndex]}";
        }
    }
}