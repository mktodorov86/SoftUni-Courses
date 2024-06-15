//   ◦ Read an integer positive number from the console
//    ◦ Sum its digits and print the sum
//Example: The number is 3451. Digits sum is 3 + 4 + 5 + 1 = 13.

int number = int.Parse(Console.ReadLine());

int sum = 0;
while (number > 0)
{
    sum += number % 10;
    number /= 10;
}

Console.WriteLine($" {sum}");
