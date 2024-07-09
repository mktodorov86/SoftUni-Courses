//Write a program to check if given number is special: 
//        ◦ Special numbers are divisible by all of their digits without remainder
//        ◦ Reads an integer number and check whether it is a special number
//      ◦ If the number IS special print: "{num} is special"
//     ◦ If the number is NOT special print: "{num} is not special"
//Note: There will not be numbers with digit 0 in them.


int number = int.Parse(Console.ReadLine());

// Copy of the original number for printing the result
int originalNumber = number;

// Flag to check if the number is special
bool isSpecial = true;

// Extract each digit and check divisibility
while (number > 0)
{
    int digit = number % 10;
    if (digit == 0 || originalNumber % digit != 0)
    {
        isSpecial = false;
        break;
    }
    number /= 10;
}

// Print the result
if (isSpecial)
{
    Console.WriteLine($"{originalNumber} is special");
}
else
{
    Console.WriteLine($"{originalNumber} is not special");
}