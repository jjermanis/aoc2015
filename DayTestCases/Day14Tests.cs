using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day14Tests
    {
        [Fact]
        public void Problem141_Test1_Returns1120()
        {
            var day = new Day14("Day14Test1.txt");
            Assert.Equal(1120, day.RaceWinnerDistance(1000));
        }

        [Fact]
        public void Problem142_Test1_Returns689()
        {
            var day = new Day14("Day14Test1.txt");
            Assert.Equal(689, day.LeaderPoints(1000));
        }
    }
}
