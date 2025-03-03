namespace AutoTechSolutions
{
    public class Car
    {
        // Private Fields (Encapsulation)
        private int carID;
        private string brand;
        private string model;
        private int year;
        private double price;

        public int CarID
        {
            get { return carID; }
            set { carID = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        // Parameterized Constructor (Overloading)
        public Car(int carID, string brand, string model, int year, double price)
        {
            Console.WriteLine("Receiving Car Information...");
            this.carID = carID;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        // Default Constructor (Overloading)
        public Car()
        {
            Console.WriteLine("Creating Car with Default Values...");
            this.carID = 0;
            this.brand = "Unknown";
            this.model = "Unknown";
            this.year = 2000;
            this.price = 10000; 
        }

        // Method to Display Car Details
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
