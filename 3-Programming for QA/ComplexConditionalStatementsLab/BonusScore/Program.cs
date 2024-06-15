int number = int.Parse(Console.ReadLine());

if (number <= 3)
{
    int bonus5 = number + 5;
    Console.WriteLine($"{bonus5}");
}
else if (number >= 4 && number <= 6)
{
    int bonus15 = number + 15;
    Console.WriteLine($"{bonus15}");
}
else if (number >= 7 && number <= 9)
{
    int bonus20 = number + 20;
    Console.WriteLine($"{bonus20}");

}