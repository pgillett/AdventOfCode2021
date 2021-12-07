using System;
using System.Linq;

namespace Advent
{
    public class Day07
    {
        public int ConstantFuel(string input) => CalcFuel(input, i => i);

        public int IncreasingFuel(string input) => CalcFuel(input, i => i * (i + 1) / 2);
        
        private int CalcFuel(string input, Func<int, int> fuelMove)
        {
            var crabs = input.Split(',').Select(int.Parse).ToArray();

            return Enumerable.Range(crabs.Min(), crabs.Max())
                .Select(i => crabs.Sum(c => fuelMove(Math.Abs(c - i))))
                .Min();
        }
    }
}