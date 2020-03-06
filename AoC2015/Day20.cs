using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day20 : DaySingleLineText, IDay
    {
        // The answer for 20-1 will have a lot of factors.  Assume that the first few prime
        // factor will be part of the answer
        private const int HOUSE_STEP = 2 * 2 * 3 * 5;

        private readonly int _limit;

        public Day20(string filename) : base(filename)
        {
            _limit = int.Parse(Data);
        }

        public Day20() : this("Day20.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"First house at {_limit} presents: {FirstHouseAtLimit()}");
            var visitCap = 50;
            Console.WriteLine($"First house, with {visitCap} visit cap per elf: {FirstHouseCappedVisits(visitCap)}");
        }

        public int FirstHouseAtLimit()
        {
            for (var house = HOUSE_STEP; true; house += HOUSE_STEP)
            {
                var curr = 0;
                foreach (var factor in Util.AllFactors(house))
                    curr += factor * 10;
                if (curr >= _limit)
                    return house;
            }
        }

        public int FirstHouseCappedVisits(int visitCap)
        {
            for (var house = HOUSE_STEP; true; house += HOUSE_STEP)
            {
                var curr = 0;
                foreach (var factor in Util.AllFactors(house))
                {
                    if (house / factor <= visitCap)
                        curr += factor * 11;
                }
                if (curr >= _limit)
                    return house;
            }
        }
    }
}
