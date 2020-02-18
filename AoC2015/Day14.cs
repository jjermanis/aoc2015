using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day14 : DayMultiLineText, IDay
    {
        public Day14(string filename) : base(filename)
        {
        }

        public Day14() : this("Day14.txt")
        {
        }

        public void Do()
        {
            var time = 2503;
            Console.WriteLine($"Race winner distance: {RaceWinnerDistance(time)}");
        }

        public int RaceWinnerDistance(int seconds)
        {
            var reindeer = GetReindeer().ToList();
            for (int t=0; t < seconds; t++)
            {
                foreach (var deer in reindeer)
                {
                    var periodTime = t % deer.CyclePeriod;
                    if (periodTime < deer.FlyTime)
                        deer.Distance += deer.Speed;
                }
            }
            return reindeer.Max(d => d.Distance);
        }

        private IEnumerable<Reindeer> GetReindeer()
        {
            foreach (var line in Data)
            {
                var tokens = line.Split(' ');
                yield return new Reindeer
                {
                    Name = tokens[0],
                    Speed = int.Parse(tokens[3]),
                    FlyTime = int.Parse(tokens[6]),
                    RestTime = int.Parse(tokens[13]),
                };
            }
        }

        public class Reindeer
        {
            public string Name { get; set; }
            public int Speed { get; set; }
            public int FlyTime { get; set; }
            public int RestTime { get; set; }
            public int CyclePeriod { get => FlyTime + RestTime; }
            public int Distance { get; set; }
        }
    }
}
