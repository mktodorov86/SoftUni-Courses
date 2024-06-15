//   • From the console read: season(string), accommodation type(string) and count of the days (integer)
//     ◦ Season will be one of the following: "Spring", "Summer", "Autumn" and "Winter"
//      ◦ Accommodation type will be one of the following: "Hotel" and "Camping
//   • Based on the table below, you have to calculate expenses for the vacation with the given accommodation type, season and count of the days. 
//  • For the calculation: use price per night (extracted from the table below) multiplied by count of the days.
//  • Print the total expenses, formatted to the second digit after the decimal point

string season = Console.ReadLine();
string accomType = Console.ReadLine();
int countD = int.Parse(Console.ReadLine());

if (season == "Spring")
{
    if (accomType == "Hotel")
    {
        double totExpHotel = (30 * countD) * 0.80;
        Console.WriteLine($"{totExpHotel:F2}");
    }
    else if (accomType == "Camping")
    {
        double totExpCamp = (10 * countD) * 0.80;
        Console.WriteLine($"{totExpCamp:F2}");
    }
}
else if (season == "Summer")
{
    if (accomType == "Hotel")
    {
        double totExpHotel = (50 * countD);
        Console.WriteLine($"{totExpHotel:F2}");
    }
    else if (accomType == "Camping")
    {
        double totExpCamp = (30 * countD);
        Console.WriteLine($"{totExpCamp:F2}");
    }
}
else if (season == "Autumn")
{
    if (accomType == "Hotel")
    {
        double totExpHotel = (20 * countD) * 0.70;
        Console.WriteLine($"{totExpHotel:F2}");
    }
    else if (accomType == "Camping")
    {
        double totExpCamp = (15 * countD) * 0.70;
        Console.WriteLine($"{totExpCamp:F2}");
    }
}
else if (season == "Winter")
{
    if (accomType == "Hotel")
    {
        double totExpHotel = (40 * countD) * 0.90;
        Console.WriteLine($"{totExpHotel:F2}");
    }
    else if (accomType == "Camping")
    {
        double totExpCamp = (10 * countD) * 0.90;
        Console.WriteLine($"{totExpCamp:F2}");
    }
}