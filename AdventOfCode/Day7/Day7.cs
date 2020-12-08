using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day7
    {

        List<string> _bags;

        public Day7()
        {
            _bags = File.ReadAllLines("Day7/day7.txt").ToList();

        }
        public int GetShinyGoldBags()
        {
            var rgx = @".*\d{1}\sshiny\sgold\sbags?.*";

            var filteredList = _bags.Where(b => Regex.IsMatch(b, rgx)).ToList();
            var counter = filteredList.Count() + RecursiveBags(filteredList);

            Console.WriteLine("GLOWNY COUNTER");
            Console.WriteLine(counter);
            return counter;
        }

        public int RecursiveBags(List<string> bags)
        {
            var counter = 0;
            foreach (var bag in bags)
            {
                var splitedBag = bag.Split(" ");
                var key = splitedBag[0] + @"\s" + splitedBag[1];
                var rgxKey = $@".*\d\s{key}\sbags?.*";
                var extraFiltered = _bags.Where(b => Regex.IsMatch(b, rgxKey)).ToList();
                counter += extraFiltered.Count() + RecursiveBags(extraFiltered);
            }
            return counter;
        }

    }

}