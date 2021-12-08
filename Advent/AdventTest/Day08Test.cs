using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day08Test
    {
        private Day08 _day08;

        [TestInitialize]
        public void Setup()
        {
            _day08 = new Day08();
        }
        
        [TestMethod]
        public void Numbers1478ShouldBe26()
        {
            var expectedResult = 26;

            var actualResult = _day08.Numbers1478(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void AllNumbersShouldBe61229()
        {
            var expectedResult = 61229;

            var actualResult = _day08.AllNumbers(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void SingleItemShouldBe5353()
        {
            var expected = 5353;

            var actualResult =
                _day08.AllNumbers("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");

            actualResult.Should().Be(expected);
        }
        
        private string _input = @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce";

    }
}