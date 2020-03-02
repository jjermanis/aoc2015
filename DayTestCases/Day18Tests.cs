using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day18Tests
    {
        [Fact]
        public void Problem181_Test1_Returns4()
        {
            var day = new Day18("Day18Test1.txt");
            Assert.Equal(4, day.LightsOnCountMultipleSteps(4));
        }

        [Fact]
        public void Problem182_Test1_Returns17()
        {
            var day = new Day18("Day18Test1.txt");
            Assert.Equal(17, day.LightsOnCountMultipleSteps(5, true));
        }
    }
}
