using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day06
    {
        public long FishAfter80(string input) => TotalFish(input, 80);
        public long FishAfter256(string input) => TotalFish(input, 256);
        
        private long TotalFish(string input, int days)
        {
            var fish = input.Split(',').Select(int.Parse).ToArray();

            var totals = new Dictionary<int, long>();

            for (var startDay = days; startDay >= -9; startDay--)
            {
                var thisFish = 8;
                long inner = 1;
                for (var i = startDay + 1; i <= days; i++)
                {
                    thisFish--;
                    if (thisFish < 0)
                    {
                        thisFish = 6;
                        inner += totals[i];
                    }
                }

                totals[startDay] = inner;
            }

            return fish.Sum(f => totals[f - 8]);
        }
    }
}