namespace Question_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A company has an Employee class with properties Name and Salary.
            // The company also has a Manager class that inherits from Employee
            //and has an additional property Bonus.
            // The Employee class has a method DisplayDetails(),
            // which prints the employee’s name and salary.
            // The Manager class overrides this method to include the bonus
            //amount in the output.

            // Creating an instance of Employee
            Employee emp = new Employee("Alice", 50000);
            emp.DisplayDetails();

            // Creating an instance of Manager
            Manager mgr = new Manager("Bob", 80000, 15000);
            mgr.DisplayDetails();

            //Hybrid instance 
            Employee emp1 = new Manager("Ash", 90000, 15000);
            emp1.DisplayDetails();
        }
    }
}
