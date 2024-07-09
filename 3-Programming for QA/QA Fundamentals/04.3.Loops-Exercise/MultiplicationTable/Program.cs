//Write a program that prints a multiplication table:
//   • Reads an integer number n from the console
//   • Print a multiplication table of size 10 for given integer n in the following format:
//           "{n} x {i} = {result}" for each i in the range[1…10]

int n = int.Parse(Console.ReadLine());

// Print the multiplication table for the given number
for (int i = 1; i <= 10; i++)
{
    int result = n * i;
    Console.WriteLine($"{n} x {i} = {result}");
}
