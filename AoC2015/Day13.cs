using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day13 : DayMultiLineText, IDay
    {
        private const string ME = "me";

        public Day13(string filename) : base(filename)
        {
        }

        public Day13() : this("Day13.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Maximum happiness: {MostHappyArrangement()}");
            Console.WriteLine($"Maximum happiness with me: {MostHappyArrangementWithMe()}");
        }

        public int MostHappyArrangement()
            => MostHappyArrangement(GetHappinessOfGuests);

        public int MostHappyArrangementWithMe()
            => MostHappyArrangement(GetHappinessOfGuestsWithMe);

        private int MostHappyArrangement(Func<IEnumerable<int>> GetHappiness)
        {
            var result = 0;
            (var guests, var happinessMap) = GetSeatingInfo();
            foreach (var distance in GetHappiness())
                result = Math.Max(result, distance);
            return result;
        }

        private IEnumerable<int> GetHappinessOfGuests()
        {
            (var guests, var happinessMap) = GetSeatingInfo();
            foreach (var happiness in ArrangementHappiness(guests, happinessMap))
                yield return happiness;
        }

        private IEnumerable<int> GetHappinessOfGuestsWithMe()
        {
            (var guests, var happinessMap) = GetSeatingInfo();
            foreach (var guest in guests)
            {
                happinessMap[(ME, guest)] = 0;
                happinessMap[(guest, ME)] = 0;
            }
            guests.Add(ME);

            foreach (var happiness in ArrangementHappiness(guests, happinessMap))
                yield return happiness;
        }

        private IEnumerable<int> ArrangementHappiness(
            IList<string> guests,
            IDictionary<(string, string), int> happinessMap)
        {
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
