using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static class Day3
    {

        public static int Question1()
        {
            var allLines = File.ReadAllLines("inputs/day3.txt").Select(x => x);

            var lengthOfNumbers = allLines.First().Length;
            var  gama = new StringBuilder();
            var epsilon = new StringBuilder();

            for (int i = 0; i < lengthOfNumbers; i++)
            {
                gama.Append(commonBit(allLines.ToList(), i, 1));
            }
            for (int i = 0; i < lengthOfNumbers; i++)
            {
                epsilon.Append(commonBit(allLines.ToList(), i, 0));
            }

            return Convert.ToInt32(epsilon.ToString(), 2) * Convert.ToInt32(gama.ToString(), 2);
        }

        public static int Question2()
        {
            var allLines = File.ReadAllLines("inputs/day3.txt").Select(x => x);

            var lengthOfNumbers = allLines.First().Length;

            var oxygenLines = allLines.ToList();
            for (int i = 0; i < lengthOfNumbers; i++)
            {
                oxygenLines = oxygenLines.Where(x => x.Substring(i,1) == commonBit(oxygenLines, i, 1)).ToList();
                if (oxygenLines.Count() == 1)
                    break;
            }

            var co2Lines = allLines.ToList();
            for (int i = 0; i < lengthOfNumbers; i++)
            {
                co2Lines = co2Lines.Where(x => x.Substring(i, 1) == commonBit(co2Lines, i, 0)).ToList();
                if (co2Lines.Count() == 1)
                    break;
            }

            return Convert.ToInt32(oxygenLines.First().ToString(), 2) * Convert.ToInt32(co2Lines.First().ToString(), 2);
        }

        static string commonBit(List<string> allLines, int position, int defaultValue)
        {
            var group = allLines.Select(x => x.Substring(position, 1))
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count());

            return group.GroupBy(x => x.Count()).Count() == 1 ? defaultValue.ToString():
                Convert.ToBoolean(defaultValue) ? group.First().Key : group.Last().Key;
        }
    }
}
