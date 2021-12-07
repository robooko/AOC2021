using System.Drawing;

namespace AOC2021.Days
{
    internal class Day5
    {
        public static int Count(bool excludeDiagonal = false)
        {
            return File.ReadAllLines("inputs/day5a.txt")
                .Select(x => x)
                .Select(x => new Line(x))
                .Where(x => excludeDiagonal || !x.IsDigonal)
                .Select(x => createline(x))
                .SelectMany(x => x.Select(x => x))
                .GroupBy(x => x)
                .Count(x => x.Count() > 1);
        }

        static IEnumerable<Point> createline(Line line)
        {
            int w = line.End.X - line.Start.X;
            int h = line.End.Y - line.Start.Y;
            int x = line.Start.X;
            int y = line.Start.Y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                yield return new Point(x, y);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
            yield break;
        }
    }


    class Line
    {
        public readonly Point Start;
        public readonly Point End;

        public Line(string data)
        { 
            var startValue = data.Split("->")[0].Split(',').Select(x => int.Parse(x)).ToArray();
            var endValue = data.Split("->")[1].Split(',').Select(x => int.Parse(x)).ToArray();


            this.Start = new Point(startValue[0], startValue[1]);
            this.End = new Point(endValue[0], endValue[1]);
        }
        public bool IsDigonal => End.Y - Start.Y == End.X - Start.X || End.Y - Start.Y == Start.X - End.X;
    }


}
