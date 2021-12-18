using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day17Test
    {
        private Day17 _day17;

        [TestInitialize]
        public void Setup()
        {
            _day17 = new Day17();
        }
        
        [TestMethod]
        public void Result1ShouldBe45()
        {
            var expectedResult = 45;

            var actualResult = _day17.MaxHeight(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Result2ShouldBe0()
        {
            var expectedResult = 112;

            var actualResult = _day17.NumberOfHits(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"target area: x=20..30, y=-10..-5";

    }
}