using System;
using System.Collections.Generic;

namespace Question_1
{
    public class BankQueue
    {
        Queue<string> customerQueue = new Queue<string>();

        public void AddCustomer(string customer)
        {
            customerQueue.Enqueue(customer);
            Console.WriteLine($"Customer with token added to the queue");
        }

        public string ServeCustomer()
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("No customers in the queue");
                return null;
            }
            else
            {
                Console.WriteLine($"Customer with token served");
                return customerQueue.Dequeue();
            }
        }

        public void PeekNextCustomer()
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("No customers in the queue");
            }
            else
            {
                Console.WriteLine($"Next customer in line is {customerQueue.Peek()}");
            }
        }
    }
}
