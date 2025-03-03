using   Question_2.Vehicles;
namespace Question_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 2
            //Develop a c# program to define a common structure for
            //different vehicle insurance policies(Two - Wheeler, FourWheeler, Commercial) while allowing specific policies to
            //implement their own premium calculation?

            VehicleInsurance twoWheelerInsurance = new TwoWheelerInsurance();
            VehicleInsurance fourWheelerInsurance = new FourWheelerInsurance();
            VehicleInsurance commercialInsurance = new CommercialInsurance();

            Console.WriteLine("Two Wheeler Insurance Premium: " + twoWheelerInsurance.CalculatePremium());
            Console.WriteLine("Four Wheeler Insurance Premium: " + fourWheelerInsurance.CalculatePremium());
            Console.WriteLine("Commercial Insurance Premium: " + commercialInsurance.CalculatePremium());
            #endregion
        }
    }
}
