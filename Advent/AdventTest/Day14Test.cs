using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day14Test
    {
        private Day14 _day14;

        [TestInitialize]
        public void Setup()
        {
            _day14 = new Day14();
        }
        
        [TestMethod]
        public void PolymerAfter10ShouldBe1588()
        {
            var expectedResult = 1588;

            var actualResult = _day14.After10(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void PolymerAfter40ShouldBe2188189693529()
        {
            var expectedResult = 2188189693529;

            var actualResult = _day14.After40(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

    }
}