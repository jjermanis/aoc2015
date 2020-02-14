using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day13 : DayMultiLineText, IDay
    {
        public Day13(string filename) : base(filename)
        {
        }

        public Day13() : this("Day13.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Maximum happiness: {MostHappyArrangement()}");
        }

        public int MostHappyArrangement()
        {
            var result = 0;
            foreach (var distance in ArrangementHappiness())
                result = Math.Max(result, distance);
            return result;
        }

        private IEnumerable<int> ArrangementHappiness()
        {
            (var guests, var happinessMap) = GetSeatingInfo();

            var gc = guests.Count;
            // Iterate through all seating permutations
            foreach (var arrangement in Util.PermuteFromLength(gc))
            {
                var happiness = 0;
                for (int i = 0; i < gc; i++)
                {
                    // Calculate this guest's happiness due to neighbors. The neighbors' 
                    // happiness is handled on THEIR turn through the loop.
                    var guest = guests[arrangement[i]];
                    (var left, var right) = Neighbors(i);
                    happiness += happinessMap[(guest, left)];
                    happiness += happinessMap[(guest, right)];
                }
                yield return happiness;

                (string, string) Neighbors(int i)
                    => (guests[arrangement[(i - 1 + gc) % gc]],
                        guests[arrangement[(i + 1 + gc) % gc]]);
            }
        }

        private (List<string>, Dictionary<(string, string), int>) GetSeatingInfo()
        {
            var guests = new HashSet<string>();
            var happinessMap = new Dictionary<(string, string), int>();
            foreach (var route in Data)
            {
                var tokens = route.Split(' ');
                var personA = tokens[0];
                var verb = tokens[2];
                var units = int.Parse(tokens[3]);
                if ("lose".Equals(verb))
                    units = -units;
                var personB = tokens[10].Substring(0, tokens[10].Length - 1);

                guests.Add(personA);
                happinessMap[(personA, personB)] = units;
            }
            return (guests.ToList(), happinessMap);
        }
    }
}
