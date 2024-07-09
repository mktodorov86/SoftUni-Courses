//Write a program for checking a password, that:
//  • Reads a string that represents a password
//   • Prints:
//      ◦ "Welcome" if the password is "s3cr3t!"
//      ◦ "Wrong password!" in all other cases 

string pass = (Console.ReadLine());
if (pass == "s3cr3t!")
{
    Console.WriteLine("Welcome");
}
else
{ Console.WriteLine("Wrong password!"); }
