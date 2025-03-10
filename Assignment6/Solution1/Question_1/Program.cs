using static Question_1.BankQueue;

namespace Question_1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //A bank has a token system where customers take a token and are served in the order they arrived. You need to:
            //Add new customers to the queue. Serve customers in a First In, First Out(FIFO) order.Check who is next in line without removing them.
            BankQueue bankQueue = new BankQueue();
            bankQueue.AddCustomer("Alice");
            bankQueue.AddCustomer("Bob");
            bankQueue.AddCustomer("Cat");

            bankQueue.PeekNextCustomer();

            bankQueue.ServeCustomer();
            bankQueue.PeekNextCustomer();


            bankQueue.ServeCustomer();
            bankQueue.PeekNextCustomer();


            bankQueue.ServeCustomer();
            bankQueue.PeekNextCustomer();   

        }
    }
    
}
