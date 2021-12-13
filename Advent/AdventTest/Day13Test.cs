using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day13Test
    {
        private Day13 _day13;

        [TestInitialize]
        public void Setup()
        {
            _day13 = new Day13();
        }
        
        [TestMethod]
        public void Result1ShouldBe17()
        {
            var expectedResult = 17;

            var actualResult = _day13.OneFoldDots(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Result2ShouldBe0()
        {
            var expectedResult = new []
            {
                "*****", "*...*", "*...*", "*...*", "*****", ".....", "....."
            };

            var actualResult = _day13.AllFoldsCode(_input);

            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        
        private string _input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

    }
}