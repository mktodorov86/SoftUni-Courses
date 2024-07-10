using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        // Define the regular expression pattern for a valid date
        string pattern = @"(?<day>\d{2})(?<sep>[./-])(?<month>[A-Z][a-z]{2})\k<sep>(?<year>\d{4})";

        // Create a Regex object
        Regex regex = new Regex(pattern);

        // Find all matches in the text
        MatchCollection matches = regex.Matches(text);

        // Print the matched dates in the specified format
        foreach (Match match in matches)
        {
            string day = match.Groups["day"].Value;
            string month = match.Groups["month"].Value;
            string year = match.Groups["year"].Value;
            Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
        }
    }
}
