using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day07Tests
    {
        [Fact]
        public void Problem071_WireD_Returns72()
            => TestProb1(1, "d", 72);

        [Fact]
        public void Problem071_WireG_Returns114()
        => TestProb1(1, "g", 114);

        [Fact]
        public void Problem071_WireH_Returns65412()
        => TestProb1(1, "h", 65412);

        private void TestProb1(int testNumber, string wire, int expected)
            => Assert.Equal(expected, new Day07($"Day07Test{testNumber}.txt").GetSignal(wire));
    }
}
