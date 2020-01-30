using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day05Tests
    {
        [Fact]
        public void Problem051_TestCase1_Returns2()
            => TestProb1(1, 2);

        [Fact]
        public void Problem052_TestCase2_Returns2()
            => TestProb2(2, 2);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day05($"Day05Test{testNumber}.txt").NiceWordCountV1());
        private void TestProb2(int testNumber, int expected)
            => Assert.Equal(expected, new Day05($"Day05Test{testNumber}.txt").NiceWordCountV2());

    }
}
