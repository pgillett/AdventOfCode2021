using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day11
    {
        public int After100(string input)
        {
            var grid = new Octopus(input);

            var total = 0;
            for (int i = 0; i < 100; i++)
            {
                var result = grid.Process();
                total += result;
            }

            return total;
        }

        public int Synchronise(string input)
        {
            var grid = new Octopus(input);

            var count = 0;
            while (grid.Process() != grid.Total)
                count++;

            return count+1;
        }
       
        private class Octopus
        {
            private int[][] Energy;
            private int MaxX;
            private int MaxY;
            public int Total => MaxX * MaxY;

            public Octopus(string input)
            {
                Energy = input.Split(Environment.NewLine)
                    .Select(l => l.Select(c => c - '0').ToArray()).ToArray();
                MaxX = Energy[0].Length;
                MaxY = Energy.Length;
            }

            public int Process()
            {
                var queue = new Queue<(int x, int y)>();

                for (var y = 0; y < MaxY; y++)
                {
                    for (var x = 0; x < MaxX; x++)
                        queue.Enqueue((y, x));
                }

                while (queue.Count > 0)
                {
                    var (y, x) = queue.Dequeue();
                    Energy[y][x]++;
                    if (Energy[y][x] == 10)
                    {
                        for (var dy = -1; dy <= 1; dy++)
                        for (var dx = -1; dx <= 1; dx++)
                        {
                            if (dy != 0 || dx != 0)
                            {
                                var nx = x + dx;
                                var ny = y + dy;
                                if (nx >= 0 && nx < MaxX && ny >= 0 && ny < MaxY)
                                    queue.Enqueue((ny, nx));
                            }
                        }
                    }
                }

                var flashes = 0;
                for (var y = 0; y < MaxY; y++)
                for (var x = 0; x < MaxX; x++)
                    if (Energy[y][x] > 9)
                    {
                        Energy[y][x] = 0;
                        flashes++;
                    }

                return flashes;
            }
        }
    }
}