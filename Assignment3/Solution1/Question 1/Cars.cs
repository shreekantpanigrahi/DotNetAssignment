using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    class Cars
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public void AcceptCarDetails(int carID, string brand, string model, int year, double price)
        {
            Console.WriteLine("Receiving Car Information...");
            CarID = carID;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }

        public void DisplayCarDetails()
        {
            Console.WriteLine("Presenting Car Information...");
            Console.WriteLine($"Car ID: {CarID}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Price: ₹{Price}");
        }
    }
}
