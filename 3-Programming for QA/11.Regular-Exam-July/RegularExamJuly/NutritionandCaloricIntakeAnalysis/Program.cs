using System;

namespace CaloricIntakeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the count of food items
            int N = int.Parse(Console.ReadLine());

            // If N is less than or equal to zero, print zero and return
            if (N <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            int cumulativeCalories = 0;

            // For each food item, read the caloric value and calculate the cumulative caloric intake
            for (int i = 0; i < N; i++)
            {
                int caloricValue = int.Parse(Console.ReadLine());
                cumulativeCalories += caloricValue;
                Console.WriteLine(cumulativeCalories);
            }
        }
    }
}
