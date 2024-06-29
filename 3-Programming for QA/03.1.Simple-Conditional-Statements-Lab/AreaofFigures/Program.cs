

//Write a program to calculate figure area, that: 
//    • Reads the type of the figure (string): "square", "rectangle" and "circle"
//    • Read:
//      ◦ If the figure is square: read one floating-point number, representing side of the square
//      ◦ If the figure is rectangle: read two floating-point numbers, representing width and length of the rectangle
//       ◦ If the figure is circle: read one floating-point number, representing radius of the circle
//   • Calculate area of the given figure
//       ◦ If the figure is square: area = side * side
//    ◦ If the figure is rectangle: area = width * length
//      ◦ If the figure is circle: area = pi * radius * radius
//• Prints the calculated area, formatted to the 2nd decimal

using System.ComponentModel.Design;

string figType =(Console.ReadLine());


if (figType == "square")
{
    double side = double.Parse(Console.ReadLine());
    double area = side * side;
    Console.WriteLine($"{area:F2}");
}

else if (figType == "rectangle")
{
    double width = double.Parse(Console.ReadLine());
    double lenght = double.Parse(Console.ReadLine());


    double rectArea = width * lenght;
    Console.WriteLine($"{rectArea:f2}");
}
else if (figType == "circle")
{
    double radCircle = double.Parse(Console.ReadLine());



    double circleArea = Math.PI * radCircle * radCircle;
    Console.WriteLine($"{circleArea:f2}");
}


