
namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are developing an Employee Management System in C#. The system
            //has an Employee class that stores employee details, but it does not have a
            //method to calculate the years of experience based on the joining date.
            //(Use DateTime struct properties to extract year from date) write a c#
            //program for the same.

            Employee emp = new Employee(1, "shuu", new DateTime(2015, 6, 1));
            emp.EmployeeDetails();
            Console.WriteLine($"The yearsof experience is {emp.CalcYearOfExp()}");

        }
}
}
