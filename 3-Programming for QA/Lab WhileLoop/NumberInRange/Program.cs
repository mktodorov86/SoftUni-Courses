// ◦ Read an integer number from the console
// ◦ Check if the number is in the range [1 … 100]
//    ▪ No(number is NOT in the range)  read a new number
//    ▪ Yes(number is IN the range)  print the number and the program stops
do
{
    int number = int.Parse(Console.ReadLine());

    if (number >= 1 && number <= 100)
    {
        Console.WriteLine(number); break;


    }
}
while (true);