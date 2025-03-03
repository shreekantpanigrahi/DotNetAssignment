using System.Diagnostics.Metrics;

namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A software company wants to develop a Salary Calculation System that
            //calculates the Net Salary of employees based on their basic salary, tax
            //deductions, and bonus. The system should perform various operations
            //using arithmetic, relational, logical operators
            // Take the basic salary as user input.
            // Calculate a tax deduction(10 % of the basic salary).
            // Add a bonus based on performance ratings:
            // Rating >= 8 → Bonus = 20 % of the basic salary.
            // Rating >= 5 and < 8 → Bonus = 10 % of the basic salary.
            // Rating < 5 → No bonus.
            // Display the computed salary after all calculations.
            #region question 1

            Console.Write("Enter the basic salary of the employee: ");
            double basicSalary=double.Parse(Console.ReadLine());

            double taxDeduction = basicSalary * 0.1;
            Console.WriteLine("The tax deduction is: " + taxDeduction);

            double bonus = 0;

            Console.WriteLine("Enter the performance rating of the employee: ");
            int rating = int.Parse(Console.ReadLine());

            if(rating >= 8)
            {
                bonus = basicSalary * 0.2;
            }
            else if(rating >=5 && rating < 8)
            {
                bonus = basicSalary * 0.10;
            }

            Console.WriteLine("The bonus is: " + bonus);
            double netSalary = basicSalary - taxDeduction + bonus;
            Console.WriteLine("The net salary of the employee is: " + netSalary);

            #endregion
        }
    }
}
