using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Advent
{
    public class Day05
    {
        public int VentsExcluding(string input)
        {
            return Calc(input, false);
        }
        
        public int VentsIncluding(string input)
        {
            return Calc(input, true);
        }
        
        private int Calc(string input, bool include)
        {
            var vents = input.Split(Environment.NewLine).Select(l => new Vent(l));

            if (!include)
                vents = vents.Where(v => v.IsHorizVert);

            var map = new Dictionary<Point, int>();
            
            foreach (var vent in vents)
            {
                var point = vent.From;
                map[point] = map.ContainsKey(point) ? map[point] + 1 : 1;

                while (point != vent.To)
                {
                    point = vent.Towards(point);
                    map[point] = map.ContainsKey(point) ? map[point] + 1 : 1;
                }
            }

            return map.Values.Count(m => m >= 2);
        }

        private class Vent
        {
            public Point From;
            public Point To;

            public Point Towards(Point old) => new(old.X + DeltaX, old.Y + DeltaY);

            private int DeltaX;
            private int DeltaY;

            public bool IsHorizVert => DeltaX == 0 || DeltaY == 0;

            public Vent(string line)
            {
                var split1 = line.Split(" -> ");
                From = SplitPoint(split1[0]);
                To = SplitPoint(split1[1]);

                DeltaX = To.X > From.X ? 1 : To.X == From.X ? 0 : -1;
                DeltaY = To.Y > From.Y ? 1 : To.Y == From.Y ? 0 : -1;
            }

            private Point SplitPoint(string point)
            {
                var xy = point.Split(',').Select(int.Parse).ToArray();
                return new Point(xy[0], xy[1]);
            }
        }
    }
}