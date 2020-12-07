using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day6
    {
        string[] _groups;

        public Day6()
        {
            _groups = File.ReadAllText("Day6/day6.txt.").Split("\r\n"+ "\r\n");
        }

        public int GetAnswers()
        {
            var query = _groups.Sum(g => RemoveWhitespace(g).Distinct().Count());
            Console.WriteLine(query);
            return query;
        }

        public int GetEveryoneAnswers()
        {
            var counter = _groups.Sum(group =>group.GroupBy(g => g).Count(l => l.Count() == group.Split("\n").Length));
            Console.WriteLine(counter);
            return counter;
        }

        public string RemoveWhitespace(string s)=> Regex.Replace(s, @"\s", string.Empty);
        
    }
}
