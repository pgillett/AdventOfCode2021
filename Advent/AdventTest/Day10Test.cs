using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day10Test
    {
        private Day10 _day10;

        [TestInitialize]
        public void Setup()
        {
            _day10 = new Day10();
        }
        
        [TestMethod]
        public void IllegalScoreShouldBe26397()
        {
            var expectedResult = 26397;

            var actualResult = _day10.Corrupt(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void AutoCompleteScoreShouldBe288957()
        {
            var expectedResult = 288957;

            var actualResult = _day10.Incomplete(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

    }
}