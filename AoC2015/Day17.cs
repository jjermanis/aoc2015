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
            Console.WriteLine($"Count with optimal usage: {OptimalCombinationCount(liters)}");
        }

        public int CombinationsCount(int target)
            => CombinationCount(target, 0);

        public int OptimalCombinationCount(int target)
        {
            var comboHist = new Dictionary<int, int>();
            BuildCombinationHistogram(target, 0, 0, comboHist);
            for (var n = 1; true; n++)
            {
                if (comboHist.ContainsKey(n))
                    return comboHist[n];
            }
        }

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

        private void BuildCombinationHistogram(
            int target, 
            int index, 
            int containersUsed,
            Dictionary<int, int> comboHist)
        {
            if (index >= _containers.Count)
                return;

            var curr = _containers[index];

            if (curr == target)
                IncComboHist(containersUsed+1);
            else if (curr < target)
                BuildCombinationHistogram(target - curr, index + 1, containersUsed+1, comboHist);

            BuildCombinationHistogram(target, index + 1, containersUsed, comboHist);


            void IncComboHist(int n)
            {
                if (comboHist.ContainsKey(n))
                    comboHist[n]++;
                else
                    comboHist[n] = 1;
            }
        }
    }
}
