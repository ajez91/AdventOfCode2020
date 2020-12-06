using System;
using System.IO;

namespace AdventOfCode2020
{
    public class Day3
    {

        char[,] _array;

        public Day3()
        {
            _array = Build2dArray();
        }

        public char[,] Build2dArray()
        {

            string input = File.ReadAllText("Day3/day3.txt");
            var rows = input.Split(Environment.NewLine);

            var array = new char[rows.Length, rows[0].Length];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[0].Length; j++)
                {
                    array[i, j] = rows[i][j];
                }
            }
            return array;
        }

        public int CountTree(int right, int down)
        {
            var (column, row) = (0, 0);
            var trees = 0;

            while (row < _array.GetLength(0))
            {
                if (_array[row, column] == '#')
                    trees++;

                column += right;
                row += down;

                if (column > _array.GetLength(1) - 1)
                {
                    column -= _array.GetLength(1);
                }
            }
            Console.WriteLine(trees);
            return trees;
        }

        public int ThroughSlopes()
        {
            var multiply = CountTree(1, 1) 
                * CountTree(3, 1) 
                * CountTree(5, 1) 
                * CountTree(7, 1) 
                * CountTree(1, 2);
            Console.WriteLine(multiply);
            return multiply;
        }
    }
}
