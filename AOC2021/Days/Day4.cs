using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.Days
{
    internal static  class Day4
    {

        public static int Question1()
        {

            var boards = createBoards();
            var numbers = getNumbers();

            int completedBoard = 0;
            int lastPick = 0;
            int result = 0;

            for (int numberIndex = 0; numberIndex < numbers.Count(); numberIndex++)
            {
                var currentNumber = numbers.ElementAt(numberIndex);
                boards.ToList().ForEach(b =>
                {
                    for (int i = 0; i < b.GetLength(0); i++)
                        for (int j = 0; j < b.GetLength(1); j++)
                            b[i, j] = b[i, j] == currentNumber ? 0 : b[i, j];


                });

                for (int boardIndex = 0; boardIndex < boards.Count(); boardIndex++)
                {
                    var currentBoard = boards.ElementAt(boardIndex);
                    for (int i = 0; i < currentBoard.GetLength(0); i++)
                    {

                        if (currentBoard.Row(i).Count(x => x != 0) == 0 || currentBoard.Column(i).Count(x => x != 0) == 0)
                        {
                            completedBoard = boardIndex;
                            lastPick = currentNumber;
                            break;
                        }
                    }


                    if (lastPick != 0)
                        break;
                }


                if (lastPick != 0)
                    break;
            }



            var countBoard = boards.ElementAt(completedBoard);
            for (int i = 0; i < countBoard.GetLength(0); i++)
            {
                result += countBoard.Row(i).ToList().Sum();
            }

            return result * lastPick;
        }

        public static int Question2()
        {
            var boards = createBoards();
            var numbers = getNumbers();

            int completedBoard = 0;
            int lastPick = 0;
            int result = 0;
            var completedBoards = new List<int>();

            for (int numberIndex = 0; numberIndex < numbers.Count(); numberIndex++)
            {
                var currentNumber = numbers.ElementAt(numberIndex);
                boards.ToList().ForEach(b =>
                {
                    for (int i = 0; i < b.GetLength(0); i++)
                        for (int j = 0; j < b.GetLength(1); j++)
                            b[i, j] = b[i, j] == currentNumber ? 0 : b[i, j];


                });

                for (int boardIndex = 0; boardIndex < boards.Count(); boardIndex++)
                {
                    var currentBoard = boards.ElementAt(boardIndex);
                    for (int i = 0; i < currentBoard.GetLength(0); i++)
                    {

                        if ((currentBoard.Row(i).Count(x => x != 0) == 0 || currentBoard.Column(i).Count(x => x != 0) == 0) && !completedBoards.Contains(boardIndex))
                        {
                            completedBoard = boardIndex;
                            lastPick = currentNumber;
                            completedBoards.Add(boardIndex);
                        }
                    }
                }


                if (completedBoards.Count() == boards.Count())
                    break;
            }



            var countBoard = boards.ElementAt(completedBoard);
            for (int i = 0; i < countBoard.GetLength(0); i++)
            {
                result += countBoard.Row(i).ToList().Sum();
            }

            return result * lastPick;
        }

        private static IEnumerable<int> getNumbers()
        {
            var allLines = File.ReadAllLines("inputs/day4.txt").Select(x => x);
            return allLines.ElementAt(0).Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s));
        }

        private static List<int[,]> createBoards()
        {
            var allLines = File.ReadAllLines("inputs/day4.txt").Select(x => x);
            var boards = new List<int[,]>();
            var batches = LinqExtensions.Chunk(allLines.Skip(1).Where(x => x != string.Empty).ToList(), 5);
            int[] f = batches.First().First().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            batches.ToList().ForEach(x =>
            {
                int[,] multiDimensionalArray1 = new int[5, 5];
                x.ToList().ForEach(i =>
                {
                    var index = x.ToList().IndexOf(i);
                    multiDimensionalArray1[index, 0] = x.ElementAt(index).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ElementAt(0);
                    multiDimensionalArray1[index, 1] = x.ElementAt(index).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ElementAt(1);
                    multiDimensionalArray1[index, 2] = x.ElementAt(index).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ElementAt(2);
                    multiDimensionalArray1[index, 3] = x.ElementAt(index).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ElementAt(3);
                    multiDimensionalArray1[index, 4] = x.ElementAt(index).Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ElementAt(4);
                });
                boards.Add(multiDimensionalArray1);
            });
            return boards;
        }
    }

}
