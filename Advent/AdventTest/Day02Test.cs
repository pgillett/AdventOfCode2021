using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day02Test
    {
        private Day02 _day02;

        [TestInitialize]
        public void Setup()
        {
            _day02 = new Day02();
        }
        
        [TestMethod]
        public void MoveShouldBe150()
        {
            var expectedResult = 150;

            var actualResult = _day02.Move(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void AimShouldBe900()
        {
            var expectedResult = 900;

            var actualResult = _day02.Aim(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

    }
}