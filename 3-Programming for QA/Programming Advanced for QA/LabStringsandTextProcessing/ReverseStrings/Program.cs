//  • Reads a series of strings from the console, until you receive an "end" command
//  • Reverse given strings
//  • Print each pair (old text and reversed text) on a separate line in the format:
// "{word} = {reversed word}"


using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            string word = Console.ReadLine();

            if (word.ToLower() == "end")
            {
                break;
            }

            string reversedWord = ReverseString(word);
            Console.WriteLine($"{word} = {reversedWord}");
        }
    }

    static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
