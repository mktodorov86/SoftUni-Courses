
//  • Reads an integer number N from the console
//   • Generates all possible passwords consisting of the following 3 parts:
//     ◦ The first part is an even number in the range [2…N]
///     ◦ The second digit is an odd number in the range [1…N]
//    ◦ The third is the product of the first two
//• The output holds all possible passwords

using System;

public class Program
{
    public static void Main()
    {
        // Read the number from the console
        int number = int.Parse(Console.ReadLine());

        // Iterate through even numbers up to 'number'
        for (int i = 2; i <= number; i += 2)

            for (int j = 1; j <= number; j += 2)
            {
                int thirdDigit = i * j;


                Console.Write($"{i}{j}{thirdDigit} ");
            }
        }
    }

