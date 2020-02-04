using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day09Tests
    {
        [Fact]
        public void Problem091_Test1_Returns605()
           => TestProb1(1, 605);

        [Fact]
        public void Problem092_Test1_Returns605()
            => TestProb2(1, 982);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day09($"Day09Test{testNumber}.txt").ShortestRoute());
        private void TestProb2(int testNumber, int expected)
            => Assert.Equal(expected, new Day09($"Day09Test{testNumber}.txt").LongestRoute());
    }
}
