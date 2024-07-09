using static System.Reflection.Metadata.BlobBuilder;

namespace MandLit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //       6.Mandatory Literature
         //      For the summer holidays, there are a certain number of books on Joro's list of mandatory literature. Since Joro prefers to play with friends outside, your task is to help him calculate how many hours a day he should devote to reading the necessary literature.
          //Input
              //Read 3 lines from the console:
            //1.Number of pages in the current book – an integer in the range[1... 1000].
            //   2.Pages that he reads in 1 hour – an integer in the range[1... 1000].
            //   3.The number of days he needs to finish the book – an integer in the range[1... 1000].
            //Hint: For the operands of integer types, the result of the / operator is of an integer type and equals the quotient of the two operands rounded towards zero.
            //Output
            //Print on the console the number of hours that Joro has to spend reading each day.

            int pageBook = int.Parse(Console.ReadLine());
            int pageInHour = int.Parse(Console.ReadLine());
            int daysToFin = int.Parse(Console.ReadLine());

            int hoursTotal = pageBook / pageInHour;
            int hourDay =hoursTotal / daysToFin;
            Console.WriteLine(hourDay);
        }
    }
}
