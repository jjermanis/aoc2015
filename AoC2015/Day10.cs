using System;
using System.Text;

namespace AoC2015
{
    public class Day10 : IDay
    {
        private readonly string _start;

        public Day10(string start)
        {
            _start = start;
        }

        public Day10() : this("1113122113")
        {
        }

        public void Do()
        {
            var n = 40;
            Console.WriteLine($"Length of {_start} after {n} round: {LookAndSayLen(n)}");
            n = 50;
            Console.WriteLine($"Length of {_start} after {n} round: {LookAndSayLen(n)}");
        }

        public int LookAndSayLen(int rounds)
            => LookAndSay(rounds).Length;

        private string LookAndSay(int rounds)
        {
            var curr = _start;
            for (int i = 0; i < rounds; i++)
                curr = LookAndSay(curr);
            return curr;
        }

        private string LookAndSay(string word)
        {
            char curr = word[0];
            var sb = new StringBuilder();
            var count = 1;
            for (var i = 1; i < word.Length; i++)
            {
                if (word[i] != curr)
                {
                    AddTerm(count, curr);
                    curr = word[i];
                    count = 1;
                }
                else
                    count++;
            }
            AddTerm(count, curr);
            return sb.ToString();

            void AddTerm(int n, char val) => sb.Append($"{n}{val}");
        }
    }
}
