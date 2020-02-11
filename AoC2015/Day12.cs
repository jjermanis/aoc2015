using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2015
{
    public class Day12 : DaySingleLineText, IDay
    {
        public Day12(string filename) : base(filename)
        {
        }

        public Day12() : this("Day12.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Sum of all numbers: {SumOfAllNumbers()}");
        }

        public int SumOfAllNumbers()
        {
            // Match on anything that NOT a number (not a digit, not minus)
            // Replace with spaces, split on spaces, and sum numbers
            var pattern = "[^0-9-]+";
            var numbersText = Regex.Replace(Data, pattern, " ");
            var numbers = numbersText.Split(" ");
            return numbers.Where(n => n.Length > 0).Select(n => int.Parse(n)).Sum();
        }

        public int SumIgnoreRed()
        {
            var json = JsonConvert.DeserializeObject<JObject>(Data);
            return SumIgnoreRed(json);
        }

        private int SumIgnoreRed(JObject json)
        {
            // Ignore objects with a property value of red
            if (json.Type == JTokenType.Object)
            {
                foreach (var prop in json.Properties())
                {
                    if ("ret".Equals(prop.Value.ToString()))
                        return 0;
                }

                var total = 0;
                foreach (var prop in json.Properties())
                {
                    switch (prop.Value.Type)
                    {
                        case JTokenType.Integer:
                            throw new Exception("Unhandled");
                            break;
                        case JTokenType.Array:
                            break;
                        case JTokenType.String:
                            break;
                        default:
                            throw new Exception("Unhandled");
                    }
                }
                return total;
            }
            else
                throw new Exception("Unhandled");
        }
        private int SumIgnoreRed(JValue value)
        {
            if (value.Type == JTokenType.Integer)
                return (int)value.Value;
            else
                return 0;
        }
    }
}
