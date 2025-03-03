
namespace Question_2.Vehicles
{
    public class TwoWheelerInsurance:VehicleInsurance
    {
        public TwoWheelerInsurance() 
        {
            VehicleType = "Two-Wheeler";
        }
        public override double CalculatePremium()
        {
            return 1000;
        }
    }
}
