namespace Pets_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
          // · Reads two integer numbers: count packages dog food and count packages cat food

            //  · Calculate the expenses for pet's food, if you know that:

                //o one package dog food costs 2.50 leva

            //o one package cat food costs 4.00 leva

            //· Print the calculated expenses formatted to 2nd digit in the following format:

            //"{expenses} lv."

            int dogFood=int.Parse(Console.ReadLine());
            int catFood=int.Parse(Console.ReadLine());
            double dogCosts = dogFood * 2.50;
           double catCosts = catFood * 4;
            double expenses = dogCosts+catCosts;
            Console.WriteLine(expenses.ToString("0.00") + " " + "lv" + ".");
           

        }
    }
}
