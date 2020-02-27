using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day17 : DayMultiLineText, IDay
    {
        private readonly List<int> _containers;

        public Day17(string filename) : base(filename)
        {
            _containers = Data.Select(d => int.Parse(d)).ToList();
        }

        public Day17() : this("Day17.txt")
        {
        }

        public void Do()
        {
            var liters = 150;
            Console.WriteLine($"Combinations: {CombinationsCount(liters)}");
        }

        public int CombinationsCount(int target)
            => CombinationCount(target, 0);
     
        private int CombinationCount(int target, int index)
        {
            if (index >= _containers.Count)
                return 0;

            var curr = _containers[index];

            var countWithCurr = 0;
            if (curr == target)
                countWithCurr = 1;
            else if (curr < target)
                countWithCurr = CombinationCount(target - curr, index + 1);

            var countWithoutCurr = CombinationCount(target, index + 1);

            return countWithCurr + countWithoutCurr;
        }
    }
}
