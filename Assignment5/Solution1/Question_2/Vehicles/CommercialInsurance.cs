using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2.Vehicles
{
    public class CommercialInsurance : VehicleInsurance
    {
        public CommercialInsurance()
        {
            VehicleType = "Commercial";
        }
        public override double CalculatePremium()
        {
            return 5000;
        }
    }
}
