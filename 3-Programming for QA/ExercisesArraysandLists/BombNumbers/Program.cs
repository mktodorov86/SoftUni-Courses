using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read sequence of integer numbers
        List<int> numbers = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

        // Read special bomb number and its power
        int specialBombNumber = int.Parse(Console.ReadLine().Split()[0]);
        int power = int.Parse(Console.ReadLine().Split()[0]);

        // Detonate the special bomb number and its neighbors
        DetonateBomb(numbers, specialBombNumber, power);

        // Calculate and print the sum of remaining elements in the sequence
        int sumRemaining = numbers.Sum();
        Console.WriteLine(sumRemaining);
    }

    static void DetonateBomb(List<int> numbers, int bombNumber, int power)
    {
        // Iterate through the list to detonate the bomb and its neighbors
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == bombNumber)
            {
                // Detonate the current bomb number
                int startDetonationIndex = Math.Max(0, i - power);
                int endDetonationIndex = Math.Min(numbers.Count - 1, i + power);

                // Remove detonated elements
                numbers.RemoveRange(startDetonationIndex, endDetonationIndex - startDetonationIndex + 1);

                // After removal, adjust index to continue checking from the next element
                i = startDetonationIndex - 1;
            }
        }
    }
}
