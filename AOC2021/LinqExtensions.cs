using AOC2021.Days;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    internal static class LinqExtensions
    {
        public static T[] Column<T>(this T[,] array, int column)
        {
            int l = array.GetLength(0);
            T[] columnArray = new T[l];
            for (int i = 0; i < l; i++)
            {
                columnArray[i] = array[i, column];
            }
            return columnArray;
        }

        public static T[] Row<T>(this T[,] array, int row)
        {
            int l = array.GetLength(1);
            T[] rowArray = new T[l];
            for (int i = 0; i < l; i++)
            {
                rowArray[i] = array[row, i];
            }
            return rowArray;
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(List<T> list, int batchSize)
        {
            int total = 0;
            var chunked = new List<List<T>>();
            while (total < list.Count)
            {
                var chunk = list.Skip(total).Take(batchSize);
                chunked.Add(chunk.ToList());
                total += batchSize;
            }

            return chunked;
        }

    }
}
