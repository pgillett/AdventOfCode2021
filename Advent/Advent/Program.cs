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