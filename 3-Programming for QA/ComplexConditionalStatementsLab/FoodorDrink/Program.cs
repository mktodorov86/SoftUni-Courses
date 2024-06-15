//Write a program that:
//   • Reads a product (string) from the console
//   • Based on type of the given product, print:
//   ◦ If product is one of following "tea", "water", "coffee" or "juice" you have to print "drink"
//   ◦ If the product is different from listed products above, print "unknown"

///      ◦ If product is one of following "curry", "noodles", "sushi", "spaghetti" or "bread" you have to print "food"
string product = Console.ReadLine();

if (product == "curry" || product == "noodles" || product == "sushi" || product == "spaghetti" || product == "bread")
{
    Console.WriteLine("food");
}
else if 
    (product == "tea" || product == "water" || product == "coffee" || product == "juice") 
{
    Console.WriteLine("drink");
}
else
{
    Console.WriteLine("unknown");
}
