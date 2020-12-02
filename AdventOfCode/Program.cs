namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("* * * DAY1 * * *");
            var day1 = new Day1();
            day1.Get2020();
            day1.Get2020from3numbers();

            System.Console.WriteLine("* * * DAY2 * * *");

            var day2 = new Day2();
            day2.CountPasswords();
            day2.ValidatePlaces();
        }
    }
}
