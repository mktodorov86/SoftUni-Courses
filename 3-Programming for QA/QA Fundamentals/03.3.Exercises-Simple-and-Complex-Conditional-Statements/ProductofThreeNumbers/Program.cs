//Write a program that calculates the sign of the product of three numbers:
 //   • Reads 3 real numbers from the console
 //   • Print the sign of the product of the three given numbers: "positive", "negative" or "zero"
//Note: Try to do this without multiplying the numbers.

int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
int num3 = int.Parse(Console.ReadLine());

if (num1 * num2 * num3 > 0)
{
    Console.WriteLine("positive");
}
if (num1 * num2 * num3 < 0)
{
    Console.WriteLine("negative");
}
if (num1 * num2 * num3 == 0)
{
    Console.WriteLine("zero");
}