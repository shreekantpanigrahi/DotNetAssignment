namespace Question_2.Vehicles
{
    public abstract class VehicleInsurance
    {
        //Bsae class for Vehicle Insurance
        public string VehicleType { get; set; }

        public abstract double CalculatePremium();
    }
}
