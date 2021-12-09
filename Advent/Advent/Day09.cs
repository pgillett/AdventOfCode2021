using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Advent
{
    public class Day09
    {
        public int Risk(string input) => new Map(input).CountLows;

        public int ThreeLargest(string input) => new Map(input).BasinTotal();

        private class Map
        {
            private List<(int X, int Y)> _lowPoints = new ();
            private int[][] _map;

            private int MaxX => _map[0].Length;
            private int MaxY => _map.Length;

            public Map(string input)
            {
                _map = input.Split(Environment.NewLine)
                    .Select(l => l.Select(c => (int)(c - '0')).ToArray()).ToArray();

                for (var y = 0; y < MaxY; y++)
                for (var x = 0; x < MaxX; x++)
                {
                    if (_round.All(r => Height(x, y) < Height(x + r.X, y + r.Y))) _lowPoints.Add((x, y));
                }
            }

            private (int X, int Y)[] _round = { (-1, 0), (1, 0), (0, -1), (0, 1)};
            
            private int Height(int x, int y) => x >= 0 && x < MaxX && y >= 0 && y < MaxY
                ? _map[y][x] : 10;

            public int CountLows => _lowPoints.Sum(p => Height(p.X, p.Y) + 1);

            public int BasinTotal()
            {
                var basins = new List<int>();
                foreach (var low in _lowPoints)
                {
                    var basin = 0;
                    var queue = new Queue<(int X, int Y)>();
                    var used = new HashSet<(int, int)>();
                    queue.Enqueue(low);
                    while (queue.Count > 0)
                    {
                        var p = queue.Dequeue();
                        var h = Height(p.X, p.Y);
                        
                        if (h < 9 && !used.Contains(p))
                        {
                            used.Add(p);
                            basin++;
                            foreach (var r in _round)
                            {
                                var rx = p.X + r.X;
                                var ry = p.Y + r.Y;
                                if (Height(rx, ry) > h) queue.Enqueue((rx, ry));
                            }
                        }
                    }
                
                    basins.Add(basin);
                }

                return basins.OrderByDescending(b => b).Take(3).Aggregate(1, (current, s) => current * s);
            }
        }
        
    }
}