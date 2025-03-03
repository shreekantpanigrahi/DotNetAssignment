using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Question_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that Facilitates online train ticket booking and
            //calculates the total cost. Display ticket types(General - 200, Ac - 1000rs,
            //sleeper - 500), decide the price as per your wish, ask the user to input the
            //type and number of tickets they want and calculate the total cost.
            // User can book multiple tickets until he types exit(use appropriate
            //loop and statements).

            #region My solution with if else

            Console.WriteLine("Available Ticket Types:");
            Console.WriteLine("1. General - 200 INR");
            Console.WriteLine("2. AC - 1000 INR");
            Console.WriteLine("3. Sleeper - 500 INR");
            Console.WriteLine("Type 'exit' to stop booking.");

            int general = 200;
            int ac = 1000;
            int sleeper = 500;
            int totalCost = 0;

            Console.WriteLine("Enter the type of ticket you want to book:");
            string ticketType = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the number of tickets you want to book:");
            int numberOfTickets= int.Parse(Console.ReadLine());

            if(ticketType == "general")
            {
                totalCost = general * numberOfTickets;
            }
            else if(ticketType == "ac")
            {
                totalCost = ac * numberOfTickets;
            }
            else if (ticketType == "sleeper")
            {
                totalCost = sleeper * numberOfTickets;
            }
            else if(ticketType == "exit")
            {
                Console.WriteLine("You have chosen to exit the booking.");

            }

            Console.WriteLine("The total cost of the tickets is: " + totalCost);

            #endregion


        }
    }
}
