// ◦ Read a sequence of incomes / expenses, until "End" is read
// ◦ Add the money to the balance (starting form 0)
//  ◦ Print "Increase: {money}" or "Decrease: {money}", where value is formatted to the second decimal digit
//  ◦ Finally, print the account balance, formatted to the second decimal digit in the following format: "Balance: {account balance}"


double balance = 0.0;

while (true)
{
    // Read the next input from the console
    string input = Console.ReadLine();

    // Check for the end condition
    if (input == "End")
    {
        break;
    }

    // Convert input to double
    double money;
    if (double.TryParse(input, out money))
    {
        // Update balance and print the corresponding message
        if (money > 0)
        {
            balance += money;
            Console.WriteLine($"Increase: {money:F2}");
        }
        else
        {
            balance += money;  // Adding a negative number (expense)
            Console.WriteLine($"Decrease: {Math.Abs(money):F2}");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid number or 'End' to finish.");
    }
}

// Print the final balance
Console.WriteLine($"Balance: {balance:F2}");
