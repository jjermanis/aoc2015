﻿using AoC2015;
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
            var result = day.LowestLeadingZeroHash(5);
            Assert.Equal(282749, result);
        }

        [Fact]
        public void Day04_Part2_IsCorrect()
        {
            var day = new Day04();
            var result = day.LowestLeadingZeroHash(6);
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
    }
}
