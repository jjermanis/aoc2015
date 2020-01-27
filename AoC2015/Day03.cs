using System;
using System.Collections.Generic;

namespace AoC2015
{
    public class Day03 : DaySingleLineText, IDay
    {
        private readonly IReadOnlyDictionary<char, Point> DIRECTIONS_MAP =
            new Dictionary<char, Point>
        {
            { '^', new Point(0, -1) },
            { '>', new Point(1, 0) },
            { 'v', new Point(0, 1) },
            { '<', new Point(-1, 0) },
        };

        public Day03(string filename) : base(filename)
        {
        }
        public Day03() : base("Day03.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Houses visited: {HousesVisitedCount()}");
            Console.WriteLine($"Houses visited with two santas: {HousesVisitedByTwoCount()}");
        }

        public int HousesVisitedCount()
        {
            var housesVisited = new HashSet<Point>();

            Point santaLoc = new Point(0, 0);
            housesVisited.Add(santaLoc);
            foreach (var move in Data)
            {
                santaLoc += DIRECTIONS_MAP[move];
                housesVisited.Add(santaLoc);
            }
            return housesVisited.Count;
        }

        public int HousesVisitedByTwoCount()
        {
            var housesVisited = new HashSet<Point>();

            Point santaLoc = new Point(0, 0);
            Point roboLoc = new Point(0, 0);

            housesVisited.Add(santaLoc);
            for (int i=0; i < Data.Length; i++)
            {
                var move = Data[i];
                if (i % 2 == 0)
                {
                    santaLoc += DIRECTIONS_MAP[move];
                    housesVisited.Add(santaLoc);
                }
                else
                {
                    roboLoc += DIRECTIONS_MAP[move];
                    housesVisited.Add(roboLoc);
                }
            }
            return housesVisited.Count;
        }
    }
}
