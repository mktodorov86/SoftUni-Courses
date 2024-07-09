//  • Read first string from the first line of the console
////  • Reads second string from the second line of the console
//  • Remove all of the occurrences of the first string in the second string
//  • Print the remaining string

using System;

class Program
{
    static void Main()
    {
        // Read the first string from the first line of the console
        string firstString = Console.ReadLine();

        // Read the second string from the second line of the console
        string secondString = Console.ReadLine();

        // Check if the first string is empty or null, to avoid any runtime errors
        if (!string.IsNullOrEmpty(firstString) && !string.IsNullOrEmpty(secondString))
        {
            // Remove all occurrences of the first string from the second string
            string result = RemoveOccurrences(secondString, firstString);

            // Print the remaining string
            Console.WriteLine(result);
        }
        else
        {
            // If the input strings are empty or null, print the second string as is
            Console.WriteLine(secondString);
        }
    }

    static string RemoveOccurrences(string source, string toRemove)
    {
        // Using a loop to remove all occurrences of the toRemove string
        int index = source.IndexOf(toRemove);
        while (index != -1)
        {
            source = source.Remove(index, toRemove.Length);
            index = source.IndexOf(toRemove);
        }
        return source;
    }
}
