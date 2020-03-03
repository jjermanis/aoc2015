using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day19Tests
    {
        [Fact]
        public void Problem191_Test1_Returns4()
            =>  TestProb1(1, 4);

        [Fact]
        public void Problem191_Test2_Returns7()
            => TestProb1(2, 7);

        private void TestProb1(int testNumber, int expected)
            => Assert.Equal(expected, new Day19($"Day19Test{testNumber}.txt").DistinctMoleculeCount());
    }
}
