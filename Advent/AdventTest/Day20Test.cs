using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day20est
    {
        private Day20 _day20;

        [TestInitialize]
        public void Setup()
        {
            _day20 = new Day20();
        }
        
        [TestMethod]
        public void After2ShouldBe35()
        {
            var expectedResult = 35;

            var actualResult = _day20.TwoEnhances(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void After50ShouldBe3351()
        {
            var expectedResult = 3351;

            var actualResult = _day20.FiftyEnhances(_input);

            actualResult.Should().Be(expectedResult);
        }
        
        // 5662 is too high
        
        private string _input = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";

    }
}