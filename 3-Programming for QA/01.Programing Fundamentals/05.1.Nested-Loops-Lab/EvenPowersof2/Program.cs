int n = int.Parse(Console.ReadLine());

// Print the even powers of 2 in the range [0; n]
for (int i = 0; i <= n; i += 2)
{
    // Calculate 2^i
    int powerOfTwo = (int)Math.Pow(2, i);
    // Print the result
    Console.WriteLine($"2^{i} = {powerOfTwo}");
}