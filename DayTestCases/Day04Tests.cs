using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day04Tests
    {
        [Fact]
        public void Problem041_TestCase1_Returns609043()
            => TestProb1("abcdef", 609043);

        [Fact]
        public void Problem041_TestCase2_Returns1048970()
            => TestProb1("pqrstuv", 1048970);

        private void TestProb1(string key, int expected)
            => Assert.Equal(expected, new Day04(key).LowestLeading5ZeroHash());

    }
}
