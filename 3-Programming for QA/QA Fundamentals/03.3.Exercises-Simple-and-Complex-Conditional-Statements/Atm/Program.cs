  //• Reads 3 integer numbers which represents the following values: balance, withdraw and limit
 //   • Based on the given input parameters:
  //      ◦ Print "The withdraw was successful.", if the balance is enough
  //      ◦ Print "The limit was exceeded.", if the limit is exceeded
  //      ◦ Print "Insufficient availability.", if the balance isn't enough

int balance = int.Parse(Console.ReadLine());
int withdraw =  int.Parse(Console.ReadLine()); 
int limit  = int.Parse(Console.ReadLine()); 

if  (balance > limit && balance > withdraw)
{
    Console.WriteLine("The withdraw was successful.");
}
else if ( limit < withdraw)
{
    Console.WriteLine("The limit was exceeded.");
}
else if (balance < withdraw)
{
    Console.WriteLine("Insufficient availability.");
}