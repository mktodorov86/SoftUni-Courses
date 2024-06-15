//   • Read a text (string) from the console
//  • Create a method that receives a text
//  • Find the count of the vowels contained in the text
// • Print the count of the vowels in the text


using System;

public class VowelCounter
{
    public static void Main()
    {

    string inputText = Console.ReadLine();


    int vowelCount = CountVowels(inputText);


    Console.WriteLine(vowelCount);
}


public static int CountVowels(string text)
{
    int count = 0;
    string vowels = "aeiouAEIOU"; 

    foreach (char c in text)
    {
        if (vowels.Contains(c))
        {
            count++;
        }
    }

    return count;
}
}

