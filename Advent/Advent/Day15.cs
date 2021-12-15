using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day15
    {
        public int Shortest(string input) => Process(input, 1);
        
        public int ShortestFive(string input) => Process(input, 5);

        private int Process(string input, int size)
        {
            var map = input.Split(Environment.NewLine)
                .Select(l => l.Select(c => c - '0').ToArray())
                .ToArray();

            var subX = map.Length;
            var subY = map[0].Length;
            var maxX = subX * size;
            var maxY = subY * size;

            var distances = new int[maxX, maxY];

            var queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                var around = Around(x, y, maxX, maxY);
                var shortest = around
                    .Select(p => distances[p.x, p.y])
                    .Where(d => d > 0).DefaultIfEmpty().Min(d => d);

                shortest += ((map[y % subY][x % subX] + (y / subY) + (x / subX)) - 1) % 9 + 1;

                if (distances[x, y] == 0 || shortest < distances[x, y])
                {
                    distances[x, y] = shortest;
                    foreach (var (nx, ny) in around)
                    {
                        queue.Enqueue((nx, ny));
                    }
                }
            }

            return distances[maxX - 1, maxY - 1] - distances[0, 0];
        }

        private (int dx, int dy)[] Deltas = { (1, 0), (-1, 0), (0, 1), (0, -1) };

        private (int x, int y)[] Around(int x, int y, int maxX, int maxY) =>
            Deltas
                .Select((d) => (x + d.Item1, y + d.Item2))
                .Where(d => d.Item1 >= 0 && d.Item1 < maxX && d.Item2 >= 0 && d.Item2 < maxY)
                .ToArray();
    }
}