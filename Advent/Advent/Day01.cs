using System;
using System.Linq;

namespace Advent
{
    public class Day01
    {
        public int Increases(string input) => Count(input, 1);

        public int SlidingIncreases(string input) => Count(input, 3);

        private int Count(string input, int distance)
        {
            var values = input
                .Split(Environment.NewLine)
                .Select(s => int.Parse(s))
                .ToArray();

            return values
                .Skip(distance)
                .Zip(values, (s, f) => new {f, s})
                .Count(l => l.s > l.f);
        }
    }
}