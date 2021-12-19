using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day18
    {
        public int MagnitudeAll(string input)
        {
            var sum = Snailfish.SumOfSet(input);
            return sum.Magnitude();
        }

        public int LargestPair(string input)
        {
            var set = input.Split(Environment.NewLine).ToArray();

            var max = 0;
            for (var i = 0; i < set.Length; i++)
            {
                for (var j = 0; j < set.Length; j++)
                {
                    if (i != j)
                    {
                        var mag = new Snailfish(set[i]).Add(new Snailfish(set[j])).Magnitude();
                        max = Math.Max(max, mag);
                    }
                }
            }
            
            return max;
        }

        public class Snailfish
        {
            private List<int> _tokens = new List<int>();
            private const int Open = -1;
            private const int Close = -2;
            private const int Comma = -3;

            public Snailfish(string input)
            {
                foreach (var c in input)
                {
                    _tokens.Add(c switch
                    {
                        '[' => Open,
                        ']' => Close,
                        ',' => Comma,
                        _ => c - '0'
                    });
                }
            }

            private Snailfish()
            {
                
            }

            public override string ToString()
            {
                var str = "";
                foreach (var token in _tokens)
                {
                    str += token switch
                    {
                        Open => "[",
                        Close => "]",
                        Comma => ",",
                        _ => token.ToString()
                    };
                }

                return str;
            }

            public Snailfish Add(Snailfish toAdd)
            {
                var sn = new Snailfish();
                sn._tokens.Add(Open);
                sn._tokens.AddRange(_tokens);
                sn._tokens.Add(Comma);
                sn._tokens.AddRange(toAdd._tokens);
                sn._tokens.Add(Close);
                sn.Reduce();
                return sn;
            }

            public void Reduce()
            {
                var cont = true;
                while (cont)
                {
                    var depth = 0;
                    cont = false;
                    for (var t = 0; t < _tokens.Count; t++)
                    {
                        if (_tokens[t] == Open) depth++;
                        if (_tokens[t] == Close) depth--;
                        if (depth == 5)
                        {
                            var l = _tokens[t + 1];
                            var r = _tokens[t + 3];
                            ScanReplace(t + 5, 1, r);
                            _tokens.RemoveRange(t + 1, 4);
                            _tokens[t] = 0;
                            ScanReplace(t - 1, -1, l);
                            cont = true;
                            break;
                        }
                    }

                    if (!cont)
                    {
                        var t = _tokens.FindIndex(p => p >= 10);
                        {
                            if (t >= 0)
                            {
                                var nl = _tokens[t] / 2;
                                var nr = ((_tokens[t] + 1) / 2);

                                _tokens[t] = Open;
                                _tokens.InsertRange(t + 1, new[] { nl, Comma, nr, Close });

                                cont = true;
                            }
                        }
                    }
                }
            }

            private void ScanReplace(int t, int dir, int val)
            {
                t = dir > 0
                    ? _tokens.FindIndex(t, p => p >= 0)
                    : _tokens.FindLastIndex(t, p => p >= 0);

                if (t >= 0) _tokens[t] += val;
            }

            public int Magnitude() => Magnitude(0, _tokens.Count);

            private int Magnitude(int from, int to)
            {
                if (to - from == 1) return _tokens[from];
                
                var t = from;
                var depth = 0;
                while (_tokens[t] != Comma || depth != 1)
                {
                    if (_tokens[t] == Open) depth++;
                    if (_tokens[t] == Close) depth--;
                    t++;
                }

                var left = Magnitude(from + 1, t);
                var right = Magnitude(t + 1, to - 1);
                return 3 * left + 2 * right;
            }
            
            public static Snailfish SumOfSet(string input)
            {
                var sf = input.Split(Environment.NewLine).ToArray();

                var current = new Snailfish(sf[0]);
                foreach (var s in sf.Skip(1))
                {
                    current = current.Add(new Snailfish(s));
                }

                return current;
            }
        }
    }
}