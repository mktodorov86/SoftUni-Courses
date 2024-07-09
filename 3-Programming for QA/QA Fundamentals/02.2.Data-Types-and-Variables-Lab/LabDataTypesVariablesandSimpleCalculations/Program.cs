using System.ComponentModel;
using System.Drawing;

namespace LabDataTypesVariablesandSimpleCalculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
 //           Write a program that:
  //  • Reads three floating - point numbers from the console
  //  • Print them in reversed order, each number on a new line

            double one=double.Parse(Console.ReadLine());
            double two=double.Parse(Console.ReadLine());    
            double three=double.Parse(Console.ReadLine());

            Console.WriteLine(three);
            Console.WriteLine(two);
            Console.WriteLine(one);



        }
    }
}
