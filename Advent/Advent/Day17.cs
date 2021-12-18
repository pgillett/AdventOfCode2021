using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day17a
    {
        public int Calc1(string input) => Process(input).maxHeight;

        public int Calc2(string input) => Process(input).hits;

        private bool InRange(int p, (int, int) range) => p >= range.Item1 && p <= range.Item2;
        
        private (bool hit, int height) Fire(int xv, int yv, (int, int) xRange, (int, int) yRange)
        {
            var x = 0;
            var y = 0;
            var my = 0;
            while (true)
            {
                x += xv;
                y += yv;
                my = Math.Max(my, y);
                if (xv > 0) xv--;
                yv--;
                if (InRange(x, xRange) && InRange(y, yRange))
                    return (true, my);

                if (xv >= 0 && x > xRange.Item2) return (false, 0);
                if (xv <= 0 && x < xRange.Item1) return (false, 0);
                if (yv < yRange.Item1) return (false, 0);
            }
        }
        
        private (int hits, int maxHeight) Process(string input)
        {
            input = input.Replace("target area: ", "");
            var split = input.Split(", ");

            var xRange = SplitPair(split[0]);
            var yRange = SplitPair(split[1]);

            var maxHeight = 0;
            var hits = 0;
            for (var x = 0; x <= xRange.Item2; x++)
            {
                for (var y = yRange.Item1; y < 1000; y++)
                {
                    var result = Fire(x, y, xRange, yRange);
                    if (result.hit)
                    {
                        maxHeight = Math.Max(maxHeight, result.height);
                        hits++;
                    }
                }
            }

            return (hits, maxHeight);
        }

        private (int, int) SplitPair(string input)
        {
            var split1 = input.Split("=");
            var split2 = split1[1].Split("..");
            return (int.Parse(split2[0]), int.Parse(split2[1]));
        }
    }
}