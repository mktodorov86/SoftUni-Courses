using Microsoft.VisualBasic;
using System.ComponentModel;

namespace CenturiestoMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
 //           Write a program that:
 //   • Reads an integer number, that represents centuries for conversion
//    • Convert centuries to years(1 century = 100 years)
  //  • Convert years to days(1 year = 365.2422 days)
 //   • Convert days to hours(1 day = 24 hours)
  //  • Convert hours to minutes(1 hour = 60 minutes)
  //  • Print converted data in the following format: 
//"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes"

            int centuries=int.Parse(Console.ReadLine());

            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");


        }
    }
}
