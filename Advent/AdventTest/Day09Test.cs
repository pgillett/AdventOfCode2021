using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day09Test
    {
        private Day09 _day09;

        [TestInitialize]
        public void Setup()
        {
            _day09 = new Day09();
        }
        
        [TestMethod]
        public void RiskShouldBe15()
        {
            var expectedResult = 15;

            var actualResult = _day09.Risk(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ThreeLargestShouldBe1134()
        {
            var expectedResult = 1134;

            var actualResult = _day09.ThreeLargest(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"2199943210
3987894921
9856789892
8767896789
9899965678";

    }
}