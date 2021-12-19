using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day18Test
    {
        private Day18 _day18;

        [TestInitialize]
        public void Setup()
        {
            _day18 = new Day18();
        }

        [TestMethod]
        public void MagnitudeOfTestInputShouldBe4140()
        {
            var expectedResult = 4140;

            var actualResult = _day18.MagnitudeAll(_input2);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
        [DataRow("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
        [DataRow("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
        [DataRow("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
        public void ReduceTests(string input, string expectedResult)
        {
            var sn = new Day18.Snailfish(input);
            sn.Reduce();
            var actualResult = sn.ToString();

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow("[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]", "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
        public void AddShould(string add1, string add2, string expectedResult)
        {
            var sn1 = new Day18.Snailfish(add1);
            var sn2 = new Day18.Snailfish(add2);

            var sn3 = sn1.Add(sn2);
            var actualResult = sn3.ToString();

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void SumOfSetOfSnailfish()
        {
            var expectedResult = "[[[[5,0],[7,4]],[5,5]],[6,6]]";

            var actualResult = Day18.Snailfish.SumOfSet(@"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]").ToString();

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow("[[1,2],[[3,4],5]]", 143)]
        [DataRow("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [DataRow("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [DataRow("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [DataRow("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [DataRow("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        public void MagnitudeShouldBe(string input, int expectedResult)
        {
            var sf = new Day18.Snailfish(input);
            var actualResult = sf.Magnitude();

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void SumOfTwoSnailfish1()
        {
            var expectedResult = "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]";

            var actualResult = Day18.Snailfish.SumOfSet(_input1).ToString();

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void SumOfTwoSnailfish2()
        {
            var expectedResult = "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]";

            var sf1 = new Day18.Snailfish("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]");
            var sf2 = new Day18.Snailfish("[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]");
            
            var actualResult = sf1.Add(sf2).ToString();

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void LargestPairOf2ShouldBe3993()
        {
            var expectedResult = 3993;

            var actualResult = _day18.LargestPair(_input2);

            actualResult.Should().Be(expectedResult);
        }

        private string _input1 = @"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";

        private string _input2 = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

    }
}