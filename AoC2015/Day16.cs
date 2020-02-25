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
        }

        public int GetExactSue()
            => GetSue(IsExactMatch);

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

        private IList<Dictionary<string, int>> GetSues()
        {
            var result = new List<Dictionary<string, int>>();
            foreach (var sue in Data)
            {
                var newSue = new Dictionary<string, int>();
                var tokens = sue.Split(' ');
                newSue[ID] = TokTrimVal(1);
                newSue[TokTrim(2)] = TokTrimVal(3);
                newSue[TokTrim(4)] = TokTrimVal(5);
                newSue[TokTrim(6)] = int.Parse(tokens[7]);
                result.Add(newSue);

                string TokTrim(int index)
                    => TrimLast(tokens[index]);
                int TokTrimVal(int index)
                    => int.Parse(TokTrim(index));
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
