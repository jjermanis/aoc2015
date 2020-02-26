using System;
using System.Collections.Generic;

namespace AoC2015
{
    public class Day16 : DayMultiLineText, IDay
    {
        private const string INFO_FILE = "Day16Info.txt";
        private const string ID = "id";

        private readonly IDictionary<string, int> _info;

        public Day16(string filename) : base(filename)
        {
            _info = GetCompundInfo();
        }

        public Day16() : this("Day16.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Sue number: {GetExactSue()}");
            Console.WriteLine($"Sue Part 2: {GetSuePart2()}");
        }

        public int GetExactSue()
            => GetSue(IsExactMatch);

        public int GetSuePart2()
            => GetSue(IsPart2Match);

        private int GetSue(Func<string, int, bool> IsValid)
        {
            foreach (var sue in GetSues())
            {
                bool isMatch = true;
                foreach (var key in sue.Keys)
                {
                    if (!IsValid(key, sue[key]))
                        isMatch = false;
                }
                if (isMatch)
                    return sue[ID];
            }
            throw new Exception("Sue not found");
        }

        private bool IsExactMatch(
            string key,
            int sueValue)
            => ID.Equals(key) || sueValue == _info[key];

        private bool IsPart2Match(
            string key,
            int sueValue)
        {
            if (ID.Equals(key))
                return true;

            switch (key)
            {
                case "cats":
                case "trees":
                    return sueValue > _info[key];
                case "pomeranians":
                case "goldfish":
                    return sueValue < _info[key];
                default:
                    return sueValue == _info[key];
            }
        }

        private IList<Dictionary<string, int>> GetSues()
        {
            var result = new List<Dictionary<string, int>>();
            foreach (var sue in Data)
            {
                var newSue = new Dictionary<string, int>();
                var tokens = sue.Split(' ');
                newSue[ID] = TokenTrimVal(1);
                newSue[TokenTrim(2)] = TokenTrimVal(3);
                newSue[TokenTrim(4)] = TokenTrimVal(5);
                newSue[TokenTrim(6)] = int.Parse(tokens[7]);
                result.Add(newSue);

                string TokenTrim(int index)
                    => TrimLast(tokens[index]);
                int TokenTrimVal(int index)
                    => int.Parse(TokenTrim(index));
            }
            return result;
        }

        private IDictionary<string, int> GetCompundInfo()
        {
            var result = new Dictionary<string, int>();
            var rawInfo = TextFileLines(INFO_FILE);
            foreach (var compund in rawInfo)
            {
                var tokens = compund.Split(' ');
                result[TrimLast(tokens[0])] = int.Parse(tokens[1]);
            }
            return result;
        }
    }
}
