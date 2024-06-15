using System.Reflection.Metadata;

double radius =double.Parse(Console.ReadLine());
double pi = Math.PI;
double area = radius * radius * pi;
double perimeter = 2 * pi * radius;
Console.WriteLine("Area = " + area.ToString("0.00"));
Console.WriteLine("Perimeter = " +perimeter.ToString("0.00"));


