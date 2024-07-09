//Write a program that checks if the company's office is open:
//   • Reads an hour of the day (integer number) and a day of the week (string)
////  • The office's working hours are from 10 AM to 6 PM, Monday through Saturday, inclusive.Monday, Tuesday, Wednesday, Thursday, Friday, Saturday and Sunday.
//    ◦ Print "open", if the office is open in the given hour and day of the week
//    ◦ Print "closed", if the office is closed in the given hour and day of the week

using System.ComponentModel.Design;

int hDay = int.Parse(Console.ReadLine());
string dWeek = Console.ReadLine();

if (hDay >= 10 && hDay <= 18)
{
    switch (dWeek)
    {
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
        case "Saturday":
            Console.WriteLine("open");
            break;
        case "Sunday":
            Console.WriteLine("closed");
            break;
    }
}
else
{ 
    Console.WriteLine("closed");

    }
