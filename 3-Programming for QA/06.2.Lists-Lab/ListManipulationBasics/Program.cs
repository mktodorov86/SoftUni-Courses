using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Read a list of integers from the console
        List<int> numbers = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

        // Process commands until "end" is received
        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] tokens = command.Split();
            string operation = tokens[0];

            switch (operation)
            {
                case "Add":
                    int numberToAdd = int.Parse(tokens[1]);
                    numbers.Add(numberToAdd);
                    break;
                case "Remove":
                    int numberToRemove = int.Parse(tokens[1]);
                    numbers.RemoveAll(num => num == numberToRemove);
                    break;
                case "RemoveAt":
                    int indexToRemove = int.Parse(tokens[1]);
                    numbers.RemoveAt(indexToRemove);
                    break;
                case "Insert":
                    int numberToInsert = int.Parse(tokens[1]);
                    int insertIndex = int.Parse(tokens[2]);
                    numbers.Insert(insertIndex, numberToInsert);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }

        // Print the final state of the list
        Console.WriteLine(string.Join(" ", numbers));
    }
}
