//Write a program to sum given N numbers:
//· Read integer number n – the count of numbers to sum
//· Read n floating-point numbers and print their sum

using System.Diagnostics.CodeAnalysis;

int n =int.Parse(Console.ReadLine());   

double sum = 0;
 
for (int i = 0; i < n; i++)
{
    double curNum=double.Parse(Console.ReadLine());

 sum += curNum;
}
Console.WriteLine(sum);
