using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day03Tests
    {
        [Fact]
        public void Problem031_TestCase1_Returns2()
            => TestProb1(1, 2);
        [Fact]
        public void Problem031_TestCase2_Returns2()
             => TestProb1(2, 4);
        [Fact]
        public void Problem031_TestCase3_Returns2()
             => TestProb1(3, 2);

        [Fact]
        public void Problem032_TestCase2_Returns3()
             => TestProb2(2, 3);
        [Fact]
        public void Problem032_TestCase3_Returns11()
             => TestProb2(3, 11);
        [Fact]
        public void Problem032_TestCase4_Returns3()
            => TestProb2(4, 3);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day03($"Day03Test{testNumber}.txt").HousesVisitedCount());
        private void TestProb2(int testNumber, int expected)
            => Assert.Equal(expected, new Day03($"Day03Test{testNumber}.txt").HousesVisitedByTwoCount());

    }
}
