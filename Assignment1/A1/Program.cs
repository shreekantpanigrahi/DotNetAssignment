namespace A1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question 1
            Console.WriteLine("Enter the student name: ");
            string name= Console.ReadLine();

            Console.WriteLine("Enter the student age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the student percentage: ");
            double percentage = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Name::{name}\t Age::{age}\t Percentage::{percentage}%");
            #endregion


        }
    }
}
