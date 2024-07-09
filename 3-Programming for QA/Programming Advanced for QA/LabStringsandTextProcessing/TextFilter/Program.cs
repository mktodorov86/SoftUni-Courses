using System;

class Program
{
    static void Main()
    {
        // Read the ban list from the first line of the console
        string banListInput = Console.ReadLine();

        // Read the text from the second line of the console
        string text = Console.ReadLine();

        // Split the ban list into individual words
        string[] bannedWords = banListInput.Split(new string[] { ", " }, StringSplitOptions.None);

        // Replace each banned word in the text with asterisks
        foreach (string bannedWord in bannedWords)
        {
            string replacement = new string('*', bannedWord.Length);
            text = text.Replace(bannedWord, replacement);
        }

        // Print the resulting text
        Console.WriteLine(text);
    }
}
