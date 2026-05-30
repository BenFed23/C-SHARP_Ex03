using System;

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
    }
}
