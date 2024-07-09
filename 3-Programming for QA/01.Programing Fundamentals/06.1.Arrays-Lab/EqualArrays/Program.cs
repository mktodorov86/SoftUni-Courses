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

        // Check whether the arrays are identical
        if (array1.Length != array2.Length)
        {
            Console.WriteLine("Arrays are not identical.");
        }
        else if (array1.SequenceEqual(array2))
        {
            Console.WriteLine("Arrays are identical.");
        }
        else
        {
            Console.WriteLine("Arrays are not identical.");
        }
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
