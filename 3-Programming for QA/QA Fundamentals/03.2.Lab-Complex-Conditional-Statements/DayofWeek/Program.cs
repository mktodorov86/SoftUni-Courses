

//Write a program to print the day of week as words, which:
//    • Based on the value of the number, print:
////       ◦ If the given number is equals to 1 print the first day of the week, which is "Monday"
//       ◦ If the given number is equals to 2 print the second day of the week, which is "Tuesday"
//  ◦ If the given number is equals to 3 print the third day of the week, which is "Wednesday"
// /   ◦ If the given number is equals to 4 print the fourth day of the week, which is "Thursday"
//  ◦ If the given number is equals to 5 print the fifth day of the week, which is "Friday"
//   ◦ If the given number is equals to 6 print the sixth day of the week, which is "Saturday"
///   ◦ If the given number is equals to 7 print the seventh day of the week, which is "Sunday"
//   ◦ If the given number is out of the given range print "Error"
int dayNumber = int.Parse(Console.ReadLine());

if (dayNumber == 1)
{
    Console.WriteLine("Monday");
}
else if (dayNumber == 2)
{
    Console.WriteLine("Tuesday");
}
else if (dayNumber == 3)
{
    Console.WriteLine("Wednesday");
}
else if (dayNumber == 4)
{
    Console.WriteLine("Thursday");
}
else if (dayNumber == 5)
{
    Console.WriteLine("Friday");
}
else if (dayNumber == 6)
{
    Console.WriteLine("Saturday");
}
else if (dayNumber == 7)
{
    Console.WriteLine("Sunday");
}
else
{
    Console.WriteLine("Error");
}
    