using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class UnitTest1
    {
        private Day01 _day01;

        [TestInitialize]
        public void Setup()
        {
            _day01 = new Day01();
        }
        
        [TestMethod]
        public void InputDataShouldBe7()
        {
            var expectedResult = 7;

            var actualResult = _day01.Increases(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void InputSlidingShouldBe5()
        {
            var expectedResult = 5;

            var actualResult = _day01.SlidingIncreases(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"199
200
208
210
200
207
240
269
260
263";

    }
}