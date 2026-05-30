using System;


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
    }
}
