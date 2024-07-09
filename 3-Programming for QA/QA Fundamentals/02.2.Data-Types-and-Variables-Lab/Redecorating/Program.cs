using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace Redecorating
{
    internal class Program
    {
        static void Main(string[] args)
        {
//            Rumen wants to repaint the living room and has hired craftsmen for this purpose.Write a program that calculates the cost of the repair, taking the following prices for the calculation:
 //   • Protective nylon - 1.50 BGN per square meter
 //   • Paint - 14.50 BGN per liter
 //   • Paint thinner - 5.00 BGN per liter
 //           Just in case, to the necessary materials, Rumen wants to add another 10 % of the amount of paint and 2 square meters of nylon, also 0.40 leva for bags.The amount paid to the craftsmen for 1 hour of work is equal to 30 % of the sum of all material costs.
  //          Input
 //           The input is read from the console and contains exactly 4 lines:

   //             1.Required amount of nylon(in sq.m.) - an integer number in the range[1... 100]
            
  //              2.Required amount of paint(in liters) - an integer number in the range[1... 100]
            
  //              3.Quantity of thinner(in liters) - integer number in the range[1... 30]
            
 //               4.Hours needed for the craftsmen to do the work -an integer number in the range[1... 9]
  //          Output
 //           Print out only one line on the console:
 //   • "{the sum of all costs}"

            int nylon=int.Parse(Console.ReadLine());
            int paint=int.Parse(Console.ReadLine());
            int thinner=int.Parse(Console.ReadLine());
            int hours=  int.Parse(Console.ReadLine());

            double nylonPrice = 1.50;
            double paintPrice = 14.50;
            double thinnerPrice = 5.00;
            double bagsPrice = 0.40;

            double allNylonPrice=(nylon+2)*nylonPrice;
            double allPaintPrice = paint * 1.10 * paintPrice ;
            double allFinnerPrice = thinner * thinnerPrice;

            double materialPrice= allNylonPrice + allPaintPrice + allFinnerPrice + bagsPrice;

            double amountForCraftman = (materialPrice   * 0.3) * hours;
            double allAmounts = materialPrice + amountForCraftman;

            Console.WriteLine(allAmounts);


                    }
    }
}
