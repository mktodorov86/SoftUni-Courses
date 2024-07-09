int n = int.Parse(Console.ReadLine());

// Initialize a counter for the current number to print
int currentNumber = 1;

// Loop through each level of the pyramid
for (int row = 1; currentNumber <= n; row++)
{
    // Loop through each position in the current row
    for (int col = 1; col <= row && currentNumber <= n; col++)
    {
        // Print the current number and increment the counter
        Console.Write(currentNumber + " ");
        currentNumber++;
    }
    // Move to the next line after each row
    Console.WriteLine();
}