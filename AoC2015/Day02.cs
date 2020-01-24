using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2015
{
    public class Day02 : DayMultiLineText, IDay
    {
        public Day02(string filename) : base(filename)
        {
        }
        public Day02() : base("Day02.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Wrapping paper needed: {WrappingPaper()}");
            Console.WriteLine($"Ribbon needed: {Ribbon()}");
        }

        public int WrappingPaper()
        {
            var total = 0;
            foreach (var present in SortedDimensions())
            {
                var a = present[0];
                var b = present[1];
                var c = present[2];
                total += 2 * (a * b + a * c + b * c) + a * b;
            }
            return total;
        }

        public int Ribbon()
        {
            var total = 0;
            foreach (var present in SortedDimensions())
            {
                var a = present[0];
                var b = present[1];
                var c = present[2];

                total += (2 * a + 2 * b) + (a * b * c);
            }
            return total;
        }

        private IEnumerable<int[]> SortedDimensions()
        {
            foreach (var present in Data)
            {
                var v = present.Split('x').Select(n => int.Parse(n)).ToArray();
                Array.Sort(v);
                yield return v;
            }
        }
    }
}
