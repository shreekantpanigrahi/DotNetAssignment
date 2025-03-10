using static Question_2.StudentReg;
namespace Question_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A university is conducting an event where students register for workshops.However, a student can only register once for a particular workshop.
            //You need to store unique student IDs for each workshop.If a student tries to register again, the system should prevent duplicates.Implement with C# 

            StudentReg studentReg = new StudentReg();
            while (true) { 
                Console.WriteLine("Enter 1 to register a student, 2 to show registered students, 3 to exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Enter studentID to register a student: ");
                    int studentID = int.Parse(Console.ReadLine());
                    studentReg.Register(studentID);

                }
                else if (choice == 2)
                {
                        Console.WriteLine("Here below is the registered students");
                        studentReg.ShowRegisteredStudents();
                    
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }

            Console.WriteLine("Thank you for using our service and registeration");

        }
    }
}
