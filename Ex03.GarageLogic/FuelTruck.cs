using System;


namespace Ex03.GarageLogic
{
    internal class FuelTruck: Vehicle
    {
        bool m_HasRefrigeratedCargo;
        float m_CargoVolume;
        public FuelTruck(string i_ModelName, string i_LicenseNumber) : base(i_ModelName, i_LicenseNumber)
        {

        }
    }
}
