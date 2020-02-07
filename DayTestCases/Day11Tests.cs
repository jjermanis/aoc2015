using AoC2015;
using Xunit;

namespace DayTestCases
{
    public class Day11Tests
    {
        [Fact]
        public void Problem111_abcdefgh_Returnsabcdffaa()
        {
            var day = new Day11();
            Assert.Equal("abcdffaa", day.NextValidPassword("abcdefgh"));
        }

        [Fact]
        public void Problem111_ghijklmn_Returnsghjaabcc()
        {
            var day = new Day11(); 
            Assert.Equal("ghjaabcc", day.NextValidPassword("ghijklmn"));
        }
    }
}
