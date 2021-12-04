using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Advent
{
    public class Day04
    {
        public int WinningScore(string input)
        {
            var (called, boards) = Parse(input);
            return Score(called, boards, true);
        }
        
        public int SquidToWinScore(string input)
        {
            var (called, boards) = Parse(input);
            return Score(called, boards, false);
        }

        private int Score(int[] called, Board[] boards, bool finishOnWin)
        {
            var last = 0;
            Board winner = null;
            foreach (var number in called)
            {
                foreach (var board in boards)
                {
                    if (!board.HasWon && board.Mark(number))
                    {
                        if (finishOnWin) return board.Sum() * number;
                        last = number;
                        winner = board;
                    }
                }
            }

            return winner.Sum() * last;
        }

        private class Board
        {
            private int[][] Numbers;
            public bool HasWon;

            public Board(string board)
            {
                Numbers = board
                    .Split(Environment.NewLine)
                    .Select(r => r.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray())
                    .ToArray();
            }

            public bool Mark(int called)
            {
                foreach (var row in Numbers)
                {
                    for (var c = 0; c < row.Length; c++)
                    {
                        if (row[c] == called)
                            row[c] = -1;
                    }
                }

                HasWon = Check();
                return HasWon;
            }

            private bool Check()
            {
                if (Numbers.Any(row => row.All(c => c == -1)))
                {
                    return true;
                }

                for (var c = 0; c < Numbers[0].Length; c++)
                {
                    if (Numbers.All(n => n[c] == -1)) return true;
                }

                return false;
            }

            public int Sum() => Numbers.Sum(n => n.Where(c => c > 0).Sum());
        }

        private (int[] called, Board[] boards) Parse(string input)
        {
            var sections = input
                .Split(Environment.NewLine + Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var called = sections[0].Split(',').Select(int.Parse).ToArray();

            var boards = sections.Skip(1).Select(b => new Board(b)).ToArray();

            return (called, boards);
        }
    }
}