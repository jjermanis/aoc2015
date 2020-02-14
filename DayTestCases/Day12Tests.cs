using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day12Tests
    {
        [Fact]
        public void Problem121_Test1_Returns6()
           => TestProb1(1, 6);

        [Fact]
        public void Problem121_Test2_Returns6()
            => TestProb1(2, 6);

        [Fact]
        public void Problem121_Test3_Returns3()
            => TestProb1(3, 3);

        [Fact]
        public void Problem121_Test4_Returns3()
            => TestProb1(4, 3);

        [Fact]
        public void Problem121_Test5_Returns0()
            => TestProb1(5, 0);

        [Fact]
        public void Problem121_Test6_Returns0()
            => TestProb1(6, 0);

        [Fact]
        public void Problem121_Test7_Returns0()
            => TestProb1(7, 0);

        [Fact]
        public void Problem121_Test8_Returns0()
            => TestProb1(8, 0);


        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day12($"Day12Test{testNumber}.txt").SumOfAllNumbers());

    }
}
