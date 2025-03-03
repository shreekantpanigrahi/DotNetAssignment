using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Manager:Employee
    {
        public double Bonus { get; set; }

        public Manager(string name, double salary, double bonus):base(name, salary)
        {
            Bonus = bonus;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"The name is {Name}, salary is {Salary} and the bonus is {Bonus}");
        }
    }
}
