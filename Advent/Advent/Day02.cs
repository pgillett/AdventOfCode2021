using System;
using System.Linq;

namespace Advent
{
    public class Day02
    {
        public int Move(string input)
        {
            var moves = Parse(input);

            var horiz = 0;
            var vert = 0;

            foreach (var move in moves)
            {
                switch (move.Direction)
                {
                    case "forward":
                        horiz += move.Distance;
                        break;
                    case "down":
                        vert += move.Distance;
                        break;
                    case "up":
                        vert -= move.Distance;
                        break;
                    default:
                        throw new Exception("Bad direction");
                }
            }

            return horiz * vert;
        }
        
        public int Aim(string input)
        {
            var moves = Parse(input);

            var horiz = 0;
            var vert = 0;
            var aim = 0;

            foreach (var move in moves)
            {
                switch (move.Direction)
                {
                    case "forward":
                        horiz += move.Distance;
                        vert += move.Distance * aim;
                        break;
                    case "down":
                        aim += move.Distance;
                        break;
                    case "up":
                        aim -= move.Distance;
                        break;
                    default:
                        throw new Exception("Bad direction");
                }
            }

            return horiz * vert;
        }

        private record Instruction(string Direction, int Distance);
        
        private Instruction[] Parse(string input) => input
                .Split(Environment.NewLine)
                .Select(l => l.Split(' '))
                .Select(p => new Instruction(p[0], int.Parse(p[1])))
                .ToArray();
    }
}