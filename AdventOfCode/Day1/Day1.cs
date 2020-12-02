using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day1
    {
        public int Get2020()
        {
            List<string> allNumbersString = File.ReadAllLines("day1input.txt").ToList();
            List<int> allNumbersInt = new List<int>();
            List<int> goodNumbers = new List<int>();

            foreach (var item in allNumbersString)
            {
                allNumbersInt.Add(Convert.ToInt32(item));
            }

            foreach (var item in allNumbersInt)
            {
                foreach (var num in allNumbersInt)
                {
                    if (item + num == 2020)
                    {
                        goodNumbers.Add(item);
                        goodNumbers.Add(num);
                    }
                }
            }

            Console.WriteLine(goodNumbers[0] * goodNumbers[1]);
            return goodNumbers[0] * goodNumbers[1];

        }

        public int Get2020from3numbers()
        {
            List<string> allNumbersString = File.ReadAllLines("day1input.txt").ToList();
            List<int> allNumbersInt = new List<int>();
            List<int> goodNumbers = new List<int>();

            foreach (var item in allNumbersString)
            {
                allNumbersInt.Add(Convert.ToInt32(item));
            }

            foreach (var item in allNumbersInt)
            {
                foreach (var num in allNumbersInt)
                {
                    foreach (var intnum in allNumbersInt)
                    {
                        if (item + num + intnum == 2020)
                        {
                            goodNumbers.Add(item);
                            goodNumbers.Add(num);
                            goodNumbers.Add(intnum);
                        }

                    }
                }
            }

            Console.WriteLine(goodNumbers[0] * goodNumbers[1] * goodNumbers[2]);
            return goodNumbers[0] * goodNumbers[1] * goodNumbers[2]; 

        }
    }
}
