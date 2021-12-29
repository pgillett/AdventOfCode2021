using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day23Test
    {
        private Day23 _day23;

        [TestInitialize]
        public void Setup()
        {
            _day23 = new Day23();
        }
        
        [TestMethod]
        public void FoldedShouldBe12521()
        {
            var expectedResult = 12521;

            var actualResult = _day23.Folded(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void UnfoldedShouldBe44169()
        {
            var expectedResult = 44169;

            var actualResult = _day23.Unfolded(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########";
    }
}