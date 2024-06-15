//  • Reads three integer numbers (num1, num2 and num3) from the console
//  •  Finds if num1 * num2 * num3 (the product) is negative, positive or zero
//  • Print:
//   ◦ negative - if the product is smaller than 0
//   ◦ positive - if the product is bigger than 0
//  ◦ zero - if the product is equals to 0
//Note: Try to do this WITHOUT multiplying the three numbers.


internal class Program
{
    private static void Main(string[] args)
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());

        if (num1 * num2 * num3 < 0)
            Console.WriteLine("negative");
        else if (num1 * num2 * num3 == 0)
        
            Console.WriteLine("zero");


else if (num1 * num2 * num3 > 0)
            
                Console.WriteLine("positive");
            }
        }

