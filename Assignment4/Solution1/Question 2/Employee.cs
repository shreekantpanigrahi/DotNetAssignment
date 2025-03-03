using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public Employee(string name, double salary)
        {
             Name = name;
             Salary = salary;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"The name is {Name} and the salary is {Salary}");
        }




    }
}
