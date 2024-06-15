using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace ConvertorUSDtoEUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //· Read a floating - point number: the dollars to be converted

            //· Convert dollars to euro(use fixed rate of dollars to euro: 0.88)

            //· Print the converted value in euro formatted to the 2nd digit

            double dollars=double.Parse(Console.ReadLine());
            double dollarToEuro =  dollars * 0.88;
            Console.WriteLine(dollarToEuro.ToString("0.00"));
        }
    }
}
