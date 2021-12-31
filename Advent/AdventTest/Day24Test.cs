using System;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day24Test
    {
        private Day24 _day24;

        [TestInitialize]
        public void Setup()
        {
            _day24 = new Day24();
        }

        [TestMethod]
        public void ComputeIsSameAsALU()
        {
            var sec1 = _day24.GetSection(_input4);
            var sec2 = _day24.GetSection(_input5);
            var lines1 = _input4.Split(Environment.NewLine);
            var lines2 = _input5.Split(Environment.NewLine);

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        var ali = new Day24.ALU($"{i}{j}{k}");
                        ali.Process(lines1);
                        ali.Process(lines2);
                        ali.Process(lines1);

                        var z = _day24.Compute(i, 0, sec1.div26, sec1.add1, sec1.add2);
                        z = _day24.Compute(j, z, sec2.div26, sec2.add1, sec2.add2);
                        z = _day24.Compute(k, z, sec1.div26, sec1.add1, sec1.add2);

                        z.Should().Be(ali.Registers[3]);
                    }
                }
            }
        }

        [TestMethod]
        public void NegateTest()
        {
            var expectedResult = -5;

            var ali = new Day24.ALU(5);
            ali.Process(_input.Split(Environment.NewLine));

            var actualResult = ali.Registers[1];

            actualResult.Should().Be(expectedResult);
        }
        
        [TestMethod]
        [DataRow("39", 1)]
        [DataRow("26", 1)]
        [DataRow("25", 0)]
        public void ThreeTimesTest(string input, int expectedResult)
        {
            var ali = new Day24.ALU(input);
            ali.Process(_input2.Split(Environment.NewLine));

            var actualResult = ali.Registers[3];

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow("5", "0101")]
        [DataRow("9", "1001")]
        [DataRow("2", "0010")]
        public void BinaryTest(string input, string expectedResult)
        {
            var ali = new Day24.ALU(input);
            ali.Process(_input3.Split(Environment.NewLine));

            var actualResult = $"{ali.Registers[0]}{ali.Registers[1]}{ali.Registers[2]}{ali.Registers[3]}";

            actualResult.Should().Be(expectedResult);
        }
        
        private string _input = @"inp x
mul x -1";

        private string _input2 = @"inp z
inp x
mul z 3
eql z x";

        private string _input3 = @"inp w
add z w
mod z 2
div w 2
add y w
mod y 2
div w 2
add x w
mod x 2
div w 2
mod w 2";

        private string _input4 = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y";

        private string _input5 = @"inp w
mul x 0
add x z
mod x 26
div z 26
add x 5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y";
    }
}