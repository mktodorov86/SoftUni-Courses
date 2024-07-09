using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read input sequence of integers
        List<int> numbers = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

        // Condense the sequence until a single integer remains
        while (numbers.Count > 1)
        {
            List<int> condensed = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int sum = numbers[i] + numbers[i + 1];
                condensed.Add(sum);
            }

            numbers = condensed;
        }

        // Print the final condensed integer
        Console.WriteLine(numbers[0]);
    }
}
