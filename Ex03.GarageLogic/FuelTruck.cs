using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;


namespace Ex03.GarageLogic
{
    internal class FuelTruck: Vehicle
    {
        private bool m_HasRefrigeratedCargo;
        private float m_CargoVolume;
        protected FuelSource m_FuelSource;

        public FuelTruck(string i_ModelName, string i_LicensePlateNumber) : base(i_ModelName, i_LicensePlateNumber)
        {

        }

        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
        }
        public override List<string> GetSpecialPrameters()
        {
            return null;
        }
        public override string ToString()
        {
            string vehicleDetails = base.ToString();
            vehicleDetails += m_CargoVolume + " " + m_HasRefrigeratedCargo + " " + m_FuelSource.ToString();

            return vehicleDetails;
        }
    }
}
