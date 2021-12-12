using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day12Test
    {
        private Day12 _day12;

        [TestInitialize]
        public void Setup()
        {
            _day12 = new Day12();
        }
        
        [TestMethod]
        public void OnceSet1ShouldBe10()
        {
            var expectedResult = 10;

            var actualResult = _day12.SmallCavesOnce(_input1);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void OnceSet2ShouldBe19()
        {
            var expectedResult = 19;

            var actualResult = _day12.SmallCavesOnce(_input2);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void OnceSet3ShouldBe226()
        {
            var expectedResult = 226;

            var actualResult = _day12.SmallCavesOnce(_input3);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void TwiceSet1ShouldBe36()
        {
            var expectedResult = 36;

            var actualResult = _day12.SmallCavesOneTwice(_input1);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void TwiceSet2ShouldBe103()
        {
            var expectedResult = 103;

            var actualResult = _day12.SmallCavesOneTwice(_input2);

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        public void TwiceSet3ShouldBe3509()
        {
            var expectedResult = 3509;

            var actualResult = _day12.SmallCavesOneTwice(_input3);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input1 = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";
        
        private string _input2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

        private string _input3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

    }
}