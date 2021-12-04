using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day03
    {
        public int Power(string input)
        {
            var lines = input.Split(Environment.NewLine).Select(s => s.Trim()).ToArray();

            var cols = lines[0].Length;
            
            var half = lines.Length / 2;

            var bits = "";
            for (var b = 0; b < cols; b++)
            {
                var tot = lines.Count(l => l[b] == '1');
                bits += (tot > half ? '1' : '0');
            }

            var gamma = BinToInt(bits);
            var epsilon = BinToInt(bits.Select(b => b == '1' ? '0' : '1'));

            return gamma * epsilon;
        }

        public int Life(string input)
        {
            var lines = input.Split(Environment.NewLine).Select(s => s.Trim()).ToArray();

            var oxygen = Rating(lines, '1', '0');
            var co2 = Rating(lines, '0', '1');
            return oxygen * co2;
        }

        private int Rating(string[] lines, char greater, char less)
        {
            var left = lines;
            var cols = lines[0].Length;
            for (var b = 0; b < cols && left.Length > 1; b++)
            {
                var tot = left.Count(l => l[b] == '1');
                var find = 2 * tot >= left.Length ? greater : less;
                left = left.Where(l => l[b] == find).ToArray();
            }

            return BinToInt(left[0]);  
        }

        private int BinToInt(IEnumerable<char> bits) => bits.Aggregate(0, (current, b) => (current << 1) + (b == '1' ? 1 : 0));
    }
}