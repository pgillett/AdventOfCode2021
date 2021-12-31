using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day24
    {
        public long Highest(string input) => Result(input, true);

        public long Lowest(string input) => Result(input, false);

        private long Result(string input, bool highest)
        {
            var split = input.Split("inp", StringSplitOptions.RemoveEmptyEntries);
            var sec = split.Select(GetSection).ToArray();

            var res = new Dictionary<long, long>();
            res[0] = 0;

            var start = highest ? 1 : 9;
            var end = highest ? 10 : 0;
            var dir = highest ? 1 : -1;
            for (var i = 0; i < 14; i++)
            {
                var res2 = new Dictionary<long, long>();
                var div26 = sec[i].div26;
                var add1 = sec[i].add1;
                var add2 = sec[i].add2;
                foreach (var (oldZ, serial) in res)
                {
                    var ts = serial * 10;
                    for (var c = start; c != end; c+=dir)
                    {
                        var p = Compute(c, oldZ, div26, add1, add2);
                        res2[p] = ts+c;
                    }
                }
                res = res2;
            }

            return res[0];
        }

        public (bool div26, int add1, int add2) GetSection(string input)
        {
            var split = input.Split(Environment.NewLine);
            // Lines 4, 5, 15

            var div26 = GetEndOf(split[4]) == 26;
            var add1 = GetEndOf(split[5]);
            var add2 = GetEndOf(split[15]);
            return (div26, add1, add2);
        }

        private int GetEndOf(string input) => int.Parse(input.Split(' ').Last());
        
        public long Compute(int w, long oldZ, bool div26, int add1, int add2)
        {
            if (div26)
            {
                return ((oldZ % 26) + add1 != w)
                    ? (oldZ / 26) * 26 + add2 + w
                    : oldZ / 26;
            }

            return ((oldZ % 26) + add1 != w)
                ? oldZ * 26 + add2 + w
                : oldZ;
        }
        
        // Old ALU code to test compute method

        public class ALU
        {
            public long[] Registers = new long[4];

            public string RegText => $"w = {Registers[0]} x = {Registers[1]} y = {Registers[2]} z = {Registers[3]}";
            
            public string Input;

            public ALU(string input)
            {
                Input = input;
            }

            public ALU(long input)
            {
                Input = $"{input}";
            }
            
            public void Process(string[] instructions)
            {
                foreach (var instruction in instructions)
                {
                    Process(instruction);
                }
            }

            public void Process(string instruction)
            {
                var split = instruction.Split(' ');
                var reg1 = split[1][0] - 'w';
                long reg2 = 0;
                if(split.Length==3)
                    if ("wxyz".Contains(split[2][0]))
                        reg2 = Registers[split[2][0] - 'w'];
                    else
                    {
                        reg2 = int.Parse(split[2]);
                    }
                switch (split[0])
                {
                    case "inp":
                        Registers[reg1] = Input[0] - '0';
                        Input = Input.Substring(1);
                        break;
                    case "add":
                        Registers[reg1] = Registers[reg1] + reg2;
                        break;
                    case "mul":
                        Registers[reg1] = Registers[reg1] * reg2;
                        break;
                    case "div":
                        Registers[reg1] = Registers[reg1] / reg2;
                        break;
                    case "mod":
                        Registers[reg1] = Registers[reg1] % reg2;
                        break;
                    case "eql":
                        Registers[reg1] = Registers[reg1] == reg2 ? 1 : 0;
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
    }
}