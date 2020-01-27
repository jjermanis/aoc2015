using System;
using System.Security.Cryptography;
using System.Text;

namespace AoC2015
{
    public class Day04 : IDay
    {
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
            Console.WriteLine($"First compliant value with 5 leading zeroes: {LowestLeadingZeroHash(5)}");
            Console.WriteLine($"First compliant value with 6 leading zeroes: {LowestLeadingZeroHash(6)}");
        }

        public int LowestLeadingZeroHash(int zeroCount)
        {
            var leadingZeroes = new string('0', zeroCount);

            using (var hasher = MD5.Create())
            {
                for (var x = 0; x < int.MaxValue; x++)
                {
                    var hash = GetMd5Hash(hasher, $"{_key}{x}");

                    if (leadingZeroes.Equals(hash.Substring(0, zeroCount)))
                        return x;
                }
            }
            throw new Exception("Never gets here");
        }

        private string GetMd5Hash(MD5 hasher, string input)
        {
            var rawData = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder();
            for (int i = 0; i < rawData.Length; i++)
            {
                sb.Append(rawData[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
