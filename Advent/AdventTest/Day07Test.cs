using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day07Test
    {
        private Day07 _day07;

        [TestInitialize]
        public void Setup()
        {
            _day07 = new Day07();
        }
        
        [TestMethod]
        public void ConstantFuelShouldBe37()
        {
            var expectedResult = 37;

            var actualResult = _day07.ConstantFuel(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void IncreasingFuelShouldBe168()
        {
            var expectedResult = 168;

            var actualResult = _day07.IncreasingFuel(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"16,1,2,0,4,2,7,1,2,14";

    }
}