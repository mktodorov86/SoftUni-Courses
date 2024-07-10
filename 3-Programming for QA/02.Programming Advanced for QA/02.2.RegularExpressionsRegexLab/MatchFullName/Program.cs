using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        string text = Console.ReadLine();

        // Define the regular expression pattern for a valid full name
        string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

        // Create a Regex object
        Regex regex = new Regex(pattern);

        // Find all matches in the text
        MatchCollection matches = regex.Matches(text);

        // Print the matched full names separated by a single space
        for (int i = 0; i < matches.Count; i++)
        {
            if (i > 0)
                Console.Write(" ");
            Console.Write(matches[i].Value);
        }
        Console.WriteLine();
    }
}
