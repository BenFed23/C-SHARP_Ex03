using System;


namespace Ex03.GarageLogic
{
    internal class FuelTruck: Vehicle
    {
        private bool m_HasRefrigeratedCargo;
        private float m_CargoVolume;
        protected FuelSource m_FuelSource;
        private const int k_AmountOfWheels = 14;
        private const int k_MaxAirPressure = 23;

        public FuelTruck(string i_ModelName, string i_LicensePlateNumber) : base(i_ModelName, i_LicensePlateNumber)
        {
            m_tyresCollection = new Tyre[k_AmountOfWheels];
            for (int i = 0; i < m_tyresCollection.Length; i++)
            {
                m_tyresCollection[i] = new Tyre(k_MaxAirPressure);
                m_FuelSource = new FuelSource(125, eFuelType.Soler);
                m_HasRefrigeratedCargo = false;
                m_CargoVolume = 0;
            }
        }

        public override void Refuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            m_FuelSource.RefuelVehicle(i_AmountOfFuelToAdd, i_FuelType);
            m_energyPercentages = (m_FuelSource.FuelAmount / m_FuelSource.MaxFuelCapacity) * 100;
        }
    }
}
