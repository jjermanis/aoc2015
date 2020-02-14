using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day13Tests
    {
        [Fact]
        public void Problem131_Test1_Returns330()
        {
            var day = new Day13("Day13Test1.txt");
            Assert.Equal(330, day.MostHappyArrangement());
        }
    }
}
