  //  • Reads two integer numbers from the console
  //  • First integer number represents the start of the range
  //  • Second integer number represents the end of the range
   // • Print the numbers in the given range (include start and end number), each on the new line

//Note: The first given integer will always be smaller than the second given integer.


int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

for (int i = start; i <= end; i++)
{
    Console.WriteLine(i);
}