using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day23Tests
    {
        [Fact]
        public void Problem231_Test1_Returns2()
        {
            var day = new Day23("Day23Test1.txt");
            (var a, _) = day.RunProgram();
            Assert.Equal(2, a);
        }
    }
}
