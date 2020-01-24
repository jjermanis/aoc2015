using System;
using System.Linq;

namespace AoC2015
{
    public class Day01 : DaySingleLineText, IDay
    {
        public Day01(string filename) : base(filename)
        {
        }
        public Day01() : base("Day01.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Santa should go to floor: {FindFloor()}");
            Console.WriteLine($"Santa enters basement after move #{TimeToBasement()}");
        }

        public int FindFloor()
            => Data.Select(c => '('.Equals(c) ? 1 : -1).Sum();

        public int TimeToBasement()
        {
            int floor = 0;
            for (int i=0; i<Data.Length; i++)
            {
                floor += '('.Equals(Data[i]) ? 1 : -1;
                if (floor < 0)
                    return i + 1;
            }
            throw new Exception("Never gets here");
        }

    }
}
