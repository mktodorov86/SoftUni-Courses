////Write a program to find the biggest among given n numbers:
//  • Read an integer number n (the amount of input numbers) and n integer numbers from the console
//  • Find and print the biggest number

int n = int.Parse(Console.ReadLine());

// Initialize the largest number with the minimum possible value
int largest = int.MinValue;

// Read the integers and find the largest one
for (int i = 0; i < n; i++)
{

    int num = int.Parse(Console.ReadLine());
    if (num > largest)
    {
        largest = num;
    }
}

// Print the largest number
Console.WriteLine($"{largest}");
