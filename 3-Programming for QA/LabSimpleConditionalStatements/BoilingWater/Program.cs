//Write a program to check for boiling water, that: 
 //       ◦ Reads an integer number: the water temperature (in °C)
 //       ◦ Prints: 
 //               • "The water is boiling" if the number > 100
 //               • "The water is not hot enough" in all other cases

int tempC=int.Parse(Console.ReadLine());

if (tempC > 100)
{
    Console.WriteLine("The water is boiling");
}
else
{
    Console.WriteLine("The water is not hot enough");
}