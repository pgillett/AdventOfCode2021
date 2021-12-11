using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day11Test
    {
        private Day11 _day11;

        [TestInitialize]
        public void Setup()
        {
            _day11 = new Day11();
        }
        
        [TestMethod]
        public void After100ShouldBe1656()
        {
            var expectedResult = 1656;

            var actualResult = _day11.After100(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void SynchronizePointShouldBe195()
        {
            var expectedResult = 195;

            var actualResult = _day11.Synchronise(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    }
}