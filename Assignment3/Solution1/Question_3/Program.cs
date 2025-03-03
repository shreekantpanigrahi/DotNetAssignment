using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            if (IsValidPassword(password))
            {
                Console.WriteLine("Password is valid!");
                break; 
            }
        }
    }

    static bool IsValidPassword(string password)
    {
        if (password.Length < 6)
        {
            Console.WriteLine("Password must be at least 6 characters long.");
            return false;
        }

        if (!ContainsUppercase(password))
        {
            Console.WriteLine("Password must have at least one uppercase letter.");
            return false;
        }

        if (!ContainsDigit(password))
        {
            Console.WriteLine("Password must have at least one digit.");
            return false;
        }

        return true;
    }

    static bool ContainsUppercase(string text)
    {
        foreach (char c in text)
        {
            if (char.IsUpper(c))
                return true;
        }
        return false;
    }

    static bool ContainsDigit(string text)
    {
        foreach (char c in text)
        {
            if (char.IsDigit(c))
                return true;
        }
        return false;
    }
}
