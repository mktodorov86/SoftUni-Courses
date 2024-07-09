using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System;

namespace Basketballequipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
       //     Jesse decides he wants to play basketball, but he needs equipment to train. Write a program that calculates the expenses of Jesse if he starts training, knowing how much is the fee for basketball training for a period of 1 year.
   //             • Basketball sneakers – their price is 40 % less than the fee for one year
  //  • Basketball team – its price is 20 % cheaper than that of sneakers
  //  • Basketball – its price is 1 / 4 of the price of the basketball team
  //  • Basketball accessories – their price is 1 / 5 of the price of the basketball
 //           Input
    //        From the console read 1 row:
 //   • The annual basketball training fee – an integer in the range[0... 9999]
 //           Output
  //          Print on the console how much Jesse will spend if he starts playing basketball.

            int backTrainFee=int.Parse(Console.ReadLine());

            double baskSneak = backTrainFee * 0.60;
          double baskTeam = baskSneak * 0.8;
            double basketball = baskTeam * 0.25;
     double baskAccess = basketball * 0.20;
            double startPLay=backTrainFee+baskSneak+baskTeam+basketball+baskAccess;

            Console.WriteLine(startPLay);

        }
    }
}
