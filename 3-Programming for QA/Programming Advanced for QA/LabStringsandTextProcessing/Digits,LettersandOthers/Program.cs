using System;

class Program
{
    static void Main()
    {
        // Read a single string from the console
        string input = Console.ReadLine();

        // Initialize strings to hold digits, letters, and other characters
        string digits = string.Empty;
        string letters = string.Empty;
        string others = string.Empty;

        // Iterate over each character in the input string
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                digits += c;
            }
            else if (char.IsLetter(c))
            {
                letters += c;
            }
            else
            {
                others += c;
            }
        }

        // Print the results
        Console.WriteLine(digits);
        Console.WriteLine(letters);
        Console.WriteLine(others);
    }
}
