using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Read the number of pairs, N
        int N = int.Parse(Console.ReadLine());

        // Initialize lists for zigzag pattern
        List<int> array1 = new List<int>();
        List<int> array2 = new List<int>();

        // Read the pairs and populate arrays in zigzag pattern
        for (int i = 0; i < N; i++)
        {
            string[] pair = Console.ReadLine().Split();
            int num1 = int.Parse(pair[0]);
            int num2 = int.Parse(pair[1]);

            if (i % 2 == 0)
            {
                // Add num1 to array1
                array1.Add(num1);

                // Add num2 to array2 if exists
                if (i + 1 < N)
                    array2.Add(num2);
                else
                    array2.Add(num2); // Add the last element to array2
            }
            else
            {
                // Add num2 to array1
                array1.Add(num2);

                // Add num1 to array2 if exists
                if (i + 1 < N)
                    array2.Add(num1);
                else
                    array2.Add(num1); // Add the last element to array2
            }
        }

        // Print arrays as specified
        Console.WriteLine(string.Join(" ", array1));
        Console.WriteLine(string.Join(" ", array2));
    }
}

