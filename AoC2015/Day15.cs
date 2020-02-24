using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2015
{
    public class Day15 : DayMultiLineText, IDay
    {
        public Day15(string filename) : base(filename)
        {
        }

        public Day15() : this("Day15.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Maximum score: {MaxScore()}");
            Console.WriteLine($"Maximum score for 500 calories: {MaxScore(500)}");
        }

        public int MaxScore(int? targetCalories = null)
        {
            var ings = GetIngredients();
            var max = 0;
            for (int a=0; a <= 100; a++)
                for (int b=0; a + b <= 100; b++)
                    for (int c=0; a + b + c <= 100; c++)
                        for (int d=0; a + b + c + d <= 100; d++)
                        {
                            int frost = a * ings[0].Frosting + b * ings[1].Frosting + c * ings[2].Frosting + d * ings[3].Frosting;
                            int dura = a * ings[0].Durability + b * ings[1].Durability + c * ings[2].Durability + d * ings[3].Durability;
                            int flavor = a * ings[0].Flavor + b * ings[1].Flavor + c * ings[2].Flavor + d * ings[3].Flavor;
                            int text = a * ings[0].Texture + b * ings[1].Texture + c * ings[2].Texture + d * ings[3].Texture;
                            int calories = a * ings[0].Calories + b * ings[1].Calories + c * ings[2].Calories + d * ings[3].Calories;

                            if (frost > 0 && dura > 0 && flavor > 0 && text > 0)
                                if (!targetCalories.HasValue || calories == targetCalories)
                                    max = Math.Max(max, frost * dura * flavor * text);
                        }
            return max;
        }

        
        private List<Ingredient> GetIngredients()
        {
            var result = new List<Ingredient>();
            foreach (var line in Data)
            {
                var tokens = line.Split(' ');
                result.Add(new Ingredient
                {
                    Name = TrimLast(tokens[0]),
                    Frosting = Value(tokens[2]),
                    Durability = Value(tokens[4]),
                    Flavor = Value(tokens[6]),
                    Texture = Value(tokens[8]),
                    Calories = Value(tokens[10]),
                });
            }

            return result;

            int Value(string s) => int.Parse(s.Replace(',', ' '));
        }

        public class Ingredient
        {
            public string Name { get; set; }
            public int Frosting { get; set; }
            public int Durability { get; set; }
            public int Flavor { get; set; }
            public int Texture { get; set; }
            public int Calories { get; set; }
        }
    }
}
