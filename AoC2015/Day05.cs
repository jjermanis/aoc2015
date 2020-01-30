using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day05 : DayMultiLineText, IDay
    {
        private readonly HashSet<char> VOWELS = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        private readonly HashSet<string> FORBIDDEN = new HashSet<string> { "ab", "cd", "pq", "xy" };


        public Day05(string filename) : base(filename)
        {
        }
        public Day05() : base ("Day05.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Nice word count V1: {NiceWordCountV1()}");
            Console.WriteLine($"Nice word count V2: {NiceWordCountV2()}");
        }

        public int NiceWordCountV1()
            => NiceWordCount(IsNiceV1);
        public int NiceWordCountV2()
            => NiceWordCount(IsNiceV2);

        private int NiceWordCount(Func<string, bool> isNiceFunc)
            => Data.Count(w => isNiceFunc(w));

        private bool IsNiceV1(string word)
            => VowelCount(word) >= 3 && HasDouble(word) && !HasBannedPhrase(word);

        private bool IsNiceV2(string word)
            => HasRepeatedPair(word) && HasABA(word);

        private int VowelCount(string word)
            => word.Count(c => VOWELS.Contains(c));

        private bool HasDouble(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
                if (word[i] == word[i + 1])
                    return true;
            return false;
        }

        private bool HasBannedPhrase(string word)
        {
            foreach (var badPhrase in FORBIDDEN)
                if (word.Contains(badPhrase))
                    return true;
            return false;
        }

        private bool HasRepeatedPair(string word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                var pair = word.Substring(i, 2);
                if (word.Substring(i + 2).Contains(pair))
                    return true;
            }
            return false;
        }

        private bool HasABA(string word)
        {
            for (int i = 0; i < word.Length - 2; i++)
                if (word[i] == word[i + 2])
                    return true;
            return false;
        }

    }
}
