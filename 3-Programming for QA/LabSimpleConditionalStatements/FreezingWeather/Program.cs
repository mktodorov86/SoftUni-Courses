using System.ComponentModel;
using System.Reflection.Metadata;

namespace FreezingWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
  //          Write a program to check for freezing water, that:
  //  • Reads an integer number(temperature in Celsius)
   // • Checks whether the temperature is below zero
  //  • Prints "Freezing weather!", if the temperature is equal or smaller than 0

            int tempC=int.Parse(Console.ReadLine());

            if (tempC <= 0) Console.WriteLine("Freezing weather!");
        }
    }
}
