using System;
using System.Collections.Generic;

namespace CaloricIntakeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //            • Reads an integer number N(count of the food items) from the console.
            // • For each food item(from first to the last (N)):
            //     ◦ Read from the console the caloric value(integer number) of the food item.
            //     ◦ Calculate the cumulative caloric intake after adding each food item.
            //    ◦ Print the cumulative caloric intake on a separate line.
            //   ◦ In case of N equal to or less than zero should print zero as result.
            //     // Read the count of food items
            int N = int.Parse(Console.ReadLine());

            if (N <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            int cumulativeCalories = 0;


            for (int i = 0; i < N; i++)
            {
                int caloricValue = int.Parse(Console.ReadLine());
                cumulativeCalories += caloricValue;
                Console.WriteLine(cumulativeCalories);
            }
        }
    }
}
