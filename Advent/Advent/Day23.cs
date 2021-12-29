using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Advent
{
    public class Day23
    {
        public int Folded(string input) => Shortest(input, false);
        public int Unfolded(string input) => Shortest(input, true);
        
        public int Shortest(string input, bool unfold)
        {
            var rows = input.Split(Environment.NewLine);

            var shortest = 0;

            var seen = new Dictionary<string, MapLayout>();

            var queue = new Queue<MapLayout>();
            queue.Enqueue(new MapLayout(rows, unfold));

            while (queue.Count > 0)
            {
                var next = queue.Dequeue();

                foreach (var move in next.Moves())
                {
                    if (move.Complete)
                    {
                        if (shortest == 0 || move.Energy < shortest)
                        {
                            shortest = move.Energy;
                        }
                    }
                    else
                    {
                        if (!seen.TryGetValue(move.Map, out var current) || current.Energy > move.Energy)
                        {
                            seen[move.Map] = move;
                            queue.Enqueue(move);
                        }
                    }
                }
            }

            return shortest;
        }
        
        public class MapLayout
        {
            public string Map;
            public int Energy;

            private MapLayout(string map, int energy)
            {
                Map = map;
                Energy = energy;
            }
            
            public MapLayout(string[] rows, bool unfold)
            {
                Map = rows[1].Substring(1, 11);
                for (var r = 0; r < 2; r++)
                    foreach (var c in new[] { 3, 5, 7, 9 })
                    {
                        Map += rows[r + 2][c];
                    }

                Map = unfold
                    ? Map.Substring(0, 11 + 4) + "DCBADBAC" + Map.Substring(11 + 4) 
                    : Map + "ABCDABCD";
            }

            public bool Complete => Map == "...........ABCDABCDABCDABCD";

            private bool InHomeWithSameBelow(int a, int pos, int amp)
            {
                if (pos < 11) return false;
                if ((pos - 11) % 4 != a) return false;
                while (pos <= 22)
                {
                    pos += 4;
                    if (Map[pos] != amp) return false;
                }

                return true;
            }
            
            private bool BlockedInRoom(int pos) => pos >= 15 && Map[pos - 4] != '.';
            
            private static int[] Positions = { 0, 1, 3, 5, 7, 9, 10 };

            private char Room(int amp, int row) => Map[RoomIndex(amp, row)];
            private int RoomIndex(int amp, int row) => amp + 11 + 4 * row;
            private int RoomColumn(int i) => ((i - 11) % 4) * 2 + 2;
            private int WhichRow(int i) => (i - 11) / 4;

            public List<MapLayout> Moves()
            {
                var ret = new List<MapLayout>();
                for (var a = 0; a < 4; a++)
                for (var l = 0; l < 4; l++)
                {
                    var ampChar = (char)('A' + a);
                    var i = -1;
                    for (var o = 0; o <= l; o++)
                        i = Map.IndexOf(ampChar, i + 1);

                    if (InHomeWithSameBelow(a, i, ampChar))
                    {
                        // Already in place
                    }
                    else if (BlockedInRoom(i))
                    {
                        // Something in the way
                    }
                    else
                    {
                        var p = i < 11 ? i : RoomColumn(i);
                        var moves = (i < 11 ? 0 : WhichRow(i) + 1);
                        var leaveRoom = i >= 11;
                        
                        if (Room(a, 0) == '.')
                        {
                            var target = a * 2 + 2;
                            if (p < target ? IsPathClear(p + 1, target) : IsPathClear(target, p - 1))
                            {
                                moves += Math.Abs(p - target);
                                var energy = (int)Math.Pow(10, a);
                                for (var r = 3; r >= 0; r--)
                                {
                                    if (Room(a, r) == '.')
                                    {
                                        energy = energy * (moves + r + 1);
                                        ret.Add(Updated(i, RoomIndex(a, r), ampChar, energy));
                                        leaveRoom = false;
                                    }

                                    if (Room(a, r) != ampChar)
                                        break;
                                }
                            }
                        }

                        if (leaveRoom)
                        {
                            foreach (var t in Positions)
                            {
                                if (p != t)
                                {
                                    if (p < t ? IsPathClear(p + 1, t) : IsPathClear(t, p - 1))
                                    {
                                        var energy = 1 * (int)Math.Pow(10, a) * (Math.Abs(p - t) +
                                            (WhichRow(i) + 1));
                                        ret.Add(Updated(i, t, ampChar, energy));
                                    }
                                }
                            }
                        }
                    }
                }

                return ret;
            }

            private MapLayout Updated(int oldPos, int newPos, char amp, int energy)
            {
                var charArray = Map.ToCharArray();
                charArray[oldPos] = '.';
                charArray[newPos] = amp;
                return new MapLayout(new string(charArray), Energy + energy);
            }

            private bool IsPathClear(int from, int to)
            {
                for (; from <= to; from++)
                    if (Map[from] != '.')
                        return false;
                return true;
            }
        }
    }
}