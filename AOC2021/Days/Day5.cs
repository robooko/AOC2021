using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal class Day5
    {


        public static int Question1()
        {

            var lines = createLines();
            var grid = createGrid(lines);
            int result = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.WriteLine(string.Join("", grid.Row(i)));
                result += grid.Row(i).ToList().Count(x => x == 2);
            }
            return result;
        }

        public static int Question2()
        {

            var lines = createLines();
            var grid = createGrid1(lines);
            int result = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.WriteLine(string.Join("", grid.Row(i)));
                result += grid.Row(i).ToList().Count(x => x == 2);
            }
            return result;
        }

        private static int[,] createGrid(IEnumerable<Line> lines)
        {
            int width = lines.Max(x => x.End.X) > lines.Max(x => x.Start.X) ? lines.Max(x => x.End.X) : lines.Max(x => x.Start.X);
            int height = lines.Max(x => x.End.Y) > lines.Max(x => x.Start.Y) ? lines.Max(x => x.End.Y) : lines.Max(x => x.Start.Y);
            var grid = new int[width + 1, height + 1];

            lines.ToList().ForEach(line =>
            {
                if (line.IsHorizontal)
                {
                    var start = line.Start.X > line.End.X ? line.End.X : line.Start.X;
                    var end = line.Start.X > line.End.X ? line.Start.X : line.End.X;

                    for (int i = start; i <= end; i++)
                    {
                        var cell = grid[i, line.Start.Y];
                        grid[i, line.Start.Y] = cell == 0 ? 1 : 2;
                    }
                }
                else if (line.IsVertical)
                {

                    var start = line.Start.Y > line.End.Y ? line.End.Y : line.Start.Y;
                    var end = line.Start.Y > line.End.Y ? line.Start.Y : line.End.Y;

                    for (int i = start; i <= end; i++)
                    {
                        var cell = grid[line.End.X, i];
                        grid[line.End.X, i] = cell == 0 ? 1 : 2;
                    }
                }

            });


            return grid;

        }


        private static int[,] createGrid1(IEnumerable<Line> lines)
        {
            int width = lines.Max(x => x.End.X) > lines.Max(x => x.Start.X) ? lines.Max(x => x.End.X) : lines.Max(x => x.Start.X);
            int height = lines.Max(x => x.End.Y) > lines.Max(x => x.Start.Y) ? lines.Max(x => x.End.Y) : lines.Max(x => x.Start.Y);
            var grid = new int[width + 1, height + 1];

            lines.ToList().ForEach(line =>
            {
                if (line.IsHorizontal)
                {
                    var start = line.Start.X > line.End.X ? line.End.X : line.Start.X;
                    var end = line.Start.X > line.End.X ? line.Start.X : line.End.X;

                    for (int i = start; i <= end; i++)
                    {
                        var cell = grid[i, line.Start.Y];
                        grid[i, line.Start.Y] = cell == 0 ? 1 : 2;
                    }
                }
                else if (line.IsVertical)
                {

                    var start = line.Start.Y > line.End.Y ? line.End.Y : line.Start.Y;
                    var end = line.Start.Y > line.End.Y ? line.Start.Y : line.End.Y;

                    for (int i = start; i <= end; i++)
                    {
                        var cell = grid[line.End.X, i];
                        grid[line.End.X, i] = cell == 0 ? 1 : 2;
                    }
                }
                else 
                {

                    if (line.IsPositiveDiagonal)
                    {
                        if (line.End.X < line.Start.X)
                        {
                            for (int i = 0; i <= line.Start.X - line.End.X; i++)
                            {
                                var cell = grid[line.Start.X - i, line.Start.Y - i];
                                grid[line.Start.X - i, line.Start.Y - i] = cell == 0 ? 1 : 2;
                            }
                        }
                        else
                        {
                            for (int i = 0; i <= line.End.X - line.Start.X; i++)
                            {
                                var cell = grid[line.Start.X + i, line.Start.Y + i];
                                grid[line.Start.X + i, line.Start.Y + i] = cell == 0 ? 1 : 2;
                            }

                        }
                    }
                    else if (!line.IsPositiveDiagonal)
                    {
                        if (line.End.X > line.Start.X)
                        {

                            for (int i = 0; i <= line.End.X - line.Start.X; i++)
                            {
                                var cell = grid[line.Start.X + i, line.Start.Y - i];
                                grid[line.Start.X + i, line.Start.Y - i] = cell == 0 ? 1 : 2;
                            }
                        }
                        else
                        {

                            for (int i = 0; i <= line.Start.X - line.End.X; i++)
                            {
                                var cell = grid[line.Start.X - i, line.Start.Y + i];
                                grid[line.Start.X - i, line.Start.Y + i] = cell == 0 ? 1 : 2;
                            }
                        }
                    }
                }

            });


            return grid;

        }

        private static IEnumerable<Line> createLines()
        {
            var allLines = File.ReadAllLines("inputs/day5.txt").Select(x => x);

            return allLines.Select(x => new Line(x));
        }
    }

    class Coords
    {
        public int X;
        public int Y;


        public Coords(IEnumerable<int> coords)
        {
            this.X = coords.First();
            this.Y = coords.Last();
        }
    }

    class Line
    {
        public Coords Start;
        public Coords End;

        public Line(string data)
        {
            this.Start = new Coords(data.Split("->")[0].Split(',').Select(x => int.Parse(x)));
            this.End = new Coords(data.Split("->")[1].Split(',').Select(x => int.Parse(x)));
        }

        public bool IsVertical => Start.X == End.X;
        public bool IsHorizontal => Start.Y == End.Y;
        public bool IsDigonal => End.Y - Start.Y == End.X - Start.X || End.Y - Start.Y == Start.X - End.X;
        public bool IsPositiveDiagonal => End.Y - Start.Y == End.X - Start.X;
    }
}
