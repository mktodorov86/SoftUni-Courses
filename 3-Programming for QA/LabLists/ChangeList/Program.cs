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

            if (operation == "Delete")
            {
                int element = int.Parse(tokens[1]);
                numbers.RemoveAll(num => num == element);
            }
            else if (operation == "Insert")
            {
                int element = int.Parse(tokens[1]);
                int position = int.Parse(tokens[2]);
                numbers.Insert(position, element);
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
