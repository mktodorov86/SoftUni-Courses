//Write a program that prints numbers in given range over 3: 
 //       ◦ Reads an integer number n – end of the range
  //      ◦ Prints all numbers from 1 to n, over 3 (inclusively)


int n = int.Parse(Console.ReadLine());

for (int i = 1; i <=n; i+=3)
{
    Console.WriteLine(i);

}