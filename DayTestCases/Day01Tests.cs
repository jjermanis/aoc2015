using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day01Tests
    {
        [Fact]
        public void Problem011_TestCase1_Returns0()
            => TestProb1(1, 0);

        [Fact]
        public void Problem011_TestCase2_Returns0()
            => TestProb1(2, 0);

        [Fact]
        public void Problem011_TestCase3_Returns3()
            => TestProb1(3, 3);

        [Fact]
        public void Problem011_TestCase4_Returns3()
            => TestProb1(4, 3);

        [Fact]
        public void Problem011_TestCase5_Returns3()
            => TestProb1(5, 3);

        [Fact]
        public void Problem011_TestCase6_ReturnsNeg1()
            => TestProb1(6, -1);

        [Fact]
        public void Problem011_TestCase7_ReturnsNeg1()
            => TestProb1(7, -1);

        [Fact]
        public void Problem011_TestCase8_ReturnsNeg3()
            => TestProb1(8, -3);

        [Fact]
        public void Problem011_TestCase9_ReturnsNeg3()
            => TestProb1(9, -3);

        [Fact]
        public void Problem012_TestCase10_Returns1()
            => TestProb2(10, 1);

        [Fact]
        public void Problem012_TestCase11_Returns5()
            => TestProb2(11, 5);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day01($"Day01Test{testNumber}.txt").FindFloor());

        private void TestProb2(int testNumber, int expected)
            => Assert.Equal(expected, new Day01($"Day01Test{testNumber}.txt").TimeToBasement());

    }
}
