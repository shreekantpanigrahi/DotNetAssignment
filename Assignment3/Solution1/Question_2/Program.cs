using AutoTechSolutions; 
class Program
{
    static void Main(string[] args)
    {
        
        Car myCar = new Car(101, "Toyota", "Corolla", 2022, 20000);
        myCar.DisplayCarDetails();

        Console.WriteLine("\n------------------\n");

        Car defaultCar = new Car();
        defaultCar.DisplayCarDetails();
    }
}
