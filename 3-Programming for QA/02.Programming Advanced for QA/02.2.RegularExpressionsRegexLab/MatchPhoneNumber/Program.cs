using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        // Define the regular expression pattern for a valid phone number from Sofia
        string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";

        // Create a Regex object
        Regex regex = new Regex(pattern);

        // Find all matches in the text
        MatchCollection matches = regex.Matches(text);

        // Print the matched phone numbers separated by a comma and a space
        for (int i = 0; i < matches.Count; i++)
        {
            if (i > 0)
                Console.Write(", ");
            Console.Write(matches[i].Value);
        }
        Console.WriteLine();
    }
}
