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

        // Calculate and print sums as described
        int n = numbers.Count;
        for (int i = 0; i < n / 2; i++)
        {
            int sum = numbers[i] + numbers[n - 1 - i];
            Console.Write(sum+" ");
        }

        // If the list has an odd number of elements, also calculate and print the middle element
        if (n % 2 != 0)
        {
            Console.Write(numbers[n / 2]);
        }
    }
}
