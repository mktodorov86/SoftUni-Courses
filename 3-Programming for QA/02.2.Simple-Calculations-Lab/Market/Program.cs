using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            Write a program that:
            //    • You have a farmer sells tomatoes and cucumbers at the market
            //    • Read four floating - point numbers:
 //           First represents tomato price
//        ◦ Second represents tomato quantity
//       ◦ Third represents cucumber price
//       ◦ Forth represents cucumber quantity
//    • Calculate the total cost of the production by given quantities and prices
//   • Print the total cost, formatted to the 2nd digit
           

           double tomPrice = double.Parse(Console.ReadLine());
           double tomQuan = double.Parse(Console.ReadLine());
            double cucPrice = double.Parse(Console.ReadLine());
            double cucQuan = double.Parse(Console.ReadLine());
            double tomatoes = tomPrice * tomQuan;
            double cucumber = cucPrice * cucQuan;
            double totalCost=tomatoes+cucumber;
            Console.WriteLine($"{totalCost:F2}");
         



        }
    }
}
