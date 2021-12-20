using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Advent
{
    public class Day19
    {
        public int NumberOfBeacons(string input) => Combine(input).Points.Count;

        public int LargestDistance(string input)
        {
            var beacons = Combine(input).Beacons;

            return beacons.SelectMany(b1 => beacons, Manhattan).Max();
        }

        private int Manhattan(Vector3 from, Vector3 to)
        {
            var distance = from - to;
            return (int)(Math.Abs(distance.X) + Math.Abs(distance.Y) + Math.Abs(distance.Z));
        }

        private Scanner Combine(string input)
        {
            var scanners = input.Split(Environment.NewLine + Environment.NewLine)
                .Select(s => new Scanner(s)).ToList();

            while (scanners.Count > 1)
            {
                var order = scanners.OrderBy(s => s.Points.Count).ToArray();
                for (var s1 = 0; s1 < scanners.Count - 1; s1++)
                {
                    for (var s2 = s1 + 1; s2 < scanners.Count; s2++)
                    {
                        if (order[s1].CompareAndMerge(order[s2]))
                        {
                            scanners.Remove(order[s2]);
                            s2 = scanners.Count + 1;
                            s1 = scanners.Count + 1;
                        }
                    }
                }
            }

            return scanners[0];
        }

        public class Scanner
        {
            public HashSet<Vector3> Points;
            public List<Vector3> Beacons = new();

            public Scanner(string input)
            {
                Points = input.Split(Environment.NewLine).Skip(1)
                    .Select(line =>
                {
                    var coord = line.Split(',').Select(int.Parse).ToArray();
                    return new Vector3(coord[0], coord[1], coord.Length > 2 ? coord[2] : 0);
                }).ToHashSet();
                Beacons.Add(new Vector3(0, 0, 0));
            }

            private Scanner()
            {
                Points = new HashSet<Vector3>();
            }

            public bool CompareAndMerge(Scanner second)
            {
                for (var orientation = 0; orientation < 24; orientation++)
                {
                    var scanner2 = second.Rotate(orientation);

                    var counts = new Dictionary<Vector3, int>();

                    foreach (var point1 in Points)
                    {
                        foreach (var distance in scanner2.Points.Select(point2 => point1-point2))
                        {
                            counts[distance] = counts.ContainsKey(distance) ? counts[distance] + 1 : 1;
                        }
                    }

                    var match = counts.FirstOrDefault(p => p.Value > 11);
                    if (match.Value > 11)
                    {
                        Merge(scanner2, match.Key);
                        return true;
                    }
                }

                return false;
            }
            
            private void Merge(Scanner second, Vector3 distance)
            {
                foreach (var point in second.Points)
                {
                    var relativePoint = point+distance;
                    Points.Add(relativePoint);
                }

                Beacons.AddRange(second.Beacons.Select(b => b-distance));
            }
            
            private Scanner Rotate(int orientation) => new()
            {
                    Points = Points.Select(p => Rotate(p, orientation)).ToHashSet(),
                    Beacons = Beacons.Select(p => Rotate(p, orientation)).ToList()
                };

            private Vector3 Rotate(Vector3 point, int orientation)
            {
                var X = point.X;
                var Y = point.Y;
                var Z = point.Z;
                (float x, float y, float z) = orientation switch
                {
                    0 => (X, Y, Z),
                    1 => (X, Z, -Y),
                    2 => (X, -Y, -Z),
                    3 => (X, -Z, Y),
                    4 => (-X, Y, -Z),
                    5 => (-X, -Z, -Y),
                    6 => (-X, -Y, Z),
                    7 => (-X, Z, Y),
                    8 => (-Z, Y, X),
                    9 => (-Y, -Z, X),
                    10 => (Z, -Y, X),
                    11 => (Y, Z, X),
                    12 => (Z, Y, -X),
                    13 => (Y, -Z, -X),
                    14 => (-Z, -Y, -X),
                    15 => (-Y, Z, -X),
                    16 => (-Y, X, Z),
                    17 => (Z, X, Y),
                    18 => (Y, X, -Z),
                    19 => (-Z, X, -Y),
                    20 => (Y, -X, Z),
                    21 => (Z, -X, -Y),
                    22 => (-Y, -X, -Z),
                    23 => (-Z, -X, Y)
                };
                return new Vector3(x, y, z);
            }
        }
    }
}