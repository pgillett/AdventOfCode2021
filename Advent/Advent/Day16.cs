using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Advent
{
    public class Day16
    {
        public long Version(string input) => new Packets(input).Decode().version;

        public long Result(string input) => new Packets(input).Decode().value;

        private class Packets
        {
            private string _data;
            private int _pointer;
            
            public Packets(string input)
            {
                _data = input;
            }

            public (long version, long value) Decode()
            {
                var version = Get(3);
                var type = Get(3);
                if (type == 4)
                {
                    return (version, GetLiteral());
                }

                var subs = new List<(long version, long result)>();
                if (Get(1) == 0)
                {
                    var len = Get(15);
                    var endPoint = _pointer + len;
                    while (_pointer < endPoint)
                    {
                        subs.Add(Decode());
                    }
                }
                else
                {
                    var number = Get(11);
                    for (var i = 0; i < number; i++)
                        subs.Add(Decode());
                }

                var result = type switch
                {
                    0 => subs.Sum(v => v.result),
                    1 => subs.Aggregate<(long version, long result), long>(1, (current, s) => current * s.result),
                    2 => subs.Min(s => s.result),
                    3 => subs.Max(s => s.result),
                    5 => subs[0].result > subs[1].result ? 1 : 0,
                    6 => subs[0].result < subs[1].result ? 1 : 0,
                    7 => subs[0].result == subs[1].result ? 1 : 0
                };

                version += subs.Sum(v => v.version);

                return (version, result);
            }

            private long Get(int length)
            {
                var val = 0L;
                for (var i = 0; i < length; i++)
                {
                    var nibble = "0123456789ABCDEF".IndexOf(_data[_pointer / 4]);
                    val <<= 1;
                    if ((nibble & (8L >> (_pointer % 4))) != 0)
                        val++;
                    
                    _pointer++;
                }

                return val;
            }

            private long GetLiteral()
            {
                var literal = 0L;
                while (true)
                {
                    var cont = Get(1) == 1;
                    literal <<= 4;
                    literal += Get(4);
                    if (!cont)
                        break;
                }

                return literal;
            }
        }
    }
}