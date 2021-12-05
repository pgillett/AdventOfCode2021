using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day05Test
    {
        private Day05 _day05;

        [TestInitialize]
        public void Setup()
        {
            _day05 = new Day05();
        }
        
        [TestMethod]
        public void ExcludingShouldBe5()
        {
            var expectedResult = 5;

            var actualResult = _day05.VentsExcluding(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void IncludingShouldBe12()
        {
            var expectedResult = 12;

            var actualResult = _day05.VentsIncluding(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

    }
}