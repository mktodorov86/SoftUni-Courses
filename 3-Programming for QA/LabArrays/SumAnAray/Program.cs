using System;

class Program
{
    static void Main()
    {


        // Read the input from the console
        string input = Console.ReadLine();

        try
        {
            // Split the input string by spaces and convert to an array of integers
            string[] inputArray = input.Split(' ');
            int[] numbers = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                numbers[i] = int.Parse(inputArray[i]);
            }

            // Calculate the sum of all elements in the array
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            // Print the sum
            Console.WriteLine(sum);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid series of integers separated by spaces.");
        }
    }
}
