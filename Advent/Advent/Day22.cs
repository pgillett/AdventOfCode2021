using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day22
    {
        public int Initialization(string input)
        {
            var list = input.Split(Environment.NewLine).Select(l => new Cube(l));

            var ons = new HashSet<(int x, int y, int z)>();

            foreach (var ins in list)
            {
                for (var x = Math.Max(ins.X.From, -50); x <= Math.Min(ins.X.To, 50); x++)
                for (var y = Math.Max(ins.Y.From, -50); y <= Math.Min(ins.Y.To, 50); y++)
                for (var z = Math.Max(ins.Z.From, -50); z <= Math.Min(ins.Z.To, 50); z++)
                {
                    if (ins.SetOn)
                        ons.Add((x, y, z));
                    else
                    {
                        ons.Remove((x, y, z));
                    }
                }
            }

            return ons.Count;
        }

        public long Reboot(string input)
        {
            var list = input.Split(Environment.NewLine).Select(l => new Cube(l));

            var cubes = new List<Cube>();
            foreach (var cube in list)
            {
                while (cubes.Any(c => c.Overlaps(cube)))
                {
                    var over = cubes.First(c => c.Overlaps(cube));
                    cubes.AddRange(over.Cut(cube));
                    cubes.Remove(over);
                }

                if (cube.SetOn)
                    cubes.Add(cube);
            }

            return cubes.Sum(c => c.On);
        }

        public class Cube
        {
            public Range X;
            public Range Y;
            public Range Z;
            public bool SetOn;

            public long On => ((long)(X.To - X.From + 1)) * (Y.To - Y.From + 1) * (Z.To - Z.From + 1);

            public Cube(Range x, Range y, Range z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public Cube(string line)
            {
                var split = line.Split(' ');
                SetOn = split[0] == "on";

                var xyz = split[1].Split(',')
                    .Select(s =>
                    {
                        var ft = s.Substring(2).Split("..");
                        return new Range(int.Parse(ft[0]), int.Parse(ft[1]));
                    }).ToArray();
                X = xyz[0];
                Y = xyz[1];
                Z = xyz[2];
            }

            public bool Overlaps(Cube c) =>
                c.X.From <= X.To && c.X.To >= X.From &&
                c.Y.From <= Y.To && c.Y.To >= Y.From &&
                c.Z.From <= Z.To && c.Z.To >= Z.From;

            public List<Cube> Cut(Cube c)
            {
                var ret = new List<Cube>();
                var fromX = X.From;
                if (c.X.From > X.From)
                {
                    ret.Add(new Cube(new Range(X.From, c.X.From - 1), Y, Z));
                    fromX = c.X.From;
                }

                var toX = X.To;
                if (c.X.To < X.To)
                {
                    ret.Add(new Cube(new Range(c.X.To + 1, X.To), Y, Z));
                    toX = c.X.To;
                }

                var rangeX = new Range(fromX, toX);

                var fromY = Y.From;
                if (c.Y.From > Y.From)
                {
                    ret.Add(new Cube(rangeX, new Range(Y.From, c.Y.From - 1), Z));
                    fromY = c.Y.From;
                }

                var toY = Y.To;
                if (c.Y.To < Y.To)
                {
                    ret.Add(new Cube(rangeX, new Range(c.Y.To + 1, Y.To), Z));
                    toY = c.Y.To;
                }

                var rangeY = new Range(fromY, toY);

                if (c.Z.From > Z.From)
                {
                    ret.Add(new Cube(rangeX, rangeY, new Range(Z.From, c.Z.From - 1)));
                }

                if (c.Z.To < Z.To)
                {
                    ret.Add(new Cube(rangeX, rangeY, new Range(c.Z.To + 1, Z.To)));
                }

                return ret;
            }
        }

        public record Range(int From, int To);
    }
}