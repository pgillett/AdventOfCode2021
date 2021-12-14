using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day14
    {
        public long After10(string input) => Process(input, 10);

        public long After40(string input) => Process(input, 40);

        private long Process(string input, int iterations)
        {
            var split = input.Split(Environment.NewLine + Environment.NewLine);

            var template = split[0];

            var rules = split[1].Split(Environment.NewLine).Select(l =>
            {
                var s = l.Split(" -> ");
                return (s[0], s[1]);
            }).ToDictionary(l => l.Item1, l => l.Item2);

            var counts = rules.ToDictionary(r => r.Key, r => 0L);

            for (var c = 0; c < template.Length - 1; c++)
            {
                var s = template.Substring(c, 2);
                if (!counts.ContainsKey(s)) counts[s] = 0;
                counts[s]++;
            }

            var lastPair = template[^2..];

            for (var i = 0; i < iterations; i++)
            {
                var newCounts = new Dictionary<string, long>(counts);
                foreach (var (pair, insert) in rules)
                {
                    newCounts[pair] -= counts[pair];
                    var new1 = pair[0] + insert;
                    var new2 = insert + pair[1];
                    newCounts[new1] += counts[pair];
                    newCounts[new2] += counts[pair];
                }

                lastPair = rules[lastPair] + lastPair[1];

                counts = newCounts;
            }

            counts[lastPair[1] + "-"] = 1;

            var group = counts.GroupBy(c => c.Key[0]).Select(g => (g.Key, g.Sum(c => c.Value))).ToArray()
                .OrderBy(k => k.Item2).ToArray();

            return group.Last().Item2 - group.First().Item2;
        }
    }
}