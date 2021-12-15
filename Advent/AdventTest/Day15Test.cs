using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day15Test
    {
        private Day15 _day15;

        [TestInitialize]
        public void Setup()
        {
            _day15 = new Day15();
        }
        
        [TestMethod]
        public void ShortestShouldBe40()
        {
            var expectedResult = 40;

            var actualResult = _day15.Shortest(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ShortestFiveTimesBiggerShouldBe315()
        {
            var expectedResult = 315;

            var actualResult = _day15.ShortestFive(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

    }
}