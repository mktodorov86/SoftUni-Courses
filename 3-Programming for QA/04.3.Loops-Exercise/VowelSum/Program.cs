//Write a program to sum N vowels, according to the table below:
//    • Read an integer number N: the count of characters
 //   • Read N characters and for each vowel character adds its value from the table to the result









int n = int.Parse(Console.ReadLine());

int sum = 0;

// Process each character
for (int i = 0; i < n; i++)
{
  
    char ch = char.Parse(Console.ReadLine().ToLower());

    // Add the value based on the vowel table
    switch (ch)
    {
        case 'a':
            sum += 1;
            break;
        case 'e':
            sum += 2;
            break;
        case 'i':
            sum += 3;
            break;
        case 'o':
            sum += 4;
            break;
        case 'u':
            sum += 5;
            break;
    }
}

// Print the result
Console.WriteLine($"{sum}");