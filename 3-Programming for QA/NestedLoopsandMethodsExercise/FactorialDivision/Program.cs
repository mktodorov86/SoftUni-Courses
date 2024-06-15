//  • Read two integers numbers from the console in range [1…10]
// • Calculate the factorial of each number
// • Divide the first calculated factorial by the second calculated factorial (integer division)
// • Print the result of the division



using System;

public class FactorialDivision
{
    public static void Main()
    {
    
        int firstNumber = int.Parse(Console.ReadLine());

        int secondNumber = int.Parse(Console.ReadLine());

 
        if (firstNumber < 1 || firstNumber > 10 || secondNumber < 1 || secondNumber > 10)
        {
      
            return;
        }


        int firstFactorial = CalculateFactorial(firstNumber);
        int secondFactorial = CalculateFactorial(secondNumber);

        int result = firstFactorial / secondFactorial;

 
        Console.WriteLine(result);
    }

  
    public static int CalculateFactorial(int number)
    {
        int factorial = 1;
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}
