using System;

class Program
{
    static void Main()
    {
        // Read the sequence of integers
        string inputSequence = Console.ReadLine();
        string[] numbers = inputSequence.Split();
        int[] sequence = Array.ConvertAll(numbers, int.Parse);

        // Variables to track the longest sequence
        int maxLength = 0;
        int startIndex = 0;
        int currentLength = 1;
        int currentStartIndex = 0;

        // Iterate through the sequence to find the longest sequence of equal elements
        for (int i = 1; i < sequence.Length; i++)
        {
            if (sequence[i] == sequence[i - 1])
            {
                currentLength++;

                // Update the start index of the current sequence
                if (currentLength == 2)
                {
                    currentStartIndex = i - 1;
                }
            }
            else
            {
                // Check if the current sequence is the longest found so far
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startIndex = currentStartIndex;
                }

                // Reset for the next sequence
                currentLength = 1;
                currentStartIndex = i;
            }
        }

        // Check the last sequence in case it was the longest
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            startIndex = currentStartIndex;
        }

        // Output the longest sequence of equal elements
        for (int i = startIndex; i < startIndex + maxLength; i++)
        {
            Console.Write(sequence[i] + " ");
        }
        Console.WriteLine();
    }
}
