using System;

namespace DayofWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  • Reads an integer number from the console
            //  • If the number is in range[1…7] print:
            //    ◦ "Monday" for number 1
            //    ◦ "Tuesday" for number 2
            //   ◦ "Wednesday" for number 3
            //  ◦ "Thursday" for number 4
            //   ◦ "Friday" for number 5
            //   ◦ "Saturday" for number 6
            //   ◦ "Sunday" for number 7
            // • If the number is out of the given range print "Invalid day!"

            string input = Console.ReadLine();
            int number;

            // Array to store the days of the week
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            // Try to parse the input to an integer
            if (int.TryParse(input, out number))
            {
                // Check if the number is within the valid range
                if (number >= 1 && number <= 7)
                {
                    // Access the corresponding day from the array
                    Console.WriteLine(daysOfWeek[number - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid day!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid integer.");
            }
        }
    }
}
