using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day5
    {
        public int GetHighestId()
        {
            var input = File.ReadAllLines("Day5/day5.txt").ToList();

            int max = 0;

            foreach (var item in input)
            {
                var seatId = CalculateColumn(item) * 8 + CalculateSeat(item);
                if (seatId > max) max = seatId;
            }
            return max;
        }

        public int CalculateColumn(string code)
        {
            var minCol = 0;
            var maxCol = 127;

            foreach (var c in code.Substring(0, 7))
            {
                switch (c)
                {
                    case 'F':
                        maxCol = minCol + (maxCol - minCol) / 2;
                        break;
                    case 'B':
                        minCol += (maxCol - minCol) / 2 + 1;
                        break;
                }
            }
            return maxCol;
        }

        public int CalculateSeat(string code)
        {
            var minSeat = 0;
            var maxSeat = 7;

            foreach (var c in code.Substring(7, 3))
            {
                switch (c)
                {
                    case 'L':
                        maxSeat = minSeat + (maxSeat - minSeat) / 2;
                        break;
                    case 'R':
                        minSeat += (maxSeat - minSeat) / 2 + 1;
                        break;
                }
            }
            return maxSeat;
        }
    }
}
