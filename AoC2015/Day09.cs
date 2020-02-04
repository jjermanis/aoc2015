using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day09 : DayMultiLineText, IDay
    {
        public Day09(string filename) : base(filename)
        {
        }

        public Day09() : this("Day09.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Shortest circuit length: {ShortestRoute()}");
            Console.WriteLine($"Longest circuit length: {LongestRoute()}");
        }

        public int ShortestRoute()
        {
            var result = int.MaxValue;
            foreach (var distance in RouteDistances())
                result = Math.Min(result, distance);
            return result;
        }

        public int LongestRoute()
        {
            var result = 0;
            foreach (var distance in RouteDistances())
                result = Math.Max(result, distance);
            return result;
        }

        private IEnumerable<int> RouteDistances()
        {
            (var destinations, var routes) = GetRouteInfo();

            var dc = destinations.Count;
            // Iterate through all the routes, in every permutation
            foreach (var itinerary in Util.PermuteFromLength(dc))
            {
                var journeyLen = 0;
                for (int i = 0; i < dc - 1; i++)
                {
                    var origin = destinations[itinerary[i]];
                    var dest = destinations[itinerary[i + 1]];
                    journeyLen += routes[(origin, dest)];
                }
                yield return journeyLen;
            }
        }

        private (List<string>, Dictionary<(string, string), int>) GetRouteInfo()
        {
            var destinationMap = new HashSet<string>();
            var routes = new Dictionary<(string, string), int>();
            foreach (var route in Data)
            {
                var tokens = route.Split(' ');
                var pointA = tokens[0];
                var pointB = tokens[2];
                var dist = int.Parse(tokens[4]);

                // Given a route from A->B, also save B->A
                destinationMap.Add(pointA);
                destinationMap.Add(pointB);
                routes[(pointA, pointB)] = dist;
                routes[(pointB, pointA)] = dist;
            }
            return (destinationMap.ToList(), routes);
        }
    }
}
