using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2.Vehicles
{
    public class FourWheelerInsurance: VehicleInsurance
    {
        public FourWheelerInsurance()
        {
            VehicleType = "Four-Wheeler";
        }
        public override double CalculatePremium()
        {
            return 2000;
        }
    }
}
