//Write a program that:
//    • Reads 3 integer numbers from the console
 //   • Prints the largest number

int first =int.Parse(Console.ReadLine());
int second =int.Parse(Console.ReadLine());  
int third =int.Parse(Console.ReadLine());

if (first > second && first > third)
    Console.WriteLine($"{first}");
else if (second > third && second > first) Console.WriteLine($"{second}");
else
    Console.WriteLine($"{third}");