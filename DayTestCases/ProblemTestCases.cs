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

        [Fact]
        public void Day03_Part1_IsCorrect()
        {
            var day = new Day03();
            var result = day.HousesVisitedCount();
            Assert.Equal(2572, result);
        }

        [Fact]
        public void Day03_Part2_IsCorrect()
        {
            var day = new Day03();
            var result = day.HousesVisitedByTwoCount();
            Assert.Equal(2631, result);
        }

        [Fact]
        public void Day04_Part1_IsCorrect()
        {
            var day = new Day04();
            var result = day.LowestLeading5ZeroHash();
            Assert.Equal(282749, result);
        }

        [Fact]
        public void Day04_Part2_IsCorrect()
        {
            var day = new Day04();
            var result = day.LowestLeading6ZeroHash();
            Assert.Equal(9962624, result);
        }

        [Fact]
        public void Day05_Part1_IsCorrect()
        {
            var day = new Day05();
            var result = day.NiceWordCountV1();
            Assert.Equal(258, result);
        }

        [Fact]
        public void Day05_Part2_IsCorrect()
        {
            var day = new Day05();
            var result = day.NiceWordCountV2();
            Assert.Equal(53, result);
        }

        [Fact]
        public void Day06_Part1_IsCorrect()
        {
            var day = new Day06();
            var result = day.LightsOnAfterInstructions(1);
            Assert.Equal(543903, result);
        }

        [Fact]
        public void Day06_Part2_IsCorrect()
        {
            var day = new Day06();
            var result = day.LightsOnAfterInstructions(2);
            Assert.Equal(14687245, result);
        }

        [Fact]
        public void Day07_Part1_IsCorrect()
        {
            var day = new Day07();
            var result = day.GetSignal("a");
            Assert.Equal(16076, result);
        }

        [Fact]
        public void Day07_Part2_IsCorrect()
        {
            var day = new Day07();
            var result = day.GetRemappedSignal("a");
            Assert.Equal(2797, result);
        }

        [Fact]
        public void Day08_Part1_IsCorrect()
        {
            var day = new Day08();
            var result = day.Part1();
            Assert.Equal(1342, result);
        }

        [Fact]
        public void Day08_Part2_IsCorrect()
        {
            var day = new Day08();
            var result = day.Part2();
            Assert.Equal(2074, result);
        }

        [Fact]
        public void Day09_Part1_IsCorrect()
        {
            var day = new Day09();
            var result = day.ShortestRoute();
            Assert.Equal(141, result);
        }

        [Fact]
        public void Day09_Part2_IsCorrect()
        {
            var day = new Day09();
            var result = day.LongestRoute();
            Assert.Equal(736, result);
        }

        [Fact]
        public void Day10_Part1_IsCorrect()
        {
            var day = new Day10();
            var result = day.LookAndSayLen(40);
            Assert.Equal(360154, result);
        }

        [Fact]
        public void Day10_Part2_IsCorrect()
        {
            var day = new Day10();
            var result = day.LookAndSayLen(50);
            Assert.Equal(5103798, result);
        }

        [Fact]
        public void Day11_Part1_IsCorrect()
        {
            var day = new Day11();
            var result = day.NextValidPassword("vzbxkghb");
            Assert.Equal("vzbxxyzz", result);
        }

        [Fact]
        public void Day11_Part2_IsCorrect()
        {
            var day = new Day11();
            var result = day.NextValidPassword("vzbxxyzz");
            Assert.Equal("vzcaabcc", result);
        }

        [Fact]
        public void Day12_Part1_IsCorrect()
        {
            var day = new Day12();
            var result = day.SumOfAllNumbers();
            Assert.Equal(119433, result);
        }

        //[Fact]
        //public void Day12_Part2_IsCorrect()
        //{
        //}

        [Fact]
        public void Day13_Part1_IsCorrect()
        {
            var day = new Day13();
            var result = day.MostHappyArrangement();
            Assert.Equal(618, result);
        }

        [Fact]
        public void Day13_Part2_IsCorrect()
        {
            var day = new Day13();
            var result = day.MostHappyArrangementWithMe();
            Assert.Equal(601, result);
        }

        [Fact]
        public void Day14_Part1_IsCorrect()
        {
            var day = new Day14();
            var result = day.RaceWinnerDistance(2503);
            Assert.Equal(2696, result);
        }

        [Fact]
        public void Day14_Part2_IsCorrect()
        {
            var day = new Day14();
            var result = day.LeaderPoints(2503);
            Assert.Equal(1084, result);
        }

        [Fact]
        public void Day15_Part1_IsCorrect()
        {
            var day = new Day15();
            var result = day.MaxScore();
            Assert.Equal(18965440, result);
        }

        [Fact]
        public void Day15_Part2_IsCorrect()
        {
            var day = new Day15();
            var result = day.MaxScore(500);
            Assert.Equal(15862900, result);
        }

        [Fact]
        public void Day16_Part1_IsCorrect()
        {
            var day = new Day16();
            var result = day.GetExactSue();
            Assert.Equal(40, result);
        }

        [Fact]
        public void Day16_Part2_IsCorrect()
        {
            var day = new Day16();
            var result = day.GetSuePart2();
            Assert.Equal(241, result);
        }

        [Fact]
        public void Day17_Part1_IsCorrect()
        {
            var day = new Day17();
            var result = day.CombinationsCount(150);
            Assert.Equal(4372, result);
        }

        [Fact]
        public void Day17_Part2_IsCorrect()
        {
            var day = new Day17();
            var result = day.OptimalCombinationCount(150);
            Assert.Equal(4, result);
        }

        [Fact]
        public void Day18_Part1_IsCorrect()
        {
            var day = new Day18();
            var result = day.LightsOnCountMultipleSteps(100);
            Assert.Equal(814, result);
        }

        [Fact]
        public void Day18_Part2_IsCorrect()
        {
            var day = new Day18();
            var result = day.LightsOnCountMultipleSteps(100, true);
            Assert.Equal(924, result);
        }

        [Fact]
        public void Day19_Part1_IsCorrect()
        {
            var day = new Day19();
            var result = day.DistinctMoleculeCount();
            Assert.Equal(535, result);
        }

        [Fact]
        public void Day20_Part1_IsCorrect()
        {
            var day = new Day20();
            var result = day.FirstHouseAtLimit();
            Assert.Equal(665280, result);
        }

        [Fact]
        public void Day20_Part2_IsCorrect()
        {
            var day = new Day20();
            var result = day.FirstHouseCappedVisits(50);
            Assert.Equal(705600, result);
        }

        [Fact]
        public void Day21_Part1_IsCorrect()
        {
            var day = new Day21();
            var result = day.CheapestVictory();
            Assert.Equal(121, result);
        }

        [Fact]
        public void Day21_Part2_IsCorrect()
        {
            var day = new Day21();
            var result = day.CostliestLoss();
            Assert.Equal(201, result);
        }

        [Fact]
        public void Day22_Part1_IsCorrect()
        {
            var day = new Day22();
            var result = day.CheapestVictory();
            Assert.Equal(1269, result);
        }

        [Fact]
        public void Day23_Part1_IsCorrect()
        {
            var day = new Day23();
            (_, var result) = day.RunProgram();
            Assert.Equal(307, result);
        }

        [Fact]
        public void Day23_Part2_IsCorrect()
        {
            var day = new Day23();
            (_, var result) = day.RunProgram(1, 0);
            Assert.Equal(160, result);
        }

        [Fact]
        public void Day24_Part1_IsCorrect()
        {
            var day = new Day24();
            var result = day.QuantumInOptimalConfig();
            Assert.Equal(11266889531, result);
        }
    }
}
