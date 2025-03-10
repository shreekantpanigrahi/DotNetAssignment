using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class StudentReg
    {
        private HashSet<int> studentIDs=new HashSet<int>();
        public void Register(int studentID)
        {
            if (studentIDs.Contains(studentID))
            {
                Console.WriteLine($"Student {studentID} already registered");
            }
            else
            {
                studentIDs.Add(studentID);
                Console.WriteLine("Student registered successfully");
            }
        }

        public void ShowRegisteredStudents()
        {
            if (studentIDs.Count==0) 
            {
                Console.WriteLine("No students registered yet.");
            }
            else
            {
                Console.WriteLine("Registered Students:");
                foreach (var id in studentIDs)
                {
                    Console.WriteLine(id);
                }
            }
        }
    }
}
