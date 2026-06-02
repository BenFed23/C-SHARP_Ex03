using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle: Motorcycle
    {
        protected FuelSource m_FuelSource;
        public FuelMotorcycle(string i_LicensePlateNumber, string i_ModelName) : base(i_LicensePlateNumber, i_ModelName)
        {

        }
        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
        }
        public override string ToString()
        {
            string details = base.ToString();
            details += m_FuelSource.ToString();

            return details;
        }
       public override List<string> GetSpecialPrameters()
       {
            List<string> result = new List<string>();

            return result;
        }
    }
}
