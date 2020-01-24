using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day02Tests
    {
        [Fact]
        public void Problem021_TestCase1_Returns58()
            => TestProb1(1, 58);
        [Fact]
        public void Problem021_TestCase2_Returns43()
            => TestProb1(2, 43);
        [Fact]
        public void Problem022_TestCase1_Returns34()
            => TestProb2(1, 34);
        [Fact]
        public void Problem022_TestCase2_Returns14()
            => TestProb2(2, 14);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day02($"Day02Test{testNumber}.txt").WrappingPaper());

        private void TestProb2(int testNumber, int expected)
            => Assert.Equal(expected, new Day02($"Day02Test{testNumber}.txt").Ribbon());

    }
}
