//• Reads two strings from the console: product(string) and day(string).
//  • Print the price, formatted to the second digit, based on the price table:

string product = (Console.ReadLine());
string dayOfweek = (Console.ReadLine());

if (product == "Kiwi")
{
    if (dayOfweek == "Weekday")
        Console.WriteLine("2.20");
    else
    {
        Console.WriteLine("3.00");
    }
}
else if (product == "Apple")
{
    if (dayOfweek == "Weekday")
        Console.WriteLine("1.30");
    else
    {
        Console.WriteLine("1.60");
    }
}
else if (product == "Banana")
{
    if (dayOfweek == "Weekday")
        Console.WriteLine("2.50");
    else
    {
        Console.WriteLine("2.70");
    }
}
