   // • Reads an integer number N
 //   • Print the numbers from N down to 1 (inclusively), each on separate line
//Note: N will always be bigger than 1.


int number =
int.Parse(Console.ReadLine());
while (number >= 1)
{
    Console.WriteLine(number);number--;
}