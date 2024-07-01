using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Read the sequence of integers from the console
        Console.WriteLine("Enter a sequence of integers separated by spaces:");
        string input = Console.ReadLine();

        // Split the input into individual numbers
        string[] numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<int> sequence = new List<int>();

        foreach (string number in numbers)
        {
            if (int.TryParse(number, out int num))
            {
                sequence.Add(num);
            }
            else
            {
                Console.WriteLine($"Invalid input: '{number}' is not a valid integer.");
                return;
            }
        }

        // Calculate the sums in the specified order
        int left = 0;
        int right = sequence.Count - 1;
        int n = sequence.Count / 2; // Integer division
        List<int> sums = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int sum = sequence[left + i] + sequence[right - i];
            sums.Add(sum);
        }

        // Handle the middle element if the sequence length is odd
        if (sequence.Count % 2 != 0)
        {
            sums.Add(sequence[left + n]);
        }

        // Output the results
        Console.WriteLine("Sums in the specified order:");
        foreach (int sum in sums)
        {
            Console.WriteLine(sum);
        }
    }
}

