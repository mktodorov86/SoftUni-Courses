//   ◦ The first number is 1
////  ◦ Each next number is 2 times the previous number + 1
//◦ Read an integer number n from the console – the max number
// ◦ Print the elements of the sequence (starting with 1), which are ≤ n


int n = int.Parse(Console.ReadLine());

int currentNumber = 1;
string text = "1"; 
while (true)
{
    int nextNumber = currentNumber * 2 + 1;
    if (nextNumber <= n)
    {
        text += " " + nextNumber; 
        currentNumber = nextNumber; 
    }
    else
    {
        break; 
    }
}

Console.Write($"{ text}");