using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day21Test
    {
        private Day21 _day21;

        [TestInitialize]
        public void Setup()
        {
            _day21 = new Day21();
        }
        
        [TestMethod]
        public void With100SidedShouldBe739785()
        {
            var expectedResult = 739785;

            var actualResult = _day21.With100Sided(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void UniverseWinsShouldBe444356092776315()
        {
            var expectedResult = 444356092776315;

            var actualResult = _day21.UniverseWins(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"Player 1 starting position: 4
Player 2 starting position: 8";

    }
}