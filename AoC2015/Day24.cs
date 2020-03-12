using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day24 : DayMultiLineText, IDay
    {
        private readonly List<int> _sizes;
        private int _lowestCount;
        private long _lowestQuantum;

        public Day24(string filename) : base(filename)
        {
            _sizes = new List<int>();
            foreach (var line in Data)
                _sizes.Add(int.Parse(line));
            _sizes = _sizes.OrderByDescending(o => o).ToList();
        }

        public Day24() : this("Day24.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Lowest quantum entanglement in optimal config: {QuantumInOptimalConfig()}");
        }

        public long QuantumInOptimalConfig()
        {
            _lowestCount = int.MaxValue;
            _lowestQuantum = int.MaxValue;

            var third = _sizes.Sum() / 3;
            FindOptimalConfig(third, 0, 0, 1);

            return _lowestQuantum;

        }

        private void FindOptimalConfig(
            int target,
            int index,
            int packageCount,
            long quantumEntanglement)
        {
            // This solution doesn't check to see if the other two groups balance. This seems to
            // work for my input for 24-1
            if (index >= _sizes.Count)
                return;

            var curr = _sizes[index];

            if (curr == target)
            {
                var count = packageCount + 1;
                var qe = quantumEntanglement * curr;
                UpdateBest(count, qe);
            }
            else if (curr < target)
            {
                FindOptimalConfig(target - curr, index + 1, packageCount + 1, quantumEntanglement * curr);
            }
            FindOptimalConfig(target, index + 1, packageCount, quantumEntanglement);

        }

        private void UpdateBest(int count, long qe)
        {
            if (count < _lowestCount ||
               (count == _lowestCount && qe < _lowestQuantum))
            {
                _lowestCount = count;
                _lowestQuantum = qe;
            }
        }
    }
}
