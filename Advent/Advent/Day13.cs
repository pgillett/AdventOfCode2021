using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;

namespace Advent
{
    public class Day13
    {
        public int OneFoldDots(string input) => Process(input, false).dots;
        
        public IEnumerable<string> AllFoldsCode(string input) => Process(input, true).result;

        private (int dots, IEnumerable<string> result) Process(string input, bool all)
        {
            var split = input.Split(Environment.NewLine + Environment.NewLine);

            var coords = split[0].Split(Environment.NewLine)
                .Select(l =>
                {
                    var s = l.Split(',');
                    return (int.Parse(s[0]), int.Parse(s[1]));
                }).ToArray();

            var folds = split[1].Split(Environment.NewLine)
                .Select(l =>
                {
                    var s = l.Replace("fold along ", "").Split('=');
                    return (s[0][0], int.Parse(s[1]));
                });

            var width = coords.Max(c => c.Item1) + 1;
            var height = coords.Max(c => c.Item2) + 1;

            var paper = new bool[width, height];

            foreach (var (x, y) in coords) 
                paper[x, y] = true;

            if (!all) folds = folds.Take(1);

            foreach (var (direction, position) in folds)
            {
                if (direction == 'x')
                {
                    for (var y = 0; y < height; y++)
                    for (var x = position + 1; x < width; x++)
                        if (paper[x, y])
                        {
                            paper[2 * position - x, y] = true;
                        }

                    width = position;
                }
                else
                {
                    for (var x = 0; x < width; x++)
                    for (var y = position + 1; y < height; y++)
                        if (paper[x, y])
                        {
                            paper[x, 2 * position - y] = true;
                        }

                    height = position;
                }
            }

            var result = new List<string>();
            for (var y = 0; y < height; y++)
            {
                var line = "";
                for (var x = 0; x < width; x++)
                {
                    line += paper[x, y] ? "*" : ".";
                }

                result.Add(line);
            }

            var count = result.Sum(r => r.Count(c => c == '*'));
            return (count, result);
        }
    }
}