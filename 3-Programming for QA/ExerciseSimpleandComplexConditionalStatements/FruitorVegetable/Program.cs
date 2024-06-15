// • Reads a product (string) from the console
// • Based on type of the given product, print:
//    ◦ If product is one of following "banana", "apple", "kiwi", "cherry" or "lemon" you have to print "fruit"
//    ◦ If product is one of following "cucumber", "pepper" or "carrot" you have to print "vegetable"
//    ◦ If the product is different from listed products above, print "unknown"

using System.ComponentModel.Design;

string product =Console.ReadLine();

if (product == "banana" || product == "apple" || product == "kiwi" || product == "cherry" || product == "lemon")
{
    Console.WriteLine("fruit");
}
else if (product == "cucumber" || product == "pepper" || product == "carrot")
{
    Console.WriteLine("vegetable");
}
else
{
    Console.WriteLine("unknown");
}