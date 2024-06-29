using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read the number of products

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer.");
            return;
        }

        // Read the products
        List<string> products = new List<string>();
        for (int i = 0; i < n; i++)
        {

            string product = Console.ReadLine();
            products.Add(product);
        }

        // Sort the products alphabetically
        products.Sort();

        // Print the numbered list of products

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{products[i]}");
        }
    }
}
