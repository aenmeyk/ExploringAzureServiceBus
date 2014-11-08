using System;

namespace Common
{
    public static class ColorGenerator
    {
        private static readonly Random _random = new Random();

        public static ConsoleColor GetRandomColor()
        {
            return _random.NextDouble() > 0.5
                ? ConsoleColor.Yellow
                : ConsoleColor.Cyan;
        }
    }
}