using System;

class Program
{
    static void Main()
    {
        // Read the sequence of integers
        string inputSequence = Console.ReadLine();
        string[] numbers = inputSequence.Split();

        // Convert string array to integer array
        int[] sequence = Array.ConvertAll(numbers, int.Parse);

        // Read the number of rotations
        int rotations = int.Parse(Console.ReadLine());

        // Perform rotations
        for (int i = 0; i < rotations; i++)
        {
            int firstElement = sequence[0];

            // Shift elements to the left
            for (int j = 0; j < sequence.Length - 1; j++)
            {
                sequence[j] = sequence[j + 1];
            }

            // Move first element to the end
            sequence[sequence.Length - 1] = firstElement;
        }

        // Print the resulting sequence
        Console.WriteLine(string.Join(" ", sequence));
    }
}
