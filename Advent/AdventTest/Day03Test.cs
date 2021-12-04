using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day03Test
    {
        private Day03 _day03;

        [TestInitialize]
        public void Setup()
        {
            _day03 = new Day03();
        }
        
        [TestMethod]
        public void PowerConsumptionShouldBe198()
        {
            var expectedResult = 198;

            var actualResult = _day03.Power(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LifeSupportShouldBe230()
         {
             var expectedResult = 230;
        
             var actualResult = _day03.Life(_input);
        
             actualResult.Should().Be(expectedResult);
         }
        
        private string _input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

    }
}