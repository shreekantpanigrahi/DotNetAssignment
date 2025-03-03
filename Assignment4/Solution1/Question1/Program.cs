using System.Runtime.Intrinsics.X86;

namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Develop a C# program where you need to track the total number of users
            //who have logged in. The number should persist even if different users log
            //in.(use static Field and achieve the functionality)

            Login user1 = new Login();
            Login user2 = new Login();
            Login user3 = new Login();

            Console.WriteLine($"The totalLogins is {Login.GetTotalLogins()}");

            Console.WriteLine($"The Login time for user 1: {user1.GetLoginTime()}");
            Console.WriteLine($"The Login time for user 2: {user2.GetLoginTime()}");
            Console.WriteLine($"The Login time for user 3: {user3.GetLoginTime()}");

        }
    }
}
