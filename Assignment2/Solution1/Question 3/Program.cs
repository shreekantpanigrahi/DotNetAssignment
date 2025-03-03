using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Question_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a program that allows users of an online shopping platform to
            //check their wallet balance. The platform stores multiple users with their
            //respective wallet balances.
            // Users can enter their user ID to check their balance
            // If the user enters wrong Id allow him to enter the proper Id(use
            //loops) until he enters correct one.
            // If Id is validated display the wallet balance.

            #region Dictionary solution


            //Dictionary<string, double> userWallets = new Dictionary<string, double>
            //{
            //    { "user1", 1000 },
            //    { "user2", 2000 },
            //    { "user3", 3000 },
            //    { "user4", 4000 },
            //    { "user5", 5000 }
            //};

            //bool validId = false;

            //while (!validId)
            //{
            //    Console.WriteLine("Enter your user ID to check your wallet balance:");
            //    string userId = Console.ReadLine();

            //    if (userWallets.ContainsKey(userId))
            //    {
            //        validId = true;
            //        Console.WriteLine($"Your wallet balance is: {userWallets[userId]}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid userId, Please type again!");
            //    }
            //    Console.WriteLine("Thank you for using walletbalance checker");
            //}
            #endregion

            #region Switch case solution
            bool valid = false;
            int userID = -1;

            while (!valid)
            {
                Console.WriteLine("Enter your user ID to check your wallet balance:");
                    if(int.TryParse(Console.ReadLine(), out userID))
                    {
                        switch (userID)
                        {
                            case 1:
                                Console.WriteLine("Your wallet balance is 10000");
                                valid = true;
                                break;
                            case 2:
                                Console.WriteLine("Your wallet balance is 20000");
                                valid = true;
                                break;
                            case 3:
                                Console.WriteLine("Your wallet balance is 30000");
                                valid = true;
                                break;
                            default:
                                Console.WriteLine("Invalid user ID. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid numeric value for userid");
                    }
            }
            Console.WriteLine("Thank you for using the online shopping platform!");

            #endregion
        }
    }
}
