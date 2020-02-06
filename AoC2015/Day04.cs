using System;
using System.Security.Cryptography;
using System.Text;

namespace AoC2015
{
    public class Day04 : IDay
    {
        private int MAX_SUPPORTED_COUNT = 6;

        private readonly string _key;

        public Day04(string key)
        {
            _key = key;
        }
        public Day04() : this("yzbqklnj")
        {
        }

        public void Do()
        {
            Console.WriteLine($"First compliant value with 5 leading zeroes: {LowestLeading5ZeroHash()}");
            Console.WriteLine($"First compliant value with 6 leading zeroes: {LowestLeading6ZeroHash()}");
        }

        public int LowestLeading5ZeroHash()
            => LowestLeadingZeroHash(DoesHashStartWith5Zero);
        public int LowestLeading6ZeroHash()
            => LowestLeadingZeroHash(DoesHashStartWith6Zero);

        private int LowestLeadingZeroHash(Func<MD5, string, bool> DoesMatchPattern)
        {
            using (var hasher = MD5.Create())
            {
                for (var x = 0; x < int.MaxValue; x++)
                {
                    if (DoesMatchPattern(hasher, $"{_key}{x}"))
                        return x;
                }
            }
            throw new Exception("Never gets here");
        }

        private bool DoesHashStartWith5Zero(MD5 hasher, string input)
        {
            var rawData = GetHash(hasher, input);
            return rawData[0] == 0 && rawData[1] == 0 && (rawData[2] & 0xF0) == 0;
        }

        private bool DoesHashStartWith6Zero(MD5 hasher, string input)
        {
            var rawData = GetHash(hasher, input);
            return rawData[0] == 0 && rawData[1] == 0 && rawData[2]  == 0;
        }

        private byte[] GetHash(MD5 hasher, string input)
            => hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
    }
}
