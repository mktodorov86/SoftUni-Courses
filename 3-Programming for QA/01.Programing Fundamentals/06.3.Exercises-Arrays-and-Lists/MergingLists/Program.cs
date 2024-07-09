using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read first sequence of integers
        List<int> firstSequence = Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToList();

        // Read second sequence of integers
        List<int> secondSequence = Console.ReadLine()
                                          .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();

        // Create result list to store merged sequence
        List<int> result = new List<int>();

        // Determine the minimum length of the two sequences
        int minLength = Math.Min(firstSequence.Count, secondSequence.Count);

        // Merge sequences alternating elements
        for (int i = 0; i < minLength; i++)
        {
            result.Add(firstSequence[i]);
            result.Add(secondSequence[i]);
        }

        // Add remaining elements from longer sequence, if any
        if (firstSequence.Count > secondSequence.Count)
        {
            result.AddRange(firstSequence.Skip(secondSequence.Count));
        }
        else if (secondSequence.Count > firstSequence.Count)
        {
            result.AddRange(secondSequence.Skip(firstSequence.Count));
        }

        // Print the merged result list
        Console.WriteLine(string.Join(" ", result));
    }
}
