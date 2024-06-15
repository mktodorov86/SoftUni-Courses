// ◦ Read an initial number from the input
// ◦ Read an execute a sequence of the following commands:
//     ▪ "Inc" – add 1 to the number (increment)
//    ▪ "Dec" – subtract 1 from the number (decrement)
//   ▪ "End" – print the number and stop the program

int number = int.Parse(Console.ReadLine());

while (true)
{
    string command = Console.ReadLine();

    switch (command)
    {
        case "Inc":
            number++;
            break;
        case "Dec":
            number--;
            break;
        case "End":
            Console.WriteLine(number);
            return; // Stop the program
        default:
            Console.WriteLine("Invalid command. Please enter \"Inc\", \"Dec\", or \"End\".");
            break;
    }
}

