//        ◦ Reads an integer number from the console: the "stop number"
//    ◦ Keep reading integers until it finds the stop number
//    ◦ When the stop number is found, increase the value of the previous number before it with 20% and print it

int stopNumber = int.Parse(Console.ReadLine());

// Initialize variables
int previousNumber = 0;
bool isFirstNumber = true;

while (true)
{
    // Read the next integer from the console
   
    int currentNumber = int.Parse(Console.ReadLine());

    if (currentNumber == stopNumber)
    {
        if (isFirstNumber)
        {
            Console.WriteLine("No previous number to apply a bonus.");
        }
        else
        {
            // Apply 20% bonus to the previous number
            double bonus = previousNumber * 0.20;
            double result = previousNumber + bonus;
            Console.WriteLine($"{result}");
        }
        break;
    }

    // Update the previous number and set the first number flag to false
    previousNumber = currentNumber;
    isFirstNumber = false;
}