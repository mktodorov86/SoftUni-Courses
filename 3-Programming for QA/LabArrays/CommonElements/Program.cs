using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read the first array of integers from a single line of input

        int[] array1 = ReadArrayFromConsole();

        // Read the second array of integers from a single line of input

        int[] array2 = ReadArrayFromConsole();

        // Validate if arrays are of the same length
        if (array1.Length != array2.Length)
        {
            Console.WriteLine("Arrays must have the same length.");
            return;
        }

        // Find and print common elements in both arrays
        var commonElements = array1.Intersect(array2).ToArray();
        Console.WriteLine(string.Join(" ", commonElements));
    }

    static int[] ReadArrayFromConsole()
    {
        string input = Console.ReadLine();
        try
        {
            // Split the input string by spaces and convert to an array of integers
            return input.Split(' ').Select(int.Parse).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid series of integers separated by spaces.");
            return new int[0]; // Return an empty array in case of invalid input
        }
    }
}
