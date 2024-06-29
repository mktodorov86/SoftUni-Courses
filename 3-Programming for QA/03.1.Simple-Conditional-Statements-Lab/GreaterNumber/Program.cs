//Write a program, that:
//    • Reads two integer numbers
//    • Finds the greater number
//    • Prints "Greater number: {greater number value}"
//Example

int number1=int.Parse(Console.ReadLine());
int number2=int.Parse(Console.ReadLine());  
if (number1 > number2) { Console.WriteLine($"Greater number: {number1}"); 
}
else if (number2 > number1)
        {
    Console.WriteLine($"Greater number: {number2}"); }