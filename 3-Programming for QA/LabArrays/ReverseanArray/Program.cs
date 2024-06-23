using System;

class Program
{
    static void Main()
    {
        // Read the number of integers to be input
        int N;
        if (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer.");
            return;
        }

        // Create an array to store the integers
        int[] numbers = new int[N];

        // Read N integers from the console, each on a separate line
        for (int i = 0; i < N; i++)
        {
       
            if (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.WriteLine("Please enter a valid integer.");
                i--; // Retry this position
            }
        }

        // Reverse the numbers in the array
        Array.Reverse(numbers);

        // Print the elements of the array on a single line, space-separated
        Console.WriteLine(string.Join(" ", numbers));
    }
}
