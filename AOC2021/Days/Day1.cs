using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day1
    {
        public static void Quesstion1()
        {
            var allLines = File.ReadAllLines("inputs/day1.txt").Select(x => Convert.ToInt32(x)).ToArray();
            var largerMeasurements = allLines.Where((x, idx) => idx > 0 && x > allLines[idx - 1]);
            Console.WriteLine($"Day 1 question 1 answer is {largerMeasurements.Count()}");
        }
    }
}
