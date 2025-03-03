namespace A2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question 2
            Console.WriteLine("Enter the student name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student age: ");
            string ageInput = Console.ReadLine();
            int age;
            bool isValidAge=int.TryParse(ageInput, out age);

            if (!isValidAge)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value for age.");
                return;
            }

            Console.WriteLine("Enter the student percentage: ");
            double percentage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Name::{name}\t Age::{age}\t Percentage::{percentage}%");
            #endregion
        }
    }
}
