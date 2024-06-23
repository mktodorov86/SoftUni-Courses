using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read the array of integers from a single line of input

        string input = Console.ReadLine();

        try
        {
            // Split the input string by spaces and convert to an array of integers
            int[] numbers = input.Split(' ').Select(int.Parse).ToArray();

            // Calculate the sum of even and odd numbers
            int sumEven = 0;
            int sumOdd = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sumEven += number;
                }
                else
                {
                    sumOdd += number;
                }
            }

            // Calculate the difference between the sum of even and odd numbers
            int difference = sumEven - sumOdd;

            // Print the difference
            Console.WriteLine(difference);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid series of integers separated by spaces.");
        }
    }
}
