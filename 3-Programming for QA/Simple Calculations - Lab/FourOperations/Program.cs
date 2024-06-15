using System.Collections.Generic;
using System.Drawing;

namespace FourOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //• Read two floating - point numbers: first number and second number
            // • Performs 4 arithmetic operations on the given 2 numbers, in the following order:
            //  ◦ Addition(+)
            //  ◦ Subtraction(-)
            //  ◦ Multiplication(*)
            //  ◦ Division(/)
            // • Print the results, all formatted to the 2nd digit,  in the following format:
            //  ◦ "{first number} + {second number} = {addition result}"
            // ◦ "{first number} - {second number} = {subtraction result}"
            //  ◦ "{first number} * {second number} = {multiplication result}"
            //  ◦ "{first number} / {second number} = {division result

            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            double addition = first + second;
            double substraction = first - second;
            double multiplication = first * second;
            double division = first / second;

            Console.WriteLine($"{first:F2} + {second:F2} = {addition:F2}");
            Console.WriteLine($"{first:F2} - {second:F2} = {substraction:F2}");
            Console.WriteLine($"{first:F2} * {second:F2} = {multiplication:F2}");
            Console.WriteLine($"{first:F2} / {second:F2} = {division:F2}");

        }
    }
}
