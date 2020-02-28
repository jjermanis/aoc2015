using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day17Tests
    {
        [Fact]
        public void Problem171_Test1_Returns4()
        {
            var day = new Day17("Day17Test1.txt");
            Assert.Equal(4, day.CombinationsCount(25));
        }

        [Fact]
        public void Problem172_Test1_Returns3()
        {
            var day = new Day17("Day17Test1.txt");
            Assert.Equal(3, day.OptimalCombinationCount(25));
        }
    }
}
