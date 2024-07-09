
string movieType = Console.ReadLine();

int rows = int.Parse(Console.ReadLine());
int seatsPerRow = int.Parse(Console.ReadLine());
int totalSeats = rows * seatsPerRow;
double pricePerSeat = 0;

if (movieType == "Premiere")
{
    pricePerSeat = 12.00;
}
else if (movieType == "Normal")
{
    pricePerSeat = 7.50;
}
else if (movieType == "Discount")
{
    pricePerSeat = 5.00;
}
else
{
    Console.WriteLine("Invalid movie type");
    return;
}

double totalPrice = totalSeats * pricePerSeat;

Console.WriteLine($"Total price: {totalPrice:F2}");
    