using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Advent
{
    public class Day20
    {
        public int TwoEnhances(string input) => LitAfter(input, 2);

        public int FiftyEnhances(string input) => LitAfter(input, 50);

        private int LitAfter(string input, int loops)
        {
            var split = input.Split(Environment.NewLine);
            var enhance = split[0];
            var image = new Image(split.Skip(2).ToArray());

            for (var i = 0; i < loops; i++)
            {
                image = image.Enhance(enhance);
            }

            return image.NumberLit;
        }

        public class Image
        {
            private HashSet<(int, int)> _inputLit = new();
            private bool _outside;
            private Point _from;
            private Point _to;

            public int NumberLit => _inputLit.Count;

            public Image(string[] map)
            {
                for (var y = 0; y < map.Length; y++)
                for (var x = 0; x < map[0].Length; x++)
                {
                    if (map[y][x] == '#') _inputLit.Add((x, y));
                }

                _from = new Point(0, 0);
                _to = new Point(map[0].Length, map.Length);
            }

            private Image()
            {
                
            }

            private bool LightAt(int xc, int yc) =>
                xc >= _from.X && xc < _to.X && yc >= _from.Y && yc < _to.Y
                    ? _inputLit.Contains((xc, yc))
                    : _outside;

            public Image Enhance(string enhance)
            {
                var output = new HashSet<(int, int)>();

                for (var y = _from.Y - 1; y < _to.Y + 1; y++)
                {
                    for (var x = _from.X - 1; x < _to.X + 1; x++)
                    {
                        var bin = 0;
                        for (var c = 0; c < 9; c++)
                        {
                            var xc = x + (c % 3) - 1;
                            var yc = y + (c / 3) - 1;
                            bin = (bin << 1) + (LightAt(xc, yc) ? 1 : 0);
                        }

                        if (enhance[bin] == '#')
                        {
                            output.Add((x, y));
                        }
                    }
                }

                return new Image()
                {
                    _inputLit = output,
                    _outside = enhance[_outside ? 511 : 0] == '#',
                    _from = new Point(_from.X - 1, _from.Y - 1),
                    _to = new Point(_to.X + 1, _to.Y + 1)
                };
            }
        }
    }
}