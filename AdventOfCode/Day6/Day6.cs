using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day6
    {
        string[] _groups;

        public Day6()
        {
            _groups = File.ReadAllText("Day6/day6.txt.").Split(Environment.NewLine + Environment.NewLine);
        }

        public void GetAnswers()
        {
            var query = _groups.Sum(g => RemoveWhitespace(g).Distinct().Count());
            Console.WriteLine(query);
        }

        public string RemoveWhitespace(string s)=> Regex.Replace(s, @"\s", string.Empty);
        
    }
}
