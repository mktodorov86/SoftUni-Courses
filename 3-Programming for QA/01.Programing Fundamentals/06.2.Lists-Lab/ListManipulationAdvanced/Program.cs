using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] tokens = command.Split();
            string operation = tokens[0];

            switch (operation)
            {
                case "Contains":
                    int numberToCheck = int.Parse(tokens[1]);
                    if (numbers.Contains(numberToCheck))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                    break;
                case "PrintEven":
                    Console.WriteLine(string.Join(" ", numbers.Where(num => num % 2 == 0)));
                    break;
                case "PrintOdd":
                    Console.WriteLine(string.Join(" ", numbers.Where(num => num % 2 != 0)));
                    break;
                case "GetSum":
                    Console.WriteLine(numbers.Sum());
                    break;
                case "Filter":
                    string condition = tokens[1];
                    int filterNumber = int.Parse(tokens[2]);
                    FilterNumbers(numbers, condition, filterNumber);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }

    static void FilterNumbers(List<int> numbers, string condition, int filterNumber)
    {
        switch (condition)
        {
            case "<":
                numbers.RemoveAll(num => num >= filterNumber);
                break;
            case ">":
                numbers.RemoveAll(num => num <= filterNumber);
                break;
            case ">=":
                numbers.RemoveAll(num => num < filterNumber);
                break;
            case "<=":
                numbers.RemoveAll(num => num > filterNumber);
                break;
            default:
                Console.WriteLine("Invalid condition.");
                break;
        }
    }
}
