//Write a program that:
  //  • Reads an integer number from the console
  // • Based on the given number:
    //    ◦ Print "negative", if the number is lower than zero
       // ◦ Print "positive ", if the number is bigger than zero
       // ◦ Print "zero ", if the number is equaл

int number=int.Parse(Console.ReadLine());

if (number < 0)
{
    Console.WriteLine("negative");
}
else if (number > 0)
{
    Console.Write("positive");
}


else if  (number == 0)
{
    Console.WriteLine("zero");
}