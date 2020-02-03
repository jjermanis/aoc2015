using System;
using System.Linq;

namespace AoC2015
{
    public class Day08 : DayMultiLineText, IDay
    {
        private const char BACKSLASH = '\\';
        private const char DOUBLE_QUOTE = '\"';
        private const char HEX_ESCAPE = 'x';

        public Day08(string filename) : base(filename)
        {
        }

        public Day08() : this("Day08.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Number of chars of code for string literals minus number " +
                $"of chars in memory: {Part1()}");
            Console.WriteLine($"Number of chars to represent the newly encoded strings minus " +
                $"number of chars of code in each original: {Part2()}");
        }

        public int Part1()
        {
            int result = 0;
            foreach (var line in Data)
            {
                var memoryCount = DecodedCharLen(line);
                result += line.Length - memoryCount;
            }
            return result;
        }

        public int Part2()
        {
            int result = 0;
            foreach (var line in Data)
            {
                var encodedCount = EncodedCharLen(line);
                result += encodedCount - line.Length;
            }
            return result;
        }

        private int DecodedCharLen(string val)
        {
            var charCount = 0;
            // Ignore outer-most quotes
            for (int i=1; i < val.Length-1; i++)
            {
                if (val[i] == BACKSLASH)
                {
                    switch (val[i + 1])
                    {
                        case BACKSLASH:
                        case DOUBLE_QUOTE:
                            // Skip past the escaped character
                            i++;
                            break;
                        case HEX_ESCAPE:
                            // Assume the hex number is OK
                            i += 3;
                            break;
                        default:
                            throw new Exception($"Unhandled escape character: {val[i + 1]}");
                    }
                }
                charCount++;
            }

            return charCount;
        }

        // Everything has at least 2, for the new outer-most, unescaped quotes
        // Plus the original string content
        // Plus the characters that require escaping
        private int EncodedCharLen(string val)
            => 2 + val.Length + val.Where(c => c == BACKSLASH || c == DOUBLE_QUOTE).Count();
    }
}
