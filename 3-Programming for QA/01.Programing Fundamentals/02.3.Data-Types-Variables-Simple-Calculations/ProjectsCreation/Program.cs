using System.Runtime.InteropServices;

namespace ProjectsCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // · Reads text (architecture's name) and integer number (count of projects for creation)

            //· Calculate how many hours will be needed for projects creation, if you know:

            //o one project creation takes 3 hours

            //· Print the data in the following format:

            //"The architect {architecture's name} will need {needed hours} hours to complete {count of projects for creation} project/s."

            string archName=Console.ReadLine();
            int number=int.Parse(Console.ReadLine());
            int projTime = number * 3;

            Console.WriteLine("The architect"+" "+archName + " "+"will need" +" "+ projTime.ToString("0.0000") + " "+ "hours to complete" + number +" " +"project/s.");           }
    }
}
