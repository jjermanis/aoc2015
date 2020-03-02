using System;
using System.Linq;

using LightGrid = System.Collections.Generic.HashSet<(int, int)>;

namespace AoC2015
{
    public class Day18 : DayMultiLineText, IDay
    {
        private const bool IS_ANIMATED = false;

        private readonly LightGrid _start;
        private readonly int _maxX;
        private readonly int _maxY;

        public Day18(string filename) : base(filename)
        {
            var raw = Data.ToList();
            _maxY = raw.Count;
            _maxX = raw[0].Length;
            _start = new LightGrid();
            for (var y = 0; y < raw.Count; y++)
            {
                var curr = raw[y];
                for (var x = 0; x < curr.Length; x++)
                    if (curr[x] == '#')
                        _start.Add((x, y));
            }
        }

        public Day18() : this("Day18.txt")
        {
        }

        public void Do()
        {
            var steps = 100;
            Console.WriteLine($"Lights on after {steps} steps: {LightsOnCountMultipleSteps(steps)}");
            Console.WriteLine($"Lights on, corners always on: {LightsOnCountMultipleSteps(steps, true)}");
        }

        public int LightsOnCountMultipleSteps(int n, bool isCornersOn=false)
            => LightsOnCount(RunMultipleSteps(n, isCornersOn));

        private int LightsOnCount(LightGrid grid)
            => grid.Count;

        private LightGrid RunMultipleSteps(int n, bool isCornersOn)
        {
            var curr = _start;
            if (isCornersOn)
                TurnOnCorners(curr);

            for (int i = 0; i < n; i++)
            {
                curr = RunStep(curr);
                if (isCornersOn)
                    TurnOnCorners(curr);
                if (IS_ANIMATED)
                    PrintGrid(curr);
            }
            return curr;
        }

        private void TurnOnCorners(LightGrid grid)
        {
            grid.Add((0, 0));
            grid.Add((0, _maxY - 1));
            grid.Add((_maxX - 1, 0));
            grid.Add((_maxX - 1, _maxY - 1));
        }

        private void PrintGrid(LightGrid curr)
        {
            Console.WriteLine("=====");
            for (var y = 0; y < _maxY; y++)
            {
                for (var x = 0; x < _maxX; x++)
                    Console.Write(curr.Contains((x, y)) ? '#' : '.');
                Console.WriteLine();
            }
        }

        private LightGrid RunStep(LightGrid curr)
        {
            var result = new LightGrid();
            for(var y = 0; y <_maxY; y++)
                for(var x = 0; x < _maxX; x++)
                {
                    var nc = NeighborCount(curr, x, y);
                    if (curr.Contains((x,y)))
                    {
                        if (nc == 2 || nc == 3)
                            result.Add((x, y));
                    }
                    else
                    {
                        if (nc == 3)
                            result.Add((x, y));
                    }
                }
            return result;
        }

        private int NeighborCount(LightGrid curr, int px, int py)
        {
            var result = 0;
            for (var y = py - 1; y <= py + 1; y++)
                for (var x = px - 1; x <= px + 1; x++)
                    if (px != x || py != y)
                        if (curr.Contains((x, y)))
                            result++;
            return result;
        }
    }
}
