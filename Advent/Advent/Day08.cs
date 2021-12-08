using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day08
    {
        public int Numbers1478(string input)
        {
            var lines = input
                .Split(Environment.NewLine)
                .Select(SplitLine)
                .ToArray();
            
            return lines.Sum(l => l.Item2.Count(s => s.Is1478));
        }
        
       
        public int AllNumbers(string input)
        {
            var lines = input
                .Split(Environment.NewLine)
                .Select(SplitLine)
                .ToArray();

            var total = 0;
            
            //  a
            // b c
            //  d
            // e f
            //  g
            
            foreach (var (sample, display) in lines)
            {
                var numbers = new Segment[10];
                numbers[1] = sample.Single(s => s.Length == 2);
                numbers[7] = sample.Single(s => s.Length == 3);
                numbers[4] = sample.Single(s => s.Length == 4);
                numbers[8] = sample.Single(s => s.Length == 7);
                var bd = numbers[4].Remove(numbers[1]); // Are in 4 but not 1
                numbers[0] = sample.Single(s => s.Length ==6 && !s.Contains(bd)); // Only 6 seg that doesn't have b & d
                var d = numbers[4].Remove(numbers[0]); // In 4 but not 0
                var b = bd & ~d;
                numbers[5] = sample.Single(s => s.Length == 5 && s.Contains(b));
                {
                    var sixes = sample.Where(s => s.Length == 6).ToList(); // 0 6 9
                    sixes.Remove(numbers[0]); // Already got 0
                    numbers[9] = sixes.Single(s => s.Contains(numbers[4])); // 9 contains 4
                    sixes.Remove(numbers[9]); // Remove 9
                    numbers[6] = sixes[0]; // Other one must be 6
                }
                {
                    var fives = sample.Where(s => s.Length == 5).ToList(); // 2 3 5
                    fives.Remove(numbers[5]); // Already got 5
                    numbers[3] = fives.Single(s => s.Contains(numbers[1])); // Only 3 contains 1's segs
                    fives.Remove(numbers[3]); // Remove 3
                    numbers[2] = fives[0]; // Other one must be 2
                }

                total += Display(numbers.Select(s => s.Bits).ToArray(), display);
            }

            return total;
        }

        private int Display(int[] numbers, Segment[] display) => 
            display.Aggregate(0, (current, seg) => current * 10 + Array.IndexOf(numbers, seg.Bits));

        private (Segment[], Segment[]) SplitLine(string input)
        {
            var sides = input.Split(" | ").Select(s => s.Split(' ').Select(seg => new Segment(seg)).ToArray()).ToArray();
            return (sides[0], sides[1]);
        }

        private class Segment
        {
            public int Bits;

            public int Length;

            public bool Is1478 => new[] { 2, 3, 4, 7 }.Contains(Length);

            public bool Contains(Segment seg) => Contains(seg.Bits);
            
            public bool Contains(int con) => (Bits & con) == con;

            public int Remove(Segment seg) => Bits & (~ seg.Bits);
            
            public Segment(string input)
            {
                Bits = input.Sum(c => 1 << (c - 'a'));
                Length = input.Length;
            }
        }
    }
}