using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read a list of integers from the console
  
        List<int> numbers = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

        // Remove negative numbers from the list
        numbers.RemoveAll(num => num < 0);

        // Check if there are remaining elements
        if (numbers.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            // Reverse the list
            numbers.Reverse();

            // Print the remaining elements in reversed order
        
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
