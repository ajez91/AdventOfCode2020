using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day4
    { 
        public int ValidPassports()
        {
            List<string> inputs = File.ReadAllLines("Day4/day4.txt").ToList();
            List<string> passports = BulidPassportData(inputs);

            var query = passports.Where(p => p.Split(" ").Count() == 8 ||
                    (p.Split(" ").Count() == 7 && !p.Contains("cid"))).ToList();

            Console.WriteLine("Number of valid passports : " +query.Count);
            return query.Count;
        }

        public List<string> BulidPassportData(List<string> inputs)
        {
            List<string> passports = new List<string>();
            IEnumerator<string> iter = inputs.GetEnumerator();

            while (iter.MoveNext())
            {
                var pass = "";
                var item = iter.Current;

                while (!string.IsNullOrWhiteSpace(item))
                {
                    pass += " " + item;
                    if (!iter.MoveNext()) goto end;
                    item = iter.Current;
                }                
            end:
                passports.Add(pass.TrimStart());
            }

            Console.WriteLine("Total number of passports : " +passports.Count);
            return passports;
        }
    }
}
