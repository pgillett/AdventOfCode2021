using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day25
    {
        public int NumberOfMoves(string input)
        {
            var cucumbers = new Cucumbers(input);
            for (var c = 0; true; c++)
            {
                cucumbers.Move();
                if (!cucumbers.Moved) return c + 1;
            }
        }

        public class Cucumbers
        {
            private char[][] _map;
            public bool Moved;

            public string FullMap => string.Join(Environment.NewLine, _map.Select(l => new string(l)));
            
            public Cucumbers(string input)
            {
                _map = input.Split(Environment.NewLine).Select(l => l.Select(c => c).ToArray()).ToArray();
            }

            public void Move()
            {
                Moved = false;
                MoveAll(1, 0, '>');
                MoveAll(0, 1, 'v');
            }

            private void MoveAll(int dx, int dy, char c)
            {
                var newMap = NewMap();

                for (var y = 0; y < _map.Length; y++)
                {
                    for (var x = 0; x < _map[y].Length; x++)
                    {
                        MoveTo(newMap, x, y, dx, dy, c);
                    }
                }

                _map = newMap; 
            }

            private char[][] NewMap() => _map.Select(l => new char[l.Length]).ToArray();
            
            private void MoveTo(char[][] newMap, int x, int y, int dx, int dy, char c)
            {
                var x2 = (x + dx) % _map[y].Length;
                var y2 = (y + dy) % _map.Length;
                if (_map[y][x] == c && _map[y2][x2] == '.')
                {
                    newMap[y2][x2] = c;
                    newMap[y][x] = '.';
                    Moved = true;
                }
                
                if (newMap[y][x] == 0)
                    newMap[y][x] = _map[y][x];
            }
        }
    }
}