

namespace Question1
{
    public class Employee
    {
        public int ID { get; set; } // Properties 
        public string Name { get; set; } // Properties 
        public DateTime JoinDate { get; set; } // Properties 

        public Employee(int id, string name, DateTime joindate)
        {
            ID = id;
            Name = name;
            JoinDate = joindate;
        }
        public void EmployeeDetails()
        {
            Console.WriteLine($"The emplyee id is {ID}");
            Console.WriteLine($"The Employee name is {Name}");
            Console.WriteLine($"Joining Date {JoinDate}");
        }
    }
}
