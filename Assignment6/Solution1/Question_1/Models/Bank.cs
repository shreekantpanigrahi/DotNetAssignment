using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1.Models
{
    public string Customer { get; set; };
    class Bank
    {
        Queue<string> customerQueue = new Queue<string>();

        public void AddCustomer(string customer)
        {
            customerQueue.Enqueue(customer);
        }

        public string ServeCustomer()
        {
            return customerQueue.Dequeue();
        }

        public string NextCustomer()
        {
            return customerQueue.Peek();
        }

    }
}
