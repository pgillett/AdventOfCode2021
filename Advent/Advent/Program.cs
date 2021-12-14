using System;
using System.Diagnostics;

namespace Advent
{
    class Program
    {
        private static Stopwatch _stopwatch;

        private const int From = 1;
        private const int To = 25;

        private static readonly int[,] Times = new int[25, 2];
        
        static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();

            if (IncludeDay(1))
            {
                var day1 = new Day01();
                Output(1,1,"Increase", day1.Increases(InputData.Day01Sonar));
                Output(1,2,"Sliding increase", day1.SlidingIncreases(InputData.Day01Sonar));
            }
            
            if (IncludeDay(2))
            {
                var day2 = new Day02();
                Output(2,1,"Depth horizontal move", day2.Move(InputData.Day02Dive));
                Output(2,2,"Depth horizontal aim", day2.Aim(InputData.Day02Dive));
            }
            
            if (IncludeDay(3))
            {
                var day3 = new Day03();
                Output(3,1,"Power consumption", day3.Power(InputData.Day03Report));
                Output(3,2,"Life support", day3.Life(InputData.Day03Report));
            }
            
            if (IncludeDay(4))
            {
                var day4 = new Day04();
                Output(4,1,"Winning score", day4.WinningScore(InputData.Day04Squid));
                Output(4,2,"Squid to win", day4.SquidToWinScore(InputData.Day04Squid));
            }
            
            if (IncludeDay(5))
            {
                var day5 = new Day05();
                Output(5,1,"Vents horiz vert", day5.VentsExcluding(InputData.Day05Vent));
                Output(5,2,"All vents", day5.VentsIncluding(InputData.Day05Vent));
            }
            
            if (IncludeDay(6))
            {
                var day6 = new Day06();
                Output(6,1,"Fish after 80 days", day6.FishAfter80(InputData.Day06Fish));
                Output(6,2,"Fish after 256 days", day6.FishAfter256(InputData.Day06Fish));
            }
            
            if (IncludeDay(7))
            {
                var day7 = new Day07();
                Output(7,1,"Constant fuel", day7.ConstantFuel(InputData.Day07Crabs));
                Output(7,2,"Increasing fuel", day7.IncreasingFuel(InputData.Day07Crabs));
            }
            
            if (IncludeDay(8))
            {
                var day8 = new Day08();
                Output(8, 1, "Just 1 4 7 8", day8.Numbers1478(InputData.Day08Segment));
                Output(8,2,"All numbers", day8.AllNumbers(InputData.Day08Segment));
            }
            
            if (IncludeDay(9))
            {
                var day9 = new Day09();
                Output(9, 1, "Risk", day9.Risk(InputData.Day09Smoke));
                Output(9,2,"Three largest", day9.ThreeLargest(InputData.Day09Smoke));
            }
            
            if (IncludeDay(10))
            {
                var day10 = new Day10();
                Output(10, 1, "Corrupt", day10.Corrupt(InputData.Day10Syntax));
                Output(10,2,"Incomplete", day10.Incomplete(InputData.Day10Syntax));
            }
            
            if (IncludeDay(11))
            {
                var day11 = new Day11();
                Output(11, 1, "After 100", day11.After100(InputData.Day11Octopus));
                Output(11,2,"Synchronises at", day11.Synchronise(InputData.Day11Octopus));
            }
            
            if (IncludeDay(12))
            {
                var day12 = new Day12();
                Output(12, 1, "Small caves once", day12.SmallCavesOnce(InputData.Day12Caves));
                Output(12,2,"Small caves one twice", day12.SmallCavesOneTwice(InputData.Day12Caves));
            }
            
            if (IncludeDay(13))
            {
                var day13 = new Day13();
                Output(13, 1, "One fold dots", day13.OneFoldDots(InputData.Day13Origami));
                Output(13,2,"All folds code", 
                    Environment.NewLine+
                    string.Join(Environment.NewLine, day13.AllFoldsCode(InputData.Day13Origami)));
            }
            
            if (IncludeDay(14))
            {
                var day14 = new Day14();
                Output(14, 1, "Polymer after 1", day14.After10(InputData.Day14Polymer));
                Output(14,2,"Polymer after 40", day14.After40(InputData.Day14Polymer));
            }

            
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Day       Part 1    Part 2");
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine($"{i+1,-10}{Times[i,0],5} ms  {Times[i,1],5} ms");
            }
        }
        
        static bool IncludeDay(int day)
        {
            if (day < From || day > To) return false;

            _stopwatch.Reset();
            _stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine($"DAY {day}");
            Console.WriteLine($"==========");

            return true;
        }

        static void Output(int day, int part, string name, object answer)
        {
            var time = _stopwatch.ElapsedMilliseconds;
            Times[day-1, part-1] = (int)time;
            Console.WriteLine($"{time} ms - {name}: {answer}");
            _stopwatch.Reset();
            _stopwatch.Start();
        }
    }
}