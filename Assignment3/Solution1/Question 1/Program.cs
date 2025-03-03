

namespace Question_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are part of a development team at AutoTech Solutions, working on a
            //Car Management Module for a vehicle dealership.You have been
            //assigned the task of creating a Car class that accepts and displays car
            //details.
            // Declare a Car class with appropriate member functions.
            //o CarID(unique identifier)
            //o Brand(e.g., Toyota, Ford)
            //o Model(e.g., Corolla, Mustang)
            //o Year(manufacturing year)
            //o Price(cost of the car)
            // The member function that accepts car details should display the
            //message "Receiving Car Information".
            // The member function to display car details should show the message
            //"Presenting Car Information".

            Cars myCar = new Cars();
            myCar.AcceptCarDetails(101, "Toyota", "Corolla", 2022, 20000);
            myCar.DisplayCarDetails();



        }
}
}
