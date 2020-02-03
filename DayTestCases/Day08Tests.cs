using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day08Tests
    {
        [Fact]
        public void Problem081_Test1_Returns12()
           => TestProb1(1, 12);

        [Fact]
        public void Problem082_Test1_Returns19()
           => TestProb2(1, 19);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day08($"Day08Test{testNumber}.txt").Part1());
        private void TestProb2(int testNumber, int expected)
            => Assert.Equal(expected, new Day08($"Day08Test{testNumber}.txt").Part2());

    }
}
