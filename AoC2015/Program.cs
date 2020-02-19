using System;

namespace AoC2015
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = Environment.TickCount;

            new Day15().Do();

            Console.WriteLine($"Time: {Environment.TickCount - start} ms");
        }
    }
}
