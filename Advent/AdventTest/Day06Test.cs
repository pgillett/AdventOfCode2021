using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day06Test
    {
        private Day06 _day06;

        [TestInitialize]
        public void Setup()
        {
            _day06 = new Day06();
        }
        
        [TestMethod]
        public void After18DaysShouldBe5934()
        {
            var expectedResult = 5934;

            var actualResult = _day06.FishAfter80(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void After256DaysShouldBe26984457539()
        {
            var expectedResult = 26984457539;

            var actualResult = _day06.FishAfter256(_input);

            actualResult.Should().Be(expectedResult);
        }

       
        private string _input = @"3,4,3,1,2";

    }
}