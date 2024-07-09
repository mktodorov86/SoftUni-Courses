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

        // Process the sequence to sum adjacent equal numbers
        bool hasChanged;
        do
        {
            hasChanged = false;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    int sum = numbers[i] + numbers[i + 1];
                    numbers[i] = sum;       // Update the left number with the sum
                    numbers.RemoveAt(i + 1); // Remove the right number
                    hasChanged = true;      // Set flag to indicate change
                    break;                  // Break to re-evaluate from the start
                }
            }
        } while (hasChanged); // Continue until no more changes are made

        // Print the resulting sequence after summing adjacent equal numbers
        Console.WriteLine(string.Join(" ", numbers));
    }
}
