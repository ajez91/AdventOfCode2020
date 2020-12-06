using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4
    { 
        public List<string> ValidPassports()
        {
            List<string> inputs = File.ReadAllLines("Day4/day4.txt").ToList();
            List<string> passports = BulidPassportData(inputs);

            var query = passports.Where(p => p.Split(" ").Count() == 8 ||
                    (p.Split(" ").Count() == 7 && !p.Contains("cid"))).ToList();

            Console.WriteLine("Number of valid passports : " +query.Count);
            return query;
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

        public List<Dictionary<string, string>> GetPassportDicts()
        {
            var passports = ValidPassports();

            var parsedValue = new List<Dictionary<string, string>>();

            foreach (var pass in passports)
            {
                var passDict = new Dictionary<string, string>();

                var features = pass.Split(" ");
                foreach (var item in features)
                {
                    var feat = item.Split(":");
                    passDict.Add(feat[0], feat[1]);
                }

                parsedValue.Add(passDict);
            }

            return parsedValue;
        }

        public int ValidatePassportsByRules()
        {

            var valid = GetPassportDicts().Where(p =>
               int.Parse(p["byr"]) is >= 1920 and <= 2002 &&
               int.Parse(p["iyr"]) is >= 2010 and <= 2020 &&
               int.Parse(p["eyr"]) is >= 2020 and <= 2030 &&
               (p["hgt"].EndsWith("cm") && int.Parse(p["hgt"].Substring(0, p["hgt"].Length - 2)) is >= 150 and <= 193 ||
                p["hgt"].EndsWith("in") && int.Parse(p["hgt"].Substring(0, p["hgt"].Length - 2)) is >= 59 and <= 76) &&
               Regex.IsMatch(p["hcl"], @"^\#[a-f0-9]{6}$") &&
               new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(p["ecl"]) &&
               Regex.IsMatch(p["pid"], @"^\d{9}$"));

            Console.WriteLine("Number of valid passport: " + valid.Count());
            return valid.Count();
        }

    }
}
