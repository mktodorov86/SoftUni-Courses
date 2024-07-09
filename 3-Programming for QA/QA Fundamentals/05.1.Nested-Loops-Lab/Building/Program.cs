int floorsCount = int.Parse(Console.ReadLine());


int estatesPerFloor = int.Parse(Console.ReadLine());

// Loop through each floor
for (int floor = floorsCount; floor >= 1; floor--)
{
    // Determine the type of estate based on the floor number
    char type;
    if (floor == floorsCount)
    {
        type = 'L'; // Last floor holds large apartments
    }
    else if (floor % 2 == 0)
    {
        type = 'O'; // Even floors hold offices
    }
    else
    {
        type = 'A'; // Odd floors hold apartments
    }

    // Loop through each estate on the current floor
    for (int number = 0; number < estatesPerFloor; number++)
    {
        // Generate the identifier
        string identifier = $"{type}{floor}{number}";

        // Print the identifier
        Console.Write($"{identifier} ");
    }

    // Print a new line after each floor
    Console.WriteLine();
}