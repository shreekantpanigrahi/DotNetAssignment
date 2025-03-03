namespace A4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are building a hospital management system where a patient’s discharge date may not
            //always be available
            // The system should allow null values for the discharge date but still be able
            // to check if a patient has been discharged.
            // If the patient has the discharge date print it to the console, if discharge date is
            //null then print “Not Discharged” message to the console. 

            #region question 4
            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Patient Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the date of discharge(DD:MM:YY): ");
            string dischargedateinput= Console.ReadLine();
            string? datedischarge = null;

            if (string.IsNullOrEmpty(dischargedateinput))
            {
                Console.WriteLine("Not Discharged"); //means the value is null
            }
            else
            {
                datedischarge = DateTime.Parse(dischargedateinput);
                Console.WriteLine($"Discharge Date: {datedischarge.Value.ToString("dd/MM/yyyy")}");
            }
            #endregion

        }
    }
}
