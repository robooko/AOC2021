using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day1
    {
        public static int CalculatelargerMeasurements(int take)
        {
            var allLines = File.ReadAllLines("inputs/day1.txt").Select(x => Convert.ToInt32(x)).ToArray();
            var largerMeasurements = allLines.Where((x, idx) => idx > 0 && allLines.Skip(idx).Take(take).Sum() > allLines.Skip(idx - 1).Take(take).Sum());
            return largerMeasurements.Count();
        }
    }
}
