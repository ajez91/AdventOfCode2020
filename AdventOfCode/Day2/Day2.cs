using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day2
    {
        public void CountPasswords()
        {
            List<string> inputs = File.ReadAllLines("day2.txt").ToList();

            int counter = 0;
            foreach (var item in inputs)
            {
                var newItem = item.Replace(":", "").Split(" ");
                var range = newItem[0].Split("-");
                if (Convert.ToInt32(range[0]) <= newItem[2].Count(l => l == Convert.ToChar(newItem[1])) 
                    && newItem[2].Count(l => l == Convert.ToChar(newItem[1])) <= Convert.ToInt32(range[1]))
                {
                    counter += 1;
                }
            }
            Console.WriteLine(counter);
        }

        public void ValidatePlaces()
        {
            List<string> inputs = File.ReadAllLines("day2.txt").ToList();

            int counter = 0;
            foreach (var item in inputs)
            {
                var newItem = item.Replace(":", "").Split(" ");
                var range = newItem[0].Split("-");
                if (newItem[2][Convert.ToInt32(range[0])-1] == Convert.ToChar(newItem[1])
                    && newItem[2][Convert.ToInt32(range[1])-1] != Convert.ToChar(newItem[1]))
                { counter += 1; }
                else if (newItem[2][Convert.ToInt32(range[0]) - 1] != Convert.ToChar(newItem[1])
                    && newItem[2][Convert.ToInt32(range[1]) - 1] == Convert.ToChar(newItem[1]))
                { counter += 1; }

            }
            Console.WriteLine(counter);
        }

    }
}
