using System.Collections.Generic;
using System.Drawing;

namespace Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //     • You have a rectangular bathroom of size W x H
            // • We want to cover it with tiles of size Wt x Ht
            //• Read four floating - point numbers:
             //  ◦ First represents bathroom width(W)
           //  ◦ Second represents bathroom height(H)
             //  ◦ Third represents tile width(Wt)
              // ◦ Forth represents tile height(Ht)
           // • Calculate how many tiles will be needed(add 10 % surplus)
             //  • Print the count of the needed tiles, rounded to the nearest integer

            double w=double.Parse(Console.ReadLine());  
            double h=double.Parse(Console.ReadLine());  
            double wt=double.Parse(Console.ReadLine());
            double ht=double.Parse(Console.ReadLine());

            double bathArea = w * h;
            double tileArea= wt * ht;
            double tileNeed = bathArea / tileArea;
            double addSur = tileNeed * 1.10;


            Console.WriteLine($"{addSur:F0}");



        }
    }
}
