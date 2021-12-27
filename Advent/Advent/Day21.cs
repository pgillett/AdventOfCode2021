using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day21
    {
        public int With100Sided(string input)
        {
            var positions = input.Split(Environment.NewLine).Select(s => int.Parse(s[^2..])).ToArray();

            var dice = new Dice();

            var player = 0;
            var scores = new int[2];

            var count = 0;

            while (scores.All(s => s < 1000))
            {
                var move = dice.GetThree();
                count += 3;

                positions[player] = (positions[player] + move - 1) % 10 + 1;
                scores[player] += positions[player];
                player = 1 - player;
            }

            return count * scores[player];
        }

        public class Dice
        {
            public int NextMove = 1;

            public Dice()
            {

            }

            public int GetThree()
            {
                return GetOne() + GetOne() + GetOne();
            }

            public int GetOne()
            {
                var move = NextMove;
                NextMove = (NextMove % 100) + 1;
                return move;
            }
        }

        public long UniverseWins(string input)
        {
            var positions = input.Split(Environment.NewLine).Select(s => int.Parse(s[^2..])).ToArray();

            for(var score1 = 20; score1>=0; score1--)
                for(var score2 = 20; score2>=0;score2--)
            for (var pos1 = 1; pos1 <= 10; pos1++)
            for (var pos2 = 1; pos2 <= 10; pos2++)
                WinsOnRoll(pos1, score1, pos2, score2, 21);

            var pair = outComes[(positions[0], 0, positions[1], 0)];

            return Math.Max(pair.Item1, pair.Item2);
        }

        public Dictionary<(int, int, int, int), (long, long)> outComes = new();

        public void WinsOnRoll(int pos1, int score1, int pos2, int score2, int target)
        {
            var count1 = 0L;
            var count2 = 0L;
            for (var d1 = 1; d1 <= 3; d1++)
            {
                var posAfter1 = (pos1 + d1 - 1) % 10 + 1;
                for (var d2 = 1; d2 <= 3; d2++)
                {
                    var posAfter2 = (posAfter1 + d2 - 1) % 10 + 1;
                    for (var d3 = 1; d3 <= 3; d3++)
                    {
                        var posAfter3 = (posAfter2 + d3 - 1) % 10 + 1;
                        if (score1 + posAfter3 >= target)
                            count1++;
                        else
                        {
                            for (var d4 = 1; d4 <= 3; d4++)
                            {
                                var posAfter4 = (pos2 + d4 - 1) % 10 + 1;
                                for (var d5 = 1; d5 <= 3; d5++)
                                {
                                    var posAfter5 = (posAfter4 + d5 - 1) % 10 + 1;
                                    for (var d6 = 1; d6 <= 3; d6++)
                                    {
                                        var posAfter6 = (posAfter5 + d6 - 1) % 10 + 1;
                                        if (score2 + posAfter6 >= target)
                                            count2++;
                                        else
                                        {
                                            var pair = outComes[
                                                (posAfter3, score1 + posAfter3, posAfter6, score2 + posAfter6)];
                                            count1 += pair.Item1;
                                            count2 += pair.Item2;
                                        }
                                    }
                                }
                            }
                        }

                        outComes[(pos1, score1, pos2, score2)] = (count1, count2);
                    }
                }
            }
        }
    }
}