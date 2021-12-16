using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day16Test
    {
        private Day16 _day16;

        [TestInitialize]
        public void Setup()
        {
            _day16 = new Day16();
        }
        
        [TestMethod]
        [DataRow("8A004A801A8002F478", 16)]
        [DataRow("620080001611562C8802118E34", 12)]
        [DataRow("C0015000016115A2E0802F182340", 23)]
        [DataRow("A0016C880162017C3686B18A3D4780", 31)]
        public void VersionShouldBeCorrect(string input, long expectedResult)
        {
            var actualResult = _day16.Version(input);

            actualResult.Should().Be(expectedResult);
        }

        [DataRow("C200B40A82", 3)]
        [DataRow("04005AC33890", 54)]
        [DataRow("880086C3E88112", 7)]
        [DataRow("CE00C43D881120", 9)]
        [DataRow("D8005AC2A8F0", 1)]
        [DataRow("F600BC2D8F", 0)]
        [DataRow("9C005AC2F8F0", 0)]
        [DataRow("9C0141080250320F1802104A08", 1)]
        [TestMethod]
        public void ResultShouldBeCorrect(string input, long expectedResult)
        {
            var actualResult = _day16.Result(input);

            actualResult.Should().Be(expectedResult);
        }
    }
}