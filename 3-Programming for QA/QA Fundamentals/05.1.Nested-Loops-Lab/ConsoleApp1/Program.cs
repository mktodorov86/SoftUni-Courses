using System;

public class OrderCalculator
{
    // Method to calculate and print the total price of an order
    public static void CalculateTotalPrice(string product, int quantity)
    {
        // Define prices per item using a dictionary
        var prices = new Dictionary<string, double>
        {
            { "coffee", 1.50 },
            { "water", 1.00 },
            { "coke", 1.40 },
            { "snacks", 2.00 }
        };

        // Check if the product exists in the dictionary
        if (prices.ContainsKey(product))
        {
            double pricePerItem = prices[product];
            double totalPrice = pricePerItem * quantity;

            // Print the result formatted to two decimal places
            Console.WriteLine($"{totalPrice:F2}");
        }
        else
        {
            Console.WriteLine("Invalid product. Please enter one of: coffee, water, coke, snacks");
        }
    }

    public static void Main(string[] args)
    {
        // Read product and quantity from console input
        string product = Console.ReadLine()?.ToLower(); // Convert to lowercase for case-insensitive comparison
        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
        {
            // Call method to calculate and print total price
            CalculateTotalPrice(product, quantity);
        }
        else
        {
            Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
        }
    }
}
