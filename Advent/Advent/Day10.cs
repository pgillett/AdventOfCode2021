using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day10
    {
        public int Corrupt(string input) => 
            input.Split(Environment.NewLine).Sum(l => Process(l).illegalScore);
        
        public long Incomplete(string input)
        {
            var scores = input.Split(Environment.NewLine)
                .Select(Process)
                .Where(p => p.illegalScore == 0 && p.autoCompletes.Length > 0)
                .Select(line => line.autoCompletes
                    .Aggregate<int, long>(0, (current, score) =>
                        current * 5 + score))
                .ToArray();

            return scores.OrderBy(s => s).ElementAt((scores.Length - 1) / 2);
        }

        private (int[] autoCompletes, int illegalScore) Process(string line)
        {
            var stack = new Stack<Bracket>();
            foreach (var c in line)
            {
                if (stack.Count > 0 && stack.Peek().Close == c)
                    stack.Pop();
                else
                {
                    var open = _brackets.SingleOrDefault(b => b.Open == c);
                    if (open != null)
                        stack.Push(open);
                    else
                        return (null, _brackets.Single(b => b.Close == c).Illegal);
                }
            }

            return (stack.Select(b => b.AutoComplete).ToArray(), 0);
        }
        
        private static Bracket[] _brackets = {
            new('(', ')', 3, 1),
            new('[', ']', 57, 2),
            new('{', '}', 1197, 3),
            new('<', '>', 25137, 4)
        };
        
        private record Bracket(char Open, char Close, int Illegal, int AutoComplete);
    }
}