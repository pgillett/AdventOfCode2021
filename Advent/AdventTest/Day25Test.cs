using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day25Test
    {
        private Day25 _day25;

        [TestInitialize]
        public void Setup()
        {
            _day25 = new Day25();
        }

        [TestMethod]
        public void MoveEast()
        {
            var expectedResult1 = "...>>>>.>..";
            var expectedResult2 = "...>>>.>.>.";

            var cucumbers = new Day25.Cucumbers("...>>>>>...");

            cucumbers.Move();
            cucumbers.FullMap.Should().Be(expectedResult1);
            
            cucumbers.Move();
            cucumbers.FullMap.Should().Be(expectedResult2);
        }
        
        [TestMethod]
        public void EastAndSouth()
        {
            var expectedResult = @"..........
.>........
..v....v>.
..........";

            var input = @"..........
.>v....v..
.......>..
..........";

            var cucumbers = new Day25.Cucumbers(input);

            cucumbers.Move();
            cucumbers.FullMap.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void Wrap()
        {
            var expectedResult = @">......
..v....
..>.v..
.>.v...
...>...
.......
v......";

            var input = @"...>...
.......
......>
v.....>
......>
.......
..vvv..";

            var cucumbers = new Day25.Cucumbers(input);

            for (var i = 0; i < 4; i++)
            {
                cucumbers.Move();
            }
            cucumbers.FullMap.Should().Be(expectedResult);
        }

        [TestMethod]
        public void NumberOfMovesShouldBe58()
        {
            var expectedResult = 58;

            var actualResult = _day25.NumberOfMoves(_input);

            actualResult.Should().Be(expectedResult);
        }

        private string _input = @"v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>";

    }
}