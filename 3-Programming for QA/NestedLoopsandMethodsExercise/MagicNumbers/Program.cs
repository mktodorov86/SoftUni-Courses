//   • Reads an integer number N from the console
//   • Find all 3-digit magic numbers

//Note: A magic number is a three - digit number where the
//    product of its digits equals the value of N. If you have
//   a three-digit number abc, where a, b and c are its digits,
//   it is considered a magic number of order N,  if a * b * c = N.


using System;

public class MagicNumbers
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        if (N <= 0)
        {
            Console.WriteLine("N must be a positive integer.");
            return;
        }


        for (int number = 100; number <= 999; number++)
        {
            int digit1 = number / 100;        
            int digit2 = (number / 10) % 10;  
            int digit3 = number % 10;        

     
            if (digit1 * digit2 * digit3 == N)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
