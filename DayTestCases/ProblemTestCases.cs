using AoC2015;
using Xunit;
namespace DayTestCases
{
    public class ProblemTestCases
    {
        [Fact]
        public void Day01_Part1_IsCorrect()
        {
            var day = new Day01();
            var result = day.FindFloor();
            Assert.Equal(74, result);
        }

        [Fact]
        public void Day01_Part2_IsCorrect()
        {
            var day = new Day01();
            var result = day.TimeToBasement();
            Assert.Equal(1795, result);
        }

        [Fact]
        public void Day02_Part1_IsCorrect()
        {
            var day = new Day02();
            var result = day.WrappingPaper();
            Assert.Equal(1586300, result);
        }

        [Fact]
        public void Day02_Part2_IsCorrect()
        {
            var day = new Day02();
            var result = day.Ribbon();
            Assert.Equal(3737498, result);
        }
    }
}
