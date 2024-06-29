//A given number is valid if it is in the range [100...200] or it is equals to 0. 
//Write a program that:
//    • Reads an integer from the console
  //  • Prints "invalid" if the entered number is NOT valid

int number = int.Parse(Console.ReadLine());

if (number == 0 || number >= 100 && number <= 200)
{
    Console.WriteLine("");
}
else
{
    Console.WriteLine("invalid");
}
