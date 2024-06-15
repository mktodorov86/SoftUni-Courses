
        //Write a program to calculate ticket price, that:
        //    • Prints the price in the following format "${price}":
        //      ◦ Student ticket price: 1.00
        //      ◦ Regular ticket price: 1.60
        //      ◦ For invalid type: "Invalid ticket type!"
        string ticketPrice = (Console.ReadLine());
        string student = "1.00";
        string regular = "1.60";



        if ( ticketPrice == "student") 
{
    Console.WriteLine($"${student}");
}


        else if(ticketPrice == "regular")
    {
        Console.WriteLine($"${regular}");
    }
    else
    {
        Console.WriteLine("Invalid ticket type!");
    }

 