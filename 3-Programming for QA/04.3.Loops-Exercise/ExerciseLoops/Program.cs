//   • Reads an integer number n from the console
//    • Reads an integer number p which represents power from the console
//    • Print the result of n to the power of p
//Note: Don't use Math.Pow(), use loopsnamespace ExerciseLoops


int n = int.Parse(Console.ReadLine());


int p = int.Parse(Console.ReadLine());

// Calculate n to the power of p using a loop
int result = 1;
for (int i = 0; i < p; i++)
{
    result *= n;
}

// Print the result
Console.WriteLine($"{result}");