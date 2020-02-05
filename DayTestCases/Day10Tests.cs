using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day10Tests
    {
        [Fact]
        public void Problem101_Test1_Returns605()
        {
            var day = new Day10("1");
            Assert.Equal(6, day.LookAndSayLen(4));
        }

    }
}
