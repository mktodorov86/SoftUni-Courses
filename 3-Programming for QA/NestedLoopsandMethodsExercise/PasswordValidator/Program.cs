//Write a program that checks if a given password is valid.
//• It should contain 6 – 10 characters (inclusive)
// • It should contain only letters and digits
// • It should contain at least 2 digits 
//• "Password must be between 6 and 10 characters"
//  • "Password must consist only of letters and digits"
//  • "Password must have at least 2 digits"


using System;
using System.Linq;

public class PasswordValidator
{
    public static void Main()
    {
        string password = Console.ReadLine();

        bool isValid = IsPasswordValid(password);

        if (isValid)
        {
            Console.WriteLine("Password is valid");
        }
        else
        {
            Console.WriteLine();
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!password.All(char.IsLetterOrDigit))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (password.Count(char.IsDigit) < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
    }

    // Method to validate the password
    public static bool IsPasswordValid(string password)
    {
        // Check length
        if (password.Length < 6 || password.Length > 10)
        {
            return false;
        }

        // Check if all characters are letters or digits
        if (!password.All(char.IsLetterOrDigit))
        {
            return false;
        }

        // Check if there are at least 2 digits
        if (password.Count(char.IsDigit) < 2)
        {
            return false;
        }

        return true;
    }
}
