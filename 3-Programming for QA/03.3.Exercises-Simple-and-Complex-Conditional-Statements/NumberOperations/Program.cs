// • Reads 2 real numbers and math operator (string) from the console
//  • Possible given values for the math operator are: "+", "-", "*", "/"
//  • Apply the operator with given numbers
//    • Print output in the following format, where result is formatted to the second digit:
//"{N1} {operator} {N2} = {result}"


int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
char mathO = char.Parse (Console.ReadLine());

if (mathO == '+' )
{
  int res = num1 + num2;
    Console.WriteLine($"{num1} {mathO} {num2} = {res:f2}");
}
if (mathO == '-')
{
    int res = num1 - num2;
    Console.WriteLine($"{num1} {mathO} {num2} = {res:f2}");

}
if (mathO == '*')
{
    int res = num1 * num2;
    Console.WriteLine($"{num1} {mathO} {num2} = {res:f2}");
}
if (mathO == '/')
{
    int res = num1 / num2;
    Console.WriteLine($"{num1} {mathO} {num2} = {res:f2}");
}