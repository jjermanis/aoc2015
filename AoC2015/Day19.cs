using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day19 : DayMultiLineText, IDay
    {
        private const string REPL_SEP = "=>";

        private readonly List<Replacement> _replacements;
        private readonly string _molecule;

        public Day19(string filename) : base(filename)
        {
            (_replacements, _molecule) = ParseProblemData();
        }

        public Day19() : this("Day19.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"New molecule options: {DistinctMoleculeCount()}");
        }

        public int DistinctMoleculeCount()
        {
            var newMolecules = new HashSet<string>();
            foreach (var repl in _replacements)
                foreach (var index in IndexesOf(_molecule, repl.Src))
                    newMolecules.Add(
                        $"{_molecule.Substring(0, index)}{repl.Dest}{_molecule.Substring(index + repl.Src.Length)}");
            return newMolecules.Count;
        }

        private IEnumerable<int> IndexesOf(string val, string search)
        {
            int currIndex = val.IndexOf(search);
            while (currIndex != -1)
            {
                yield return currIndex;
                currIndex = val.IndexOf(search, currIndex + 1);
            }
        }

        private (List<Replacement>, string) ParseProblemData()
        {
            var replacements = new List<Replacement>();
            foreach(var line in Data)
            {
                if (line.Contains(REPL_SEP))
                {
                    var tokens = line.Split(REPL_SEP).Select(t => t.Trim()).ToArray();
                    replacements.Add(new Replacement { Src = tokens[0], Dest = tokens[1] });
                }
                else if (line.Trim().Length > 0)
                    return (replacements, line);
            }
            throw new Exception("Never gets here");
        }
    }

    class Replacement
    {
        public string Src { get; set; }
        public string Dest { get; set; }
        public override string ToString()
            => $"{Src} => {Dest}";
    }
}
