using System;
using System.Linq;

namespace AoC2015
{
    public class Day06 : DayMultiLineText, IDay
    {
        public Day06(string filename) : base(filename)
        {
        }
        public Day06() : base("Day06.txt")
        {
        }

        public void Do()
        {
            Console.WriteLine($"Lights on v1: {LightsOnAfterInstructions(1)}");
            Console.WriteLine($"Lights on v2: {LightsOnAfterInstructions(2)}");
        }

        public int LightsOnAfterInstructions(int version)
        {
            var lights = new int[1_000_000];

            foreach(var inst in Data)
            {
                var tokens = inst.Split(' ');

                if ("toggle".Equals(tokens[0]))
                {
                    ToggleRange(version, lights, tokens[1], tokens[3]);
                }
                else if ("off".Equals(tokens[1]))
                {
                    TurnOffRange(version, lights, tokens[2], tokens[4]);
                }
                else
                {
                    TurnOnRange(version, lights, tokens[2], tokens[4]);
                }
            }

            return lights.Sum();
        }

        private void ToggleRange(int version,
            int[] lights,
            string upperLeft,
            string lowerRight)
        {
            if (version == 1)
                HandleRange(lights, upperLeft, lowerRight, ToggleLight);
            else
                HandleRange(lights, upperLeft, lowerRight, BrightnessInc2);
        }

        private void TurnOnRange(int version,
            int[] lights,
            string upperLeft,
            string lowerRight)
        {
            if (version == 1)
                HandleRange(lights, upperLeft, lowerRight, TurnOn);
            else
                HandleRange(lights, upperLeft, lowerRight, BrightnessInc1);
        }

        private void TurnOffRange(int version,
            int[] lights,
            string upperLeft,
            string lowerRight)
        {
            if (version == 1)
                HandleRange(lights, upperLeft, lowerRight, TurnOff);
            else
                HandleRange(lights, upperLeft, lowerRight, BrightnessDec1);
        }

        private void HandleRange(
            int[] lights,
            string upperLeft,
            string lowerRight,
            Action<int[], int> action)
        {
            var p1 = ParseCoordinates(upperLeft);
            var p2 = ParseCoordinates(lowerRight);

            for (int x = p1.X; x <= p2.X; x++)
                for (int y = p1.Y; y <= p2.Y; y++)
                    action(lights, 1000 * x + y);
        }

        private void ToggleLight(int[] lights, int i)
            => lights[i] = lights[i]==0 ? 1 : 0;
        private void TurnOn(int[] lights, int i)
            => lights[i] = 1;
        private void TurnOff(int[] lights, int i)
            => lights[i] = 0;
        private void BrightnessInc2(int[] lights, int i)
            => lights[i] += 2;
        private void BrightnessInc1(int[] lights, int i)
            => lights[i]++;
        private void BrightnessDec1(int[] lights, int i)
        {
            if (lights[i] > 0)
                lights[i]--;
        }

        private Point ParseCoordinates(string val)
        {
            var temp = val.Split(',').Select(s => int.Parse(s)).ToArray();
            return new Point(temp[0], temp[1]);
        }
    }
}
