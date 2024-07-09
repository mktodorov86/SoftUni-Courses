//  • Reads an array of strings from the console
//  • Each string is repeated N times, where N is the length of the string
//  • Print the concatenated string

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        string input = Console.ReadLine();

        // Split the input into an array of strings
        string[] words = input.Split(' ');

        // List to hold the final repeated strings
        List<string> repeatedWords = new List<string>();

        // Process each word
        foreach (string word in words)
        {
            int length = word.Length;
            string repeatedWord = new string(word[0], length).Replace(word[0].ToString(), word); // Repeat the word length times
            repeatedWords.Add(repeatedWord);
        }

        // Concatenate the repeated words
        string result = string.Join("", repeatedWords);
        Console.WriteLine(result);
    }
}
