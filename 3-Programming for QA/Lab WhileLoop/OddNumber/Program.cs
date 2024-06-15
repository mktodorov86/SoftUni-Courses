// ◦ Read numbers from the console until an odd number is entered
// ◦ Print the odd number as output


int num = int.Parse(Console.ReadLine());
while (num % 2 == 0)
{
    // The number is not odd → read a new one
    num = int.Parse(Console.ReadLine());
}
Console.WriteLine(num);