namespace A3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question 3
            Console.WriteLine("Enter the student name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the student age: ");
            string ageInput = Console.ReadLine();
            int age;
            bool isValidAge = int.TryParse(ageInput, out age);

            if (!isValidAge)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value for age.");
                return;
            }

            Console.WriteLine("Enter the student percentage: ");
            double percentage = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Student Email: ");
            string email = Console.ReadLine();

            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email cannot be empty. Please enter a valid email.");
                return; 
            }


            Console.WriteLine($"Name::{name}\t Age::{age}\t Percentage::{percentage}%");
            #endregion
        }
    }
}
