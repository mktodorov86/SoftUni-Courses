
int temperature = int.Parse(Console.ReadLine());
string timeOfDay = Console.ReadLine();


string clothing = "";
string shoes = "";


if (timeOfDay == "Morning")
{
    if (temperature >= 10 && temperature <= 18)
    {
        clothing = "Sweatshirt";
        shoes = "Sneakers";
    }
    else if (temperature > 18 && temperature <= 24)
    {
        clothing = "Shirt";
        shoes = "Moccasins";
    }
    else if (temperature >= 25 && temperature <= 42)
    {
        clothing = "T-Shirt";
        shoes = "Sandals";
    }
}
else if (timeOfDay == "Afternoon")
{
    if (temperature >= 10 && temperature <= 18)
    {
        clothing = "Shirt";
        shoes = "Moccasins";
    }
    else if (temperature > 18 && temperature <= 24)
    {
        clothing = "T-Shirt";
        shoes = "Sandals";
    }
    else if (temperature >= 25 && temperature <= 42)
    {
        clothing = "Swim Suit";
        shoes = "Barefoot";
    }
}
else if (timeOfDay == "Evening")
{
    clothing = "Shirt";
    shoes = "Moccasins";
}


Console.WriteLine($"It's {temperature} degrees, get your {clothing} and {shoes}.");
    }
}