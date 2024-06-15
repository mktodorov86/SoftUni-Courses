//Write a program to check whether a triangle is valid, which:
////    • Reads three integers: the sides of a triangle
 //   • Checks if each side is shorter than the sum of the other two
  //  • Prints:
  ////      ◦ "Valid Triangle" if the above condition is met
   //     ◦ "Invalid Triangle" otherwise 

int sideA=int.Parse(Console.ReadLine());
int sideB=int.Parse(Console.ReadLine());
int sideC=int.Parse(Console.ReadLine());    

if (sideA + sideB > sideC && sideC + sideA > sideB && sideB + sideC > sideA) {
    Console.WriteLine("Valid Triangle");
        }
else
{
    Console.WriteLine("Invalid Triangle");
        }