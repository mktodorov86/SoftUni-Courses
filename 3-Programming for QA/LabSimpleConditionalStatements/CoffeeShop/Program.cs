string drinkName = Console.ReadLine();
string sugOrNo = Console.ReadLine();

double cofeePrice = 1.00;
double teaPrice = 0.60;
double sugarPrice = 0.40;
double noPrice = 0.00;

if (drinkName == "coffee" && sugOrNo == "sugar")
{
    double cofeeSug = cofeePrice + sugarPrice;
    Console.WriteLine($"Final price: ${cofeeSug:F2}");
}
else if (drinkName == "coffee" && sugOrNo == "no")
{
    double cofeeNo = cofeePrice + noPrice;
    Console.WriteLine($"Final price: ${cofeeNo:F2}");
}
else if (drinkName == "tea" && sugOrNo == "sugar")
{
    double teaSug = teaPrice + sugarPrice;
    Console.WriteLine($"Final price: ${teaSug:F2}");
}
else if (drinkName == "tea" && sugOrNo == "no")
{
    Console.WriteLine($"Final price: ${teaPrice:F2}");
}