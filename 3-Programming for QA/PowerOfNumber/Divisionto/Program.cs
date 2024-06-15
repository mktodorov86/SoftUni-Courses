
////Write a program to find statistics about division to 2, 3 and 4:
//   // • Read an integer number N and N integers from the console
  //  • Find in percentages how many of these integers can divide without a remainder to numbers 2, 3 and 4
  //  • Print the percentages, formatted to the second decimal digit:
     //   ◦ On the first line print percent of the numbers that are divisible by 2
      //  ◦ On the first line print percent of the numbers that are divisible by 3
      //  ◦ On the first line print percent of the numbers that are divisible by 4


int n = int.Parse(Console.ReadLine());

// Initialize counters for each divisibility check
int divisibleBy2 = 0;
int divisibleBy3 = 0;
int divisibleBy4 = 0;

// Read the integers and count divisibility
for (int i = 0; i < n; i++)
{
  
    int num = int.Parse(Console.ReadLine());

    if (num % 2 == 0)
        divisibleBy2++;
    if (num % 3 == 0)
        divisibleBy3++;
    if (num % 4 == 0)
        divisibleBy4++;
}

// Calculate percentages
double percentDivisibleBy2 = (double)divisibleBy2 / n * 100;
double percentDivisibleBy3 = (double)divisibleBy3 / n * 100;
double percentDivisibleBy4 = (double)divisibleBy4 / n * 100;

// Print the results formatted to the second decimal digit
Console.WriteLine($"{percentDivisibleBy2:F2}%");
Console.WriteLine($"{percentDivisibleBy3:F2}%");
Console.WriteLine($"{percentDivisibleBy4:F2}%");