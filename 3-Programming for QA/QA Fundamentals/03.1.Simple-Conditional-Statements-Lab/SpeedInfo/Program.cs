  //  • Reads a floating-point number (speed)
 //   • Prints:
   //     ◦ "Slow" - if the number <= 30
   //     ◦ "Fast" - if the number > 30

double speed=double.Parse(Console.ReadLine());

if  (speed <= 30)
{
    Console.WriteLine("Slow");
}
else if (speed > 30)
{
    Console.WriteLine("Fast");
}