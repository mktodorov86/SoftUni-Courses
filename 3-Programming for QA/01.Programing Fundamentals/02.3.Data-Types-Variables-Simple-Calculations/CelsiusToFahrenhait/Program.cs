using System.Diagnostics.Metrics;

namespace CelsiusToFahrenhait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // · Read a floating - point number(the temperature in Celsius)

           // Convert given temperature in Fahrenheit(1 Fahrenheit = 1 Celsius * 1.8 + 32)

           // Print the temperature in Fahrenheit formatted to the 2nd digit after the decimal point

            double Celsius=double.Parse(Console.ReadLine());

            double Fahrenheit = Celsius * 1.8 + 32;

                Console.WriteLine(Fahrenheit.ToString("0.00"));


        }
    }
}
